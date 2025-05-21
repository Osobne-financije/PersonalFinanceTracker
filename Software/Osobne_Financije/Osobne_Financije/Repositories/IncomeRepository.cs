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

        public decimal GetTotalIncomeByStudentId(int studentId)
        {
            DB.OpenConnection();
            string query = $"SELECT SUM(Amount) FROM Incomes WHERE StudentId = {studentId}";
            object result = DB.GetScalar(query);
            DB.CloseConnection();

            if (result == DBNull.Value)
                return 0;
            else
                return Convert.ToDecimal(result);
        }

        public List<DailyAmount> GetIncomesForCurrentMonth(int studentId)
        {
            List<DailyAmount> result = new List<DailyAmount>();
            DB.OpenConnection();
            string query = $@"SELECT DAY(Date) AS Dan, SUM(Amount) AS Ukupno FROM Incomes WHERE StudentId = {studentId} AND MONTH(Date) = MONTH(GETDATE()) AND YEAR(Date) = YEAR(GETDATE()) GROUP BY DAY(Date) ORDER BY Dan";
            var reader = DB.GetDataReader(query);

            while (reader.Read())
            {
                result.Add(new DailyAmount
                {
                    Day = (int)reader["Dan"],
                    Amount = (decimal)reader["Ukupno"]
                });
            }

            DB.CloseConnection();
            return result;
        }

        public List<Income> GetIncomesByDateRange(int studentId, DateTime from, DateTime to)
        {
            List<Income> incomes = new List<Income>();
            DB.OpenConnection();

            string query = $@"SELECT i.IncomeId, i.StudentId, i.CategoryId, i.Amount, i.Date, i.Description, c.Name AS CategoryName FROM Incomes i INNER JOIN Categories c ON i.CategoryId = c.CategoryId WHERE i.StudentId = {studentId} AND i.Date BETWEEN '{from:yyyy-MM-dd}' AND '{to:yyyy-MM-dd}'";

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


    }
}
