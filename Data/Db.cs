using Microsoft.Data.Sqlite;

namespace SDA_559ir.Data
{
    internal static class Db
    {
        private static readonly string DbPath =
            Path.Combine(AppContext.BaseDirectory, "daj_da_yam.db");

        private static readonly string ConnectionString =
            $"Data Source={DbPath};Cache=Shared";

        public static SqliteConnection OpenConnection()
        {
            EnsureCreated();
            var conn = new SqliteConnection(ConnectionString);
            conn.Open();

            // Ensure FK support if we add relations later
            using var pragma = conn.CreateCommand();
            pragma.CommandText = "PRAGMA foreign_keys = ON;";
            pragma.ExecuteNonQuery();

            return conn;
        }

        private static void EnsureCreated()
        {
            // If the file exists, we still ensure tables exist
            using var conn = new SqliteConnection(ConnectionString);
            conn.Open();

            using var cmd = conn.CreateCommand();
            cmd.CommandText = @"
                CREATE TABLE IF NOT EXISTS menu_items (
                  id INTEGER PRIMARY KEY AUTOINCREMENT,
                  product_name TEXT NOT NULL,
                  category_id INTEGER NOT NULL,
                  description TEXT NOT NULL DEFAULT '',
                  weight_grams REAL NOT NULL DEFAULT 0,
                  price_eur REAL NOT NULL DEFAULT 0,
                  image_path TEXT NOT NULL DEFAULT '',
                  FOREIGN KEY (category_id) REFERENCES categories(id)
                );

                CREATE TABLE IF NOT EXISTS categories (
                  id INTEGER PRIMARY KEY AUTOINCREMENT,
                  name TEXT NOT NULL UNIQUE
                );

                CREATE TABLE IF NOT EXISTS couriers (
                  id INTEGER PRIMARY KEY AUTOINCREMENT,
                  name TEXT NOT NULL UNIQUE,
                  phone TEXT NOT NULL DEFAULT '',
                  is_active INTEGER NOT NULL DEFAULT 1
                );

                CREATE TABLE IF NOT EXISTS orders (
                  id INTEGER PRIMARY KEY AUTOINCREMENT,
                  customer_name TEXT NOT NULL DEFAULT '',
                  customer_phone TEXT NOT NULL DEFAULT '',
                  delivery_address TEXT NOT NULL DEFAULT '',
                  courier_id INTEGER NULL,
                  deliver_at TEXT NOT NULL DEFAULT '',
                  status INTEGER NOT NULL DEFAULT 0,
                  created_at TEXT NOT NULL DEFAULT (datetime('now'))
                );

                CREATE TABLE IF NOT EXISTS order_items (
                  id INTEGER PRIMARY KEY AUTOINCREMENT,
                  order_id INTEGER NOT NULL,
                  menu_item_id INTEGER NOT NULL,
                  qty INTEGER NOT NULL DEFAULT 0,
                  unit_price_eur REAL NOT NULL DEFAULT 0,
                  FOREIGN KEY (order_id) REFERENCES orders(id) ON DELETE CASCADE,
                  FOREIGN KEY (menu_item_id) REFERENCES menu_items(id)
                );

                CREATE INDEX IF NOT EXISTS idx_order_items_order_id ON order_items(order_id);

                ";
            cmd.ExecuteNonQuery();

            SeedIfEmpty(conn);
        }

        private static void SeedIfEmpty(SqliteConnection conn)
        {
            SeedMenuIfEmpty(conn);
            SeedCouriersIfEmpty(conn);
        }

        private static void SeedMenuIfEmpty(SqliteConnection conn)
        {
            using var countCmd = conn.CreateCommand();
            countCmd.CommandText = "SELECT COUNT(1) FROM menu_items;";
            var count = Convert.ToInt64(countCmd.ExecuteScalar());
            if (count > 0) return;

            using var seedCmd = conn.CreateCommand();
            seedCmd.CommandText = @"
                INSERT OR IGNORE INTO categories(name) VALUES
                ('Pizza'),
                ('Burgers'),
                ('Salads'),
                ('Desserts'),
                ('Drinks');

                INSERT INTO menu_items(product_name, category_id, description, weight_grams, price_eur, image_path)
                VALUES
                ('Margherita Pizza', (SELECT id FROM categories WHERE name='Pizza'), 'Classic pizza with tomato and mozzarella', 450, 9.99, ''),
                ('Caesar Salad', (SELECT id FROM categories WHERE name='Salads'), 'Chicken, parmesan, croutons', 350, 7.50, '');
                ";
            seedCmd.ExecuteNonQuery();
        }

        private static void SeedCouriersIfEmpty(SqliteConnection conn)
        {
            using var countCmd = conn.CreateCommand();
            countCmd.CommandText = "SELECT COUNT(1) FROM couriers;";
            var count = Convert.ToInt64(countCmd.ExecuteScalar());
            if (count > 0) return;

            using var seedCmd = conn.CreateCommand();
            seedCmd.CommandText = @"
                INSERT OR IGNORE INTO couriers(name, phone, is_active) VALUES
                ('Ivan', '0888000001', 1),
                ('Maria', '0888000002', 1);
                ";
            seedCmd.ExecuteNonQuery();
        }

    }
}
