using System;
using System.Collections.Generic;

namespace SDA_559ir.Models
{
    public sealed class NewOrderDraft
    {
        public long? OrderId { get; set; }

        public string CustomerName { get; set; } = "";
        public string CustomerPhone { get; set; } = "";
        public string DeliveryAddress { get; set; } = "";

        public int? CourierId { get; set; }
        public DateTime? DeliverAt { get; set; }
        public OrderStatus Status { get; set; } = OrderStatus.New;

        public Dictionary<long, int> ItemsByMenuItemId { get; } = new Dictionary<long, int>();

        public int GetQty(long menuItemId)
        {
            return ItemsByMenuItemId.TryGetValue(menuItemId, out var q) ? q : 0;
        }

        public void SetQty(long menuItemId, int qty)
        {
            if (qty <= 0) ItemsByMenuItemId.Remove(menuItemId);
            else ItemsByMenuItemId[menuItemId] = qty;
        }

        public bool HasItems()
        {
            return ItemsByMenuItemId.Count > 0;
        }

        public void ClearAll()
        {
            OrderId = null;
            CustomerName = "";
            CustomerPhone = "";
            DeliveryAddress = "";
            CourierId = null;
            DeliverAt = null;
            Status = OrderStatus.New;
            ItemsByMenuItemId.Clear();
        }

        public void CopyFrom(NewOrderDraft src)
        {
            if (src == null) throw new ArgumentNullException(nameof(src));

            OrderId = src.OrderId;
            CustomerName = src.CustomerName ?? "";
            CustomerPhone = src.CustomerPhone ?? "";
            DeliveryAddress = src.DeliveryAddress ?? "";

            CourierId = src.CourierId;
            DeliverAt = src.DeliverAt;
            Status = src.Status;

            ItemsByMenuItemId.Clear();
            foreach (var kv in src.ItemsByMenuItemId)
                ItemsByMenuItemId[kv.Key] = kv.Value;
        }
    }
}
