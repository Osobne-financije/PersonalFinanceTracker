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
    class SavingsGoalRepository
    {
        public bool AddGoal(SavingsGoal goal)
        {
            DB.OpenConnection();
            string query = $"INSERT INTO SavingsGoals (StudentId, TargetAmount, CreatedDate) " + $"VALUES ({goal.StudentId}, {goal.TargetAmount.ToString(System.Globalization.CultureInfo.InvariantCulture)}, '{goal.CreatedDate:yyyy-MM-dd}')";
            int result = DB.ExecuteCommand(query);
            DB.CloseConnection();

            return result > 0;
        }
        public SavingsGoal GetGoalByStudentId(int studentId)
        {
            DB.OpenConnection();
            string query = $"SELECT * FROM SavingsGoals WHERE StudentId = {studentId} ORDER BY CreatedDate DESC";
            SqlDataReader reader = DB.GetDataReader(query);

            SavingsGoal goal = null;
            if (reader.Read())
            {
                goal = new SavingsGoal
                {
                    GoalId = (int)reader["GoalId"],
                    StudentId = (int)reader["StudentId"],
                    TargetAmount = (decimal)reader["TargetAmount"],
                    CreatedDate = (DateTime)reader["CreatedDate"]
                };
            }
            DB.CloseConnection();
            return goal;
        }
    }
}
