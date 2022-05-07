using System;
using System.Data.SqlClient;

namespace _02.VillainNames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string connectionString = "Server=.;Integrated Security=true;Database=MinionsDB";

            using SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();

            GetVillainNames(connection);
        }

        private static void GetVillainNames(SqlConnection connection)
        {
            string query = @"SELECT v.Name, COUNT(mv.VillainId) AS MinionsCount  
                                FROM Villains AS v
                                JOIN MinionsVillains AS mv ON v.Id = mv.VillainId
                                GROUP BY v.Id, v.Name
                                HAVING COUNT(mv.VillainId) > 3
                                ORDER BY COUNT(mv.VillainId)";

            using var command = new SqlCommand(query, connection);

            using SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine($"{reader["Name"]} - {reader["MinionsCount"]}");
            }
        }
    }
}
