using System.Collections.Generic;
using DBLayer;
using System.Data.SqlClient;
using Osobne_Financije.Models;

namespace Osobne_Financije.Repositories
{
    class CategoryRepository
    {
        public List<Category> GetCategoriesByType(string type)
        {
            List<Category> categories = new List<Category>();

            DB.OpenConnection();
            string query = "SELECT * FROM Categories WHERE Type = '{type}'";
            SqlDataReader reader = DB.GetDataReader(query);

            while (reader.Read())
            {
                Category category = new Category
                {
                    Id = (int)reader["id"],
                    Name = reader["Name"].ToString(),
                    Type = reader["Type"].ToString(),
                };
                categories.Add(category);
            }
            DB.CloseConnection();
            return categories;
        }

        public bool AddCategory(string name, string type)
        {
            DB.OpenConnection();
            string query = $"INSERT INTO Categories (Name, Type) VALUES ('{name}', '{type}')";
            int affectedRows = DB.ExecuteCommand(query);
            DB.CloseConnection();
            return affectedRows > 0;
        }
    }
}
