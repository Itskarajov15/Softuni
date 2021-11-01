using System;
using System.Collections.Generic;

namespace PersonsInfo
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var persons = new List<Person>();

            var lines = int.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                var cmdArg = Console.ReadLine()
                    .Split();

                var person = new Person(cmdArg[0], cmdArg[1], int.Parse(cmdArg[2]), decimal.Parse(cmdArg[3]));

                persons.Add(person);
            }

            var team = new Team("Softuni");

            foreach (var person in persons)
            {
                team.AddPlayer(person);
            }

            Console.WriteLine($"First team has {team.FirstTeam.Count} players.");
            Console.WriteLine($"Reserve team has {team.ReserveTeam.Count} players.");
        }
    }
}