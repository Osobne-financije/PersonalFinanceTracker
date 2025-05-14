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

            string query = $"INSERT INTO Income (StudentId, CategoryId, Amount, Date, Description) VALUES ({income.StudentId}, {income.CategoryId}, {income.Amount.ToString(System.Globalization.CultureInfo.InvariantCulture)}, '{income.Date:yyyy-MM-dd}', '{income.Description}')";
            
            int affectedRows = DB.ExecuteCommand(query);
            DB.CloseConnection();

            return affectedRows > 0;
        }

    }
}
