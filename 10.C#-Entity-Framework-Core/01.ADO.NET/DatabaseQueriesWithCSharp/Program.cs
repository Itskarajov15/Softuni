using System;
using System.Data.SqlClient;

namespace DatabaseQueriesWithCSharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Increase the salary of the employees with even id
            using (var connection = new SqlConnection(
                "Server=.;Integrated Security=true;Database=SoftUni"))
            {
                connection.Open();

                string query = "UPDATE EMPLOYEES SET Salary = Salary + 10 WHERE EmployeeId % 2 = 0";
                SqlCommand sqlCommand = new SqlCommand(query, connection);

                int rowsAffected = sqlCommand.ExecuteNonQuery();
                Console.WriteLine(rowsAffected);
            
            }

            //Returns the highest salary
            using (var connection = new SqlConnection(
                "Server=.;Integrated Security=true;Database=SoftUni"))
            {
                connection.Open();

                string query = "SELECT MAX(Salary) FROM Employees";
                SqlCommand sqlCommand = new SqlCommand(query, connection);

                decimal highestSalary = (decimal)sqlCommand.ExecuteScalar();
                Console.WriteLine(highestSalary);
            }

            //Returns the full name of the employee with the highest salary
            using (var connection = new SqlConnection(
                "Server=.;Integrated Security=true;Database=SoftUni"))
            {
                connection.Open();

                string query = "SELECT TOP(1) * FROM Employees ORDER BY Salary DESC";
                SqlCommand sqlCommand = new SqlCommand(query, connection);

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                
                while(sqlDataReader.Read())
                {
                    Console.WriteLine(sqlDataReader[1] + " " + sqlDataReader[2]);
                }
            }
        }
    }
}
