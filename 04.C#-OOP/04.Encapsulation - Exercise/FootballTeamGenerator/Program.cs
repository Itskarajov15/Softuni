using System;
using System.Collections.Generic;

namespace FootballTeamGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            var teams = new Dictionary<string, Team>();

            while (true)
            {
                var line = Console.ReadLine();

                if (line == "END")
                {
                    break;
                }

                var parts = line.Split(";", StringSplitOptions.RemoveEmptyEntries);

                try
                {
                    if (parts[0] == "Team")
                    {
                        if (!teams.ContainsKey(parts[1]))
                        {
                            teams.Add(parts[1], new Team(parts[1]));
                        }
                    }
                    else if (parts[0] == "Add")
                    {
                        if (!teams.ContainsKey(parts[1]))
                        {
                            throw new InvalidOperationException($"Team {parts[1]} does not exist.");
                        }
                        else
                        {
                            var name = parts[2];
                            var endurance = int.Parse(parts[3]);
                            var sprint = int.Parse(parts[4]);
                            var dribble = int.Parse(parts[5]);
                            var passing = int.Parse(parts[6]);
                            var shooting = int.Parse(parts[7]);

                            var player = new Player(name, endurance, sprint, dribble, passing, shooting);

                            teams[parts[1]].AddPlayer(player);
                        }
                    }
                    else if (parts[0] == "Remove")
                    {
                        if (teams.ContainsKey(parts[1]))
                        {
                            teams[parts[1]].RemovePlayer(parts[2]);
                        }
                        else
                        {
                            throw new InvalidOperationException($"Team {parts[1]} does not exist.");
                        }
                    }
                    else if (parts[0] == "Rating")
                    {
                        if (!teams.ContainsKey(parts[1]))
                        {
                            throw new InvalidOperationException($"Team {parts[1]} does not exist.");
                        }
                        else
                        {
                            Console.WriteLine(teams[parts[1]].GetRating());
                        }
                    }
                }
                catch (Exception ex)
                    when (ex is InvalidOperationException || ex is ArgumentException)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
