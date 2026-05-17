using Microsoft.Data.Sqlite;
using VSP__559ir_MyProject.Models;

namespace VSP__559ir_MyProject.Data
{
    internal class CourierRepository
    {
        public List<Courier> GetAll(string? search, bool onlyActive)
        {
            using var conn = Db.OpenConnection();
            using var cmd = conn.CreateCommand();

            cmd.CommandText = @"
            SELECT id, name, phone, is_active
            FROM couriers
            WHERE (@search IS NULL OR name LIKE '%' || @search || '%')
              AND (@onlyActive = 0 OR is_active = 1)
            ORDER BY name;
            ";
            cmd.Parameters.AddWithValue("@search", string.IsNullOrWhiteSpace(search) ? (object)DBNull.Value : search!.Trim());
            cmd.Parameters.AddWithValue("@onlyActive", onlyActive ? 1 : 0);

            var result = new List<Courier>();
            using var r = cmd.ExecuteReader();
            while (r.Read())
            {
                result.Add(new Courier
                {
                    Id = r.GetInt32(r.GetOrdinal("id")),
                    Name = r.GetString(r.GetOrdinal("name")),
                    Phone = r.IsDBNull(r.GetOrdinal("phone")) ? "" : r.GetString(r.GetOrdinal("phone")),
                    IsActive = r.GetInt32(r.GetOrdinal("is_active")) == 1
                });
            }

            return result;
        }

        public Courier? GetById(int id)
        {
            using var conn = Db.OpenConnection();
            using var cmd = conn.CreateCommand();

            cmd.CommandText = @"
            SELECT id, name, phone, is_active
            FROM couriers
            WHERE id = @id;
            ";
            cmd.Parameters.AddWithValue("@id", id);

            using var r = cmd.ExecuteReader();
            if (!r.Read()) return null;

            return new Courier
            {
                Id = r.GetInt32(r.GetOrdinal("id")),
                Name = r.GetString(r.GetOrdinal("name")),
                Phone = r.IsDBNull(r.GetOrdinal("phone")) ? "" : r.GetString(r.GetOrdinal("phone")),
                IsActive = r.GetInt32(r.GetOrdinal("is_active")) == 1
            };
        }

        public int Create(Courier c)
        {
            using var conn = Db.OpenConnection();
            using var cmd = conn.CreateCommand();

            cmd.CommandText = @"
            INSERT INTO couriers(name, phone, is_active)
            VALUES (@name, @phone, @active);
            SELECT last_insert_rowid();
            ";
            cmd.Parameters.AddWithValue("@name", c.Name.Trim());
            cmd.Parameters.AddWithValue("@phone", (c.Phone ?? "").Trim());
            cmd.Parameters.AddWithValue("@active", c.IsActive ? 1 : 0);

            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        public void Update(Courier c)
        {
            using var conn = Db.OpenConnection();
            using var cmd = conn.CreateCommand();

            cmd.CommandText = @"
                UPDATE couriers
                SET name = @name,
                    phone = @phone,
                    is_active = @active
                WHERE id = @id;
                ";
            cmd.Parameters.AddWithValue("@id", c.Id);
            cmd.Parameters.AddWithValue("@name", c.Name.Trim());
            cmd.Parameters.AddWithValue("@phone", (c.Phone ?? "").Trim());
            cmd.Parameters.AddWithValue("@active", c.IsActive ? 1 : 0);

            cmd.ExecuteNonQuery();
        }

        // Soft delete
        public void Deactivate(int id)
        {
            using var conn = Db.OpenConnection();
            using var cmd = conn.CreateCommand();

            cmd.CommandText = "UPDATE couriers SET is_active = 0 WHERE id = @id;";
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
        }
    }
}
