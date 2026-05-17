using Microsoft.Data.Sqlite;
using VSP__559ir_MyProject.Models;

namespace VSP__559ir_MyProject.Data
{
    internal sealed class MenuRepository
    {
        public List<Category> GetCategories()
        {
            using var conn = Db.OpenConnection();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT id, name FROM categories ORDER BY name;";

            var list = new List<Category>();
            using var r = cmd.ExecuteReader();
            while (r.Read())
            {
                list.Add(new Category
                {
                    Id = r.GetInt64(r.GetOrdinal("id")),
                    Name = r.GetString(r.GetOrdinal("name"))
                });
            }

            return list;
        }

        public List<MenuItem> GetMenuItems(long? categoryId)
        {
            using var conn = Db.OpenConnection();
            using var cmd = conn.CreateCommand();

            cmd.CommandText = @"
                SELECT mi.id,
                       mi.product_name,
                       mi.category_id,
                       c.name AS category_name,
                       mi.description,
                       mi.weight_grams,
                       mi.price_eur,
                       mi.image_path
                FROM menu_items mi
                JOIN categories c ON c.id = mi.category_id
                WHERE (@cat IS NULL OR mi.category_id = @cat)
                ORDER BY mi.product_name;
                ";

            cmd.Parameters.AddWithValue("@cat", categoryId.HasValue ? categoryId.Value : (object)DBNull.Value);

            var list = new List<MenuItem>();
            using var r = cmd.ExecuteReader();
            while (r.Read())
            {
                list.Add(new MenuItem
                {
                    Id = r.GetInt64(r.GetOrdinal("id")),
                    ProductName = r.GetString(r.GetOrdinal("product_name")),
                    CategoryId = r.GetInt64(r.GetOrdinal("category_id")),
                    Description = r.GetString(r.GetOrdinal("description")),
                    WeightGrams = r.GetDouble(r.GetOrdinal("weight_grams")),
                    PriceEur = r.GetDouble(r.GetOrdinal("price_eur")),
                    ImagePath = r.GetString(r.GetOrdinal("image_path")),
                    CategoryName = r.GetString(r.GetOrdinal("category_name"))
                });
            }

            return list;
        }

        public List<MenuItem> GetAll()
        {
            return GetMenuItems(null);
        }

        public MenuItem? GetById(long id)
        {
            using var conn = Db.OpenConnection();
            using var cmd = conn.CreateCommand();

            cmd.CommandText = @"
                SELECT mi.id,
                       mi.product_name,
                       mi.category_id,
                       c.name AS category_name,
                       mi.description,
                       mi.weight_grams,
                       mi.price_eur,
                       mi.image_path
                FROM menu_items mi
                JOIN categories c ON c.id = mi.category_id
                WHERE mi.id = @id
                LIMIT 1;
                ";
            cmd.Parameters.AddWithValue("@id", id);

            using var r = cmd.ExecuteReader();
            if (!r.Read()) return null;

            return new MenuItem
            {
                Id = r.GetInt64(r.GetOrdinal("id")),
                ProductName = r.GetString(r.GetOrdinal("product_name")),
                CategoryId = r.GetInt64(r.GetOrdinal("category_id")),
                Description = r.GetString(r.GetOrdinal("description")),
                WeightGrams = r.GetDouble(r.GetOrdinal("weight_grams")),
                PriceEur = r.GetDouble(r.GetOrdinal("price_eur")),
                ImagePath = r.GetString(r.GetOrdinal("image_path")),
                CategoryName = r.GetString(r.GetOrdinal("category_name"))
            };
        }

        public long Create(MenuItem item)
        {
            using var conn = Db.OpenConnection();
            using var cmd = conn.CreateCommand();

            cmd.CommandText = @"
INSERT INTO menu_items(product_name, category_id, description, weight_grams, price_eur, image_path)
VALUES(@name, @cat, @desc, @w, @p, @img);
SELECT last_insert_rowid();
";
            cmd.Parameters.AddWithValue("@name", (item.ProductName ?? "").Trim());
            cmd.Parameters.AddWithValue("@cat", item.CategoryId);
            cmd.Parameters.AddWithValue("@desc", item.Description ?? "");
            cmd.Parameters.AddWithValue("@w", item.WeightGrams);
            cmd.Parameters.AddWithValue("@p", item.PriceEur);
            cmd.Parameters.AddWithValue("@img", item.ImagePath ?? "");

            return Convert.ToInt64(cmd.ExecuteScalar());
        }

        public void Update(MenuItem item)
        {
            using var conn = Db.OpenConnection();
            using var cmd = conn.CreateCommand();

            cmd.CommandText = @"
UPDATE menu_items
SET product_name = @name,
    category_id = @cat,
    description = @desc,
    weight_grams = @w,
    price_eur = @p,
    image_path = @img
WHERE id = @id;
";
            cmd.Parameters.AddWithValue("@id", item.Id);
            cmd.Parameters.AddWithValue("@name", (item.ProductName ?? "").Trim());
            cmd.Parameters.AddWithValue("@cat", item.CategoryId);
            cmd.Parameters.AddWithValue("@desc", item.Description ?? "");
            cmd.Parameters.AddWithValue("@w", item.WeightGrams);
            cmd.Parameters.AddWithValue("@p", item.PriceEur);
            cmd.Parameters.AddWithValue("@img", item.ImagePath ?? "");

            cmd.ExecuteNonQuery();
        }

        public void Delete(long id)
        {
            using var conn = Db.OpenConnection();
            using var cmd = conn.CreateCommand();

            cmd.CommandText = "DELETE FROM menu_items WHERE id = @id;";
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();
        }
    }
}
