using Osobne_Financije.Models;
using Osobne_Financije.Helpers;
using System.Data.SqlClient;
using DBLayer;

namespace Osobne_Financije.Repositories
{
    class StudentRepository
    {

        public bool Signup(Student student)
        {
            DB.OpenConnection();

            string hashed = HashHelper.HashPassword(student.Password);

            string query = $"INSERT INTO Students (FirstName, LastName, UserName, Password) " + $"VALUES ('{student.Firstname}', '{student.Lastname}', '{student.Username}', '{hashed}')";

            int result = DB.ExecuteCommand(query);

            DB.CloseConnection();

            return result > 0;
        }

        public Student Login(string username, string password)
        {
            DB.OpenConnection();

            string hashed = HashHelper.HashPassword(password);

            string query = $"SELECT * FROM Students WHERE UserName = '{username}' AND Password = '{hashed}'";

            SqlDataReader reader = DB.GetDataReader(query);

            Student student = null;

            if (reader.Read())
            {
                student = new Student
                {
                    Id = (int)reader["Id"],
                    Firstname = reader["FirstName"].ToString(),
                    Lastname = reader["LastName"].ToString(),
                    Username = reader["UserName"].ToString(),
                    Password = reader["Password"].ToString()
                };
            }

            DB.CloseConnection();
            return student;
        }
        public bool UsernameExists(string username)
        {
            DB.OpenConnection();

            string query = $"SELECT COUNT(*) FROM Students WHERE UserName = '{username}'";
            int count = (int)DB.GetScalar(query);

            DB.CloseConnection();
            return count > 0;
        }

    }
}
