using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using DBLayer;
using Osobne_Financije.Models;

namespace Osobne_Financije.Repositories
{
    class ExpenseRepository
    {
        public bool AddExpense(Expense expense)
        {
            DB.OpenConnection();
            string query = $"INSERT INTO Expenses (StudentId, CategoryId, Amount, Date, Description) VALUES ({expense.StudentId}, {expense.CategoryId}, {expense.Amount.ToString(System.Globalization.CultureInfo.InvariantCulture)}, '{expense.Date:yyyy-MM-dd}', '{expense.Description}')";

            int affectedRows = DB.ExecuteCommand(query);
            DB.CloseConnection();

            return affectedRows > 0;
        }

        public List<Expense> GetExpenseByStudentId(int studentId)
        {
            List<Expense> expenses = new List<Expense>();
            DB.OpenConnection();
            string query = $@"SELECT i.ExpenseId, i.StudentId, i.CategoryId, i.Amount, i.Date, i.Description, c.Name AS CategoryName FROM Expenses i INNER JOIN Categories c ON i.CategoryId = c.CategoryId WHERE i.StudentId = {studentId}";
            SqlDataReader reader = DB.GetDataReader(query);

            while (reader.Read())
            {
                Expense expense = new Expense
                {
                    Id = (int)reader["ExpenseId"],
                    StudentId = (int)reader["StudentId"],
                    CategoryId = (int)reader["CategoryId"],
                    Amount = (decimal)reader["Amount"],
                    Date = (DateTime)reader["Date"],
                    Description = reader["Description"].ToString(),
                    CategoryName = reader["CategoryName"].ToString()
                };
                expenses.Add(expense);
            }
            DB.CloseConnection();
            return expenses;
        }
        public bool DeleteExpense(int expenseId)
        {
            DB.OpenConnection();
            string query = $"DELETE FROM Expenses WHERE ExpenseId = {expenseId}";
            int result = DB.ExecuteCommand(query);
            DB.CloseConnection();
            return result > 0;
        }

        public decimal GetTotalExpenseByStudentId(int studentId)
        {
            DB.OpenConnection();
            string query = $"SELECT SUM(Amount) FROM Expenses WHERE StudentId = {studentId}";
            object result = DB.GetScalar(query);
            DB.CloseConnection();

            if (result == DBNull.Value)
                return 0;
            else
                return Convert.ToDecimal(result);
        }
        public List<DailyAmount> GetExpensesForCurrentMonth(int studentId)
        {
            List<DailyAmount> result = new List<DailyAmount>();
            DB.OpenConnection();
            string query = $@"SELECT DAY(Date) AS Dan, SUM(Amount) AS Ukupno FROM Expenses WHERE StudentId = {studentId} AND MONTH(Date) = MONTH(GETDATE()) AND YEAR(Date) = YEAR(GETDATE()) GROUP BY DAY(Date) ORDER BY Dan";
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
        public List<Expense> GetExpensesByDateRange(int studentId, DateTime from, DateTime to)
        {
            List<Expense> expenses = new List<Expense>();
            DB.OpenConnection();

            string query = $@"SELECT i.ExpenseId, i.StudentId, i.CategoryId, i.Amount, i.Date, i.Description, c.Name AS CategoryName FROM Expenses i INNER JOIN Categories c ON i.CategoryId = c.CategoryId WHERE i.StudentId = {studentId} AND i.Date BETWEEN '{from:yyyy-MM-dd}' AND '{to:yyyy-MM-dd}'";

            SqlDataReader reader = DB.GetDataReader(query);

            while (reader.Read())
            {
                Expense expense = new Expense
                {
                    Id = (int)reader["ExpenseId"],
                    StudentId = (int)reader["StudentId"],
                    CategoryId = (int)reader["CategoryId"],
                    Amount = (decimal)reader["Amount"],
                    Date = (DateTime)reader["Date"],
                    Description = reader["Description"].ToString(),
                    CategoryName = reader["CategoryName"].ToString()
                };
                expenses.Add(expense);
            }

            DB.CloseConnection();
            return expenses;
        }

    }
}
