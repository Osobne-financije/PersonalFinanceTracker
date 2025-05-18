using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using DBLayer;
using Osobne_Financije.Models;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osobne_Financije.Repositories
{
    class IncomeRepository
    {
        public bool AddIncome(Income income)
        {
            DB.OpenConnection();

            string query = $"INSERT INTO Incomes (StudentId, CategoryId, Amount, Date, Description) VALUES ({income.StudentId}, {income.CategoryId}, {income.Amount.ToString(System.Globalization.CultureInfo.InvariantCulture)}, '{income.Date:yyyy-MM-dd}', '{income.Description}')";
            
            int affectedRows = DB.ExecuteCommand(query);
            DB.CloseConnection();

            return affectedRows > 0;
        }

        public List<Income> GetIncomesByStudentId(int studentId)
        {
            List<Income> incomes = new List<Income>();
            DB.OpenConnection();
            string query = $@"SELECT i.IncomeId, i.StudentId, i.CategoryId, i.Amount, i.Date, i.Description, c.Name AS CategoryName FROM Incomes i INNER JOIN Categories c ON i.CategoryId = c.CategoryId WHERE i.StudentId = {studentId}";
            SqlDataReader reader = DB.GetDataReader(query);

            while (reader.Read())
            {
                Income income = new Income
                {
                    Id = (int)reader["IncomeId"],
                    StudentId = (int)reader["StudentId"],
                    CategoryId = (int)reader["CategoryId"],
                    Amount = (decimal)reader["Amount"],
                    Date = (DateTime)reader["Date"],
                    Description = reader["Description"].ToString(),
                    CategoryName = reader["CategoryName"].ToString()
                };
                incomes.Add(income);
            }
            DB.CloseConnection();
            return incomes;
        }

        public bool DeleteIncome(int incomeId)
        {
            DB.OpenConnection();
            string query = $"DELETE FROM Incomes WHERE IncomeId = {incomeId}";
            int result = DB.ExecuteCommand(query);
            DB.CloseConnection();
            return result > 0;
        }

    }
}
