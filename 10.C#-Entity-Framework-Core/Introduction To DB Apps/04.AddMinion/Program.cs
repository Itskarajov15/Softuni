using System;
using System.Data.SqlClient;

namespace _04.AddMinion
{
    internal class Program
    {
        const string connectionString = "Server=.;Integrated Security=true;Database=MinionsDB";

        static void Main(string[] args)
        {
            using var connection = new SqlConnection(connectionString);
            connection.Open();

            string[] minionInformation = Console.ReadLine().Split(' ');
            string name = minionInformation[1];
            int age = int.Parse(minionInformation[2]);
            string town = minionInformation[3];
            string villainName = Console.ReadLine().Split(" ")[1];

            var townId = GetTownId(town, connection);

            if (townId == null)
            {
                InsertTownIntoDatabase(town, connection);
            }

            var villainId = GetVillainId(villainName, connection);

            if (villainId == null)
            {
                InsertVillainIntoDatabase(villainName, connection);
            }

            InsertMinionIntoDatabase(name, age, town, connection);
            InsertMinionToVillain(GetVillainId(villainName, connection), GetMinionId(name, connection), villainName, name, connection);
        }

        private static void InsertMinionToVillain(object villainId, object minionId, string villainName, string minioneName, SqlConnection connection)
        {
            string insertMinionToVillainQuery = "INSERT INTO MinionsVillains (MinionId, VillainId) VALUES (@villainId, @minionId)";
            using var insertMinionToVillainCommand = new SqlCommand(insertMinionToVillainQuery, connection);
            insertMinionToVillainCommand.Parameters.AddWithValue("@villainId", villainId);
            insertMinionToVillainCommand.Parameters.AddWithValue("@minionId", minionId);

            Console.WriteLine($"Successfully added {minioneName} to be minion of {villainName}.");
        }

        private static object GetMinionId(string minionName, SqlConnection connection)
        {
            string minionIdQuery = "SELECT Id FROM Minions WHERE Name = @Name";

            using var MinionIdCommand = new SqlCommand(minionIdQuery, connection);
            MinionIdCommand.Parameters.AddWithValue("@Name", minionName);

            return MinionIdCommand.ExecuteScalar();
        }

        private static void InsertMinionIntoDatabase(string name, int age, string town, SqlConnection connection)
        {
            string insertMinionQuery = "INSERT INTO Minions (Name, Age, TownId) VALUES (@name, @age, @townId)";

            using var insertMinionCommand = new SqlCommand(insertMinionQuery, connection);
            insertMinionCommand.Parameters.AddWithValue("@name", name);
            insertMinionCommand.Parameters.AddWithValue("@age", age);
            insertMinionCommand.Parameters.AddWithValue("@townId", town);
            insertMinionCommand.ExecuteNonQuery();
        }

        private static void InsertVillainIntoDatabase(string villainName, SqlConnection connection)
        {
            string insertVillainQuery = "INSERT INTO Villains (Name, EvilnessFactorId)  VALUES (@villainName, 4)";

            using var insertVillainCommand = new SqlCommand(insertVillainQuery, connection);
            insertVillainCommand.Parameters.AddWithValue("@villainName", villainName);
            insertVillainCommand.ExecuteNonQuery();

            Console.WriteLine($"Villain {villainName} was added to the database.");
        }

        private static object GetVillainId(string villainName, SqlConnection connection)
        {
            string villainIdQuery = "SELECT Id FROM Villains WHERE Name = @Name";

            using var villainIdCommand = new SqlCommand(villainIdQuery, connection);
            villainIdCommand.Parameters.AddWithValue("@Name", villainName);

            return villainIdCommand.ExecuteScalar();
        }

        private static object GetTownId(string town, SqlConnection connection)
        {
            string townIdQuery = "SELECT Id FROM Towns WHERE Name = @townName";

            using var townIdCommand = new SqlCommand(townIdQuery, connection);
            townIdCommand.Parameters.AddWithValue("@townName", town);

            return townIdCommand.ExecuteScalar();
        }

        private static void InsertTownIntoDatabase(string town, SqlConnection connection)
        {
            string insertTownQuery = "INSERT INTO Towns (Name) VALUES (@townName)";

            using var insertTownCommand = new SqlCommand(insertTownQuery, connection);
            insertTownCommand.Parameters.AddWithValue("@townName", town);
            insertTownCommand.ExecuteNonQuery();

            Console.WriteLine($"Town {town} was added to the database.");
        }
    }
}
