using System;
using System.Collections.Generic;
using System.Linq;

namespace ForceBook
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> teams = new Dictionary<string, List<string>>();

            while (true)
            {
                string input = Console.ReadLine();

                string splitString = input.Contains("|") ? " | " : " -> ";

                string[] inputElements = input.Split(splitString);

                if (input == "Lumpawaroo")
                {
                    break;
                }

                if (input.Contains("|"))
                {
                    string sideName = inputElements[0];
                    string user = inputElements[1];

                    if (!teams.ContainsKey(sideName))
                    {
                        teams.Add(sideName, new List<string>());
                    }

                    //bool doesExist = false;

                    //foreach (var team in teams)
                    //{
                    //    if (team.Value.Contains(user))
                    //    {
                    //        doesExist = true;
                    //        break;
                    //    }
                    //}

                    //if (!teams[sideName].Contains(user) && !doesExist)
                    //{
                    //    teams[sideName].Add(user);
                    //}

                    if (!teams[sideName].Contains(user) && !teams.Values.Any(x => x.Contains(user)))
                    {
                        teams[sideName].Add(user);
                    }
                }
                else if (input.Contains("->"))
                {
                    string user = inputElements[0];
                    string sideName = inputElements[1];

                    foreach (var team in teams)
                    {
                        foreach (var currentUser in team.Value)
                        {
                            if (currentUser == user)
                            {
                                team.Value.Remove(user);
                                break;
                            }
                        }
                    }

                    if (!teams.ContainsKey(sideName))
                    {
                        teams.Add(sideName, new List<string>());
                    }

                    teams[sideName].Add(user);

                    Console.WriteLine($"{user} joins the {sideName} side!");
                }
            }

            foreach (var team in teams.Where(x => x.Value.Count > 0)
                .OrderByDescending(x => x.Value.Count)
                .ThenBy(x => x.Key))
            {
                Console.WriteLine($"Side: {team.Key}, Members: {team.Value.Count}");

                foreach (var user in team.Value.OrderBy(x => x))
                {
                    Console.WriteLine($"! {user}");
                }
            }
        }
    }
}
