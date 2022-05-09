using System;
using System.Data.SqlClient;

namespace _03.MinionNames
{
    internal class Program
    {
        const string connectionString = "Server=.;Integrated Security=true;Database=MinionsDB";

        static void Main(string[] args)
        {
            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            Console.Write("Enter villain id: ");
            int villainId = int.Parse(Console.ReadLine());

            var villain = GetVillainById(villainId, connection);
            

            if (String.IsNullOrEmpty(villain))
            {
                Console.WriteLine($"No villain with ID {villainId} exists in the database");
            }
            else
            {
                Console.WriteLine($"Villain: {villain}");

                GetMinions(villainId, connection);
            }
        }

        private static void GetMinions(int villainId, SqlConnection connection)
        {
            string getMinionsQuery = @"SELECT ROW_NUMBER() OVER (ORDER BY m.Name) as RowNum,
                                                 m.Name, 
                                                 m.Age
                                               FROM MinionsVillains AS mv
                                               JOIN Minions As m ON mv.MinionId = m.Id
                                               WHERE mv.VillainId = @Id
                                               ORDER BY m.Name";

            using SqlCommand getMinionsCommand = new SqlCommand(getMinionsQuery, connection);
            getMinionsCommand.Parameters.Add(new SqlParameter("@Id", villainId));

            using SqlDataReader reader = getMinionsCommand.ExecuteReader();

            if (!reader.HasRows)
            {
                Console.WriteLine("(no minions)");
            }
            else
            {
                while (reader.Read())
                {
                    Console.WriteLine($"{reader["RowNum"]}. {reader["Name"]} - {reader["Age"]}");
                }
            }
        }

        private static string GetVillainById(int villainId, SqlConnection connection)
        {
            string getVillainQuery = "SELECT Name FROM Villains WHERE Id = @Id";

            using var getVillainCommand = new SqlCommand(getVillainQuery, connection);
            getVillainCommand.Parameters.AddWithValue("@Id", villainId);

            return (string)getVillainCommand.ExecuteScalar();
        }
    }
}
