using System;
using System.Data.SqlClient;

namespace _01.InitialSetup
{
    internal class Program
    {
        const string connectionString = "Server=.;Integrated Security=true;Database=MinionsDB";

        static void Main(string[] args)
        {
            using var connection = new SqlConnection(connectionString);
            connection.Open();

            //string createDatabase = "CREATE DATABASE MinionsDB";

            var createTableStatements = GetCreateTableStatements();

            foreach (var command in createTableStatements)
            {
                ExecuteNonQuery(command, connection);
            }

            var insertDataStatements = GetInsertDataStatements();

            foreach (var command in insertDataStatements)
            {
                ExecuteNonQuery(command, connection);
            }
        }

        private static void ExecuteNonQuery(string query, SqlConnection connection)
        {
            using var command = new SqlCommand(query, connection);
            command.ExecuteNonQuery();
        }

        private static string[] GetCreateTableStatements()
        {
            var result = new string[]
            {
                "CREATE TABLE Countries(Id INT PRIMARY KEY, [Name] VARCHAR(50) NOT NULL)",
                @"CREATE TABLE Towns(Id INT PRIMARY KEY, [Name] VARCHAR(50) NOT NULL, CountryCode INT NOT NULL,
                    FOREIGN KEY (CountryCode) REFERENCES Countries(Id))",
                @"CREATE TABLE Minions(Id INT PRIMARY KEY,[Name] VARCHAR(50) NOT NULL,Age INT NOT NULL,TownId INT,
                    FOREIGN KEY (TownId) REFERENCES Towns(Id))",
                "CREATE TABLE EvilnessFactors(Id INT PRIMARY KEY,[Name] VARCHAR(50) NOT NULL)",
                @"CREATE TABLE Villains(Id INT PRIMARY KEY,[Name] VARCHAR(50),EvilnessFactorId INT,
                    FOREIGN KEY (EvilnessFactorId) REFERENCES EvilnessFactors(Id))",
                @"CREATE TABLE MinionsVillains(MinionId INT NOT NULL,VillainId INT NOT NULL,
                    CONSTRAINT PK_MinionId_VillainId PRIMARY KEY (MinionId, VillainId),
                    FOREIGN KEY (MinionId) REFERENCES Minions(Id),
                    FOREIGN KEY (VillainId) REFERENCES Villains(Id))"
            };

            return result;
        }

        private static string[] GetInsertDataStatements()
        {
            var result = new string[]
            {
                "INSERT INTO Countries VALUES (1, 'Bulgaria'), (2, 'Norway'), (3, 'Cyrpus'), (4, 'Greece'), (5, 'UK')",
                "INSERT INTO Towns VALUES (1, 'Plovdiv', 1), (2, 'Oslo', 2), (3, 'Larnaca', 3), (4, 'Athens', 4), (5, 'London', 5)",
                @"INSERT INTO Minions VALUES (1, 'Stoyan', 12, 1), (2, 'George', 22, 2), (3, 'Ivan', 25, 3), (4, 'Kiro', 21, 4),
                    (5, 'Niki', 25, 5)",
                "INSERT INTO EvilnessFactors VALUES (1, 'super good'), (2, 'good'), (3, 'bad'), (4, 'evil'), (5, 'super evil')",
                "INSERT INTO Villains VALUES (1, 'Gru', 1), (2, 'Ivo', 2), (3, 'Teo', 3), (4, 'Sto', 4), (5, 'Pro', 5)",
                "INSERT INTO MinionsVillains VALUES (1, 1), (2, 2), (3, 3), (4, 4), (5, 5)"
            };

            return result;
        }
    }
}
