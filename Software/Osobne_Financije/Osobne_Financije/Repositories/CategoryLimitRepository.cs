using DBLayer;
using Osobne_Financije.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osobne_Financije.Repositories
{
    class CategoryLimitRepository
    {
        public bool AddLimit(CategoryLimit limit)
        {
            DB.OpenConnection();

            string query = $"INSERT INTO CategoryLimits (StudentId, CategoryId, LimitAmount) " + $"VALUES ({limit.StudentId}, {limit.CategoryId}, {limit.LimitAmount.ToString(System.Globalization.CultureInfo.InvariantCulture)})";
            int result = DB.ExecuteCommand(query);
            DB.CloseConnection();

            return result > 0;
        }
        public List<CategoryLimit> GetLimitsByStudentId(int studentId)
        {
            List<CategoryLimit> limits = new List<CategoryLimit>();

            DB.OpenConnection();
            string query = $@"SELECT l.LimitId, l.StudentId, l.CategoryId, l.LimitAmount, c.Name AS CategoryName FROM CategoryLimits l INNER JOIN Categories c ON l.CategoryId = c.CategoryId WHERE l.StudentId = {studentId}";
            SqlDataReader reader = DB.GetDataReader(query);

            while (reader.Read())
            {
                limits.Add(new CategoryLimit
                {
                    LimitId = (int)reader["LimitId"],
                    StudentId = (int)reader["StudentId"],
                    CategoryId = (int)reader["CategoryId"],
                    LimitAmount = (decimal)reader["LimitAmount"],
                    CategoryName = reader["CategoryName"].ToString()
                });
            }

            DB.CloseConnection();
            return limits;
        }
    }
}
