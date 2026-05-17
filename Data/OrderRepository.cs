using Microsoft.Data.Sqlite;
using VSP__559ir_MyProject.Models;

namespace VSP__559ir_MyProject.Data
{
    internal sealed class OrderRepository
    {
        public long SaveOrder(NewOrderDraft draft)
        {
            if (draft.OrderId.HasValue)
            {
                UpdateOrder(draft);
                return draft.OrderId.Value;
            }

            var id = CreateOrder(draft);
            draft.OrderId = id;
            return id;
        }

        public long CreateOrder(NewOrderDraft draft)
        {
            using var conn = Db.OpenConnection();
            using var tx = conn.BeginTransaction();

            // Insert order header
            using var cmd = conn.CreateCommand();
            cmd.Transaction = tx;
            cmd.CommandText = @"
INSERT INTO orders (customer_name, customer_phone, delivery_address, courier_id, deliver_at, status)
VALUES (@cn, @cp, @addr, @courierId, @deliverAt, @status);
SELECT last_insert_rowid();
";
            cmd.Parameters.AddWithValue("@cn", (draft.CustomerName ?? "").Trim());
            cmd.Parameters.AddWithValue("@cp", (draft.CustomerPhone ?? "").Trim());
            cmd.Parameters.AddWithValue("@addr", (draft.DeliveryAddress ?? "").Trim());
            cmd.Parameters.AddWithValue("@courierId", draft.CourierId.HasValue ? draft.CourierId.Value : (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@deliverAt", draft.DeliverAt.HasValue ? draft.DeliverAt.Value.ToString("yyyy-MM-dd HH:mm") : "");
            cmd.Parameters.AddWithValue("@status", (int)draft.Status);

            var orderId = Convert.ToInt64(cmd.ExecuteScalar());

            // Insert items with snapshot price
            foreach (var kv in draft.ItemsByMenuItemId)
            {
                var menuItemId = kv.Key;
                var qty = kv.Value;
                if (qty <= 0) continue;

                var unitPrice = GetMenuItemPrice(conn, tx, menuItemId);

                using var itemCmd = conn.CreateCommand();
                itemCmd.Transaction = tx;
                itemCmd.CommandText = @"
INSERT INTO order_items (order_id, menu_item_id, qty, unit_price_eur)
VALUES (@oid, @mid, @qty, @price);
";
                itemCmd.Parameters.AddWithValue("@oid", orderId);
                itemCmd.Parameters.AddWithValue("@mid", menuItemId);
                itemCmd.Parameters.AddWithValue("@qty", qty);
                itemCmd.Parameters.AddWithValue("@price", unitPrice);
                itemCmd.ExecuteNonQuery();
            }

            tx.Commit();
            return orderId;
        }

        public void UpdateOrder(NewOrderDraft draft)
        {
            if (!draft.OrderId.HasValue)
                throw new InvalidOperationException("OrderId is required for update.");

            using var conn = Db.OpenConnection();
            using var tx = conn.BeginTransaction();

            // Update order header
            using (var cmd = conn.CreateCommand())
            {
                cmd.Transaction = tx;
                cmd.CommandText = @"
UPDATE orders
SET customer_name = @cn,
    customer_phone = @cp,
    delivery_address = @addr,
    courier_id = @courierId,
    deliver_at = @deliverAt,
    status = @status
WHERE id = @id;
";
                cmd.Parameters.AddWithValue("@id", draft.OrderId.Value);
                cmd.Parameters.AddWithValue("@cn", (draft.CustomerName ?? "").Trim());
                cmd.Parameters.AddWithValue("@cp", (draft.CustomerPhone ?? "").Trim());
                cmd.Parameters.AddWithValue("@addr", (draft.DeliveryAddress ?? "").Trim());
                cmd.Parameters.AddWithValue("@courierId", draft.CourierId.HasValue ? draft.CourierId.Value : (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@deliverAt", draft.DeliverAt.HasValue ? draft.DeliverAt.Value.ToString("yyyy-MM-dd HH:mm") : "");
                cmd.Parameters.AddWithValue("@status", (int)draft.Status);

                cmd.ExecuteNonQuery();
            }

            // Replace items: delete all, then insert current selection
            using (var del = conn.CreateCommand())
            {
                del.Transaction = tx;
                del.CommandText = "DELETE FROM order_items WHERE order_id = @id;";
                del.Parameters.AddWithValue("@id", draft.OrderId.Value);
                del.ExecuteNonQuery();
            }

            foreach (var kv in draft.ItemsByMenuItemId)
            {
                var menuItemId = kv.Key;
                var qty = kv.Value;
                if (qty <= 0) continue;

                var unitPrice = GetMenuItemPrice(conn, tx, menuItemId);

                using var itemCmd = conn.CreateCommand();
                itemCmd.Transaction = tx;
                itemCmd.CommandText = @"
INSERT INTO order_items (order_id, menu_item_id, qty, unit_price_eur)
VALUES (@oid, @mid, @qty, @price);
";
                itemCmd.Parameters.AddWithValue("@oid", draft.OrderId.Value);
                itemCmd.Parameters.AddWithValue("@mid", menuItemId);
                itemCmd.Parameters.AddWithValue("@qty", qty);
                itemCmd.Parameters.AddWithValue("@price", unitPrice);
                itemCmd.ExecuteNonQuery();
            }

            tx.Commit();
        }

        public NewOrderDraft? GetOrderDraft(long orderId)
        {
            using var conn = Db.OpenConnection();

            // Header
            using var oCmd = conn.CreateCommand();
            oCmd.CommandText = @"
SELECT id, customer_name, customer_phone, delivery_address, courier_id, deliver_at, status
FROM orders
WHERE id = @id;
";
            oCmd.Parameters.AddWithValue("@id", orderId);

            using var r = oCmd.ExecuteReader();
            if (!r.Read()) return null;

            var draft = new NewOrderDraft
            {
                OrderId = r.GetInt64(r.GetOrdinal("id")),
                CustomerName = r.GetString(r.GetOrdinal("customer_name")),
                CustomerPhone = r.GetString(r.GetOrdinal("customer_phone")),
                DeliveryAddress = r.GetString(r.GetOrdinal("delivery_address")),
                CourierId = r.IsDBNull(r.GetOrdinal("courier_id")) ? null : r.GetInt32(r.GetOrdinal("courier_id")),
                Status = (OrderStatus)r.GetInt32(r.GetOrdinal("status"))
            };

            var deliverAtRaw = r.GetString(r.GetOrdinal("deliver_at"));
            if (!string.IsNullOrWhiteSpace(deliverAtRaw))
            {
                if (DateTime.TryParse(deliverAtRaw, out var dt))
                    draft.DeliverAt = dt;
            }

            // Items
            using var iCmd = conn.CreateCommand();
            iCmd.CommandText = @"
SELECT menu_item_id, qty
FROM order_items
WHERE order_id = @id;
";
            iCmd.Parameters.AddWithValue("@id", orderId);

            using var ir = iCmd.ExecuteReader();
            while (ir.Read())
            {
                var menuItemId = ir.GetInt64(ir.GetOrdinal("menu_item_id"));
                var qty = ir.GetInt32(ir.GetOrdinal("qty"));
                draft.ItemsByMenuItemId[menuItemId] = qty;
            }

            return draft;
        }

        private static decimal GetMenuItemPrice(SqliteConnection conn, SqliteTransaction tx, long menuItemId)
        {
            using var cmd = conn.CreateCommand();
            cmd.Transaction = tx;
            cmd.CommandText = "SELECT price_eur FROM menu_items WHERE id = @id;";
            cmd.Parameters.AddWithValue("@id", menuItemId);

            var raw = cmd.ExecuteScalar();
            if (raw == null || raw == DBNull.Value) return 0m;

            return Convert.ToDecimal(raw);
        }

        public ReceiptData? GetReceiptData(long orderId)
        {
            using var conn = Db.OpenConnection();

            // Read order header
            using var oCmd = conn.CreateCommand();
            oCmd.CommandText = @"
SELECT o.id,
       o.customer_name,
       o.customer_phone,
       o.delivery_address,
       o.deliver_at,
       o.status,
       o.created_at,
       COALESCE(c.name, '') AS courier_name
FROM orders o
LEFT JOIN couriers c ON c.id = o.courier_id
WHERE o.id = @id;
";
            oCmd.Parameters.AddWithValue("@id", orderId);

            using var r = oCmd.ExecuteReader();
            if (!r.Read()) return null;

            var data = new ReceiptData
            {
                OrderId = r.GetInt64(r.GetOrdinal("id")),
                CustomerName = r.GetString(r.GetOrdinal("customer_name")),
                CustomerPhone = r.GetString(r.GetOrdinal("customer_phone")),
                DeliveryAddress = r.GetString(r.GetOrdinal("delivery_address")),
                DeliverAt = r.GetString(r.GetOrdinal("deliver_at")),
                CreatedAt = r.GetString(r.GetOrdinal("created_at")),
                Status = r.GetInt32(r.GetOrdinal("status")),
                CourierName = r.GetString(r.GetOrdinal("courier_name"))
            };

            // Read items
            using var iCmd = conn.CreateCommand();
            iCmd.CommandText = @"
SELECT mi.product_name,
       oi.qty,
       oi.unit_price_eur
FROM order_items oi
JOIN menu_items mi ON mi.id = oi.menu_item_id
WHERE oi.order_id = @id
ORDER BY mi.product_name;
";
            iCmd.Parameters.AddWithValue("@id", orderId);

            using var ir = iCmd.ExecuteReader();
            while (ir.Read())
            {
                data.Items.Add(new ReceiptItem
                {
                    ProductName = ir.GetString(ir.GetOrdinal("product_name")),
                    Qty = ir.GetInt32(ir.GetOrdinal("qty")),
                    UnitPriceEur = Convert.ToDecimal(ir.GetDouble(ir.GetOrdinal("unit_price_eur")))
                });
            }

            return data;
        }

        public List<OrderListRow> SearchOrders(string? query, int? courierId)
        {
            using var conn = Db.OpenConnection();
            using var cmd = conn.CreateCommand();

            var q = (query ?? "").Trim();

            cmd.CommandText = @"
SELECT
  o.id AS order_id,
  o.customer_name,
  o.customer_phone,
  o.delivery_address,
  COALESCE(c.name, '') AS courier_name,
  COALESCE(o.created_at, '') AS created_at,
  COALESCE(o.deliver_at, '') AS deliver_at,
  o.status AS status,
  COALESCE(SUM(oi.qty * oi.unit_price_eur), 0) AS total_eur
FROM orders o
LEFT JOIN couriers c ON c.id = o.courier_id
LEFT JOIN order_items oi ON oi.order_id = o.id
WHERE
  (@courierId IS NULL OR o.courier_id = @courierId)
  AND (
    @q = ''
    OR o.customer_name LIKE @ql
    OR o.customer_phone LIKE @ql
    OR o.delivery_address LIKE @ql
    OR COALESCE(c.name,'') LIKE @ql
    OR COALESCE(o.created_at,'') LIKE @ql
    OR COALESCE(o.deliver_at,'') LIKE @ql
    OR CAST(o.id AS TEXT) LIKE @ql
  )
GROUP BY o.id, o.customer_name, o.customer_phone, o.delivery_address, courier_name, created_at, deliver_at, o.status
ORDER BY o.id DESC;
";

            cmd.Parameters.AddWithValue("@courierId", courierId.HasValue ? courierId.Value : (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@q", q);
            cmd.Parameters.AddWithValue("@ql", $"%{q}%");

            var list = new List<OrderListRow>();
            using var r = cmd.ExecuteReader();
            while (r.Read())
            {
                list.Add(new OrderListRow
                {
                    OrderId = r.GetInt64(r.GetOrdinal("order_id")),
                    CustomerName = r.GetString(r.GetOrdinal("customer_name")),
                    CustomerPhone = r.GetString(r.GetOrdinal("customer_phone")),
                    DeliveryAddress = r.GetString(r.GetOrdinal("delivery_address")),
                    CourierName = r.GetString(r.GetOrdinal("courier_name")),
                    CreatedAt = r.GetString(r.GetOrdinal("created_at")),
                    DeliverAt = r.GetString(r.GetOrdinal("deliver_at")),
                    Status = r.GetInt32(r.GetOrdinal("status")),
                    TotalEur = Convert.ToDecimal(r.GetDouble(r.GetOrdinal("total_eur")))
                });
            }

            return list;
        }
    }

    internal sealed class ReceiptData
    {
        public long OrderId { get; set; }
        public string CustomerName { get; set; } = "";
        public string CustomerPhone { get; set; } = "";
        public string DeliveryAddress { get; set; } = "";
        public string DeliverAt { get; set; } = "";
        public string CreatedAt { get; set; } = "";
        public int Status { get; set; }
        public string CourierName { get; set; } = "";

        public List<ReceiptItem> Items { get; } = new List<ReceiptItem>();

        public string StatusText
        {
            get
            {
                return Status switch
                {
                    0 => "New",
                    1 => "On the way",
                    2 => "Completed",
                    _ => "Unknown"
                };
            }
        }
    }

    internal sealed class ReceiptItem
    {
        public string ProductName { get; set; } = "";
        public int Qty { get; set; }
        public decimal UnitPriceEur { get; set; }
    }
}
