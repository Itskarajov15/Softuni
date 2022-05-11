using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace _05.ChangeTownNamesCasing
{
    internal class Program
    {
        const string connectionString = "Server=.;Integrated Security=true;Database=MinionsDB";

        static void Main(string[] args)
        {
            using var connection = new SqlConnection(connectionString);
            connection.Open();

            string countryName = Console.ReadLine();

            int rowsAffected = SetNamesToUpperCase(countryName, connection);

            if (rowsAffected == 0)
            {
                Console.WriteLine("No town names were affected.");
            }
            else
            {
                Console.WriteLine($"{rowsAffected} town names were affected.");

                PrintTownNames(countryName, connection);
            }
        }

        private static void PrintTownNames(string countryName, SqlConnection connection)
        {
            string query = @" SELECT t.Name 
                                FROM Towns as t
                                JOIN Countries AS c ON c.Id = t.CountryCode
                                WHERE c.Name = @countryName";

            using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@countryName", countryName);

            using var reader = command.ExecuteReader();

            var towns = new List<string>();

            while(reader.Read())
            {
                towns.Add((string)reader[0]);
            }

            Console.WriteLine($"[{String.Join(", ", towns)}]");
        }

        private static int SetNamesToUpperCase(string countryName, SqlConnection connection)
        {
            string updateQuery = @"UPDATE Towns
                                   SET Name = UPPER(Name)
                                   WHERE CountryCode = (SELECT c.Id FROM Countries AS c WHERE c.Name = @countryName)";

            using var updateCommand = new SqlCommand(updateQuery, connection);
            updateCommand.Parameters.AddWithValue("@countryName", countryName);

            return updateCommand.ExecuteNonQuery();
        }
    }
}
