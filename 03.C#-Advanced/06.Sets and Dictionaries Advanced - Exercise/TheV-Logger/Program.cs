using System;
using System.Collections.Generic;
using System.Linq;

namespace TheV_Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, SortedSet<string>>> app = new Dictionary<string, Dictionary<string, SortedSet<string>>>();

            string[] command = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            while (command[0] != "Statistics")
            {
                string vlogger = command[0];

                if (command[1] == "joined")
                {
                    if (!app.ContainsKey(vlogger))
                    {
                        app.Add(vlogger, new Dictionary<string, SortedSet<string>>());

                        app[vlogger].Add("following", new SortedSet<string>());
                        app[vlogger].Add("followers", new SortedSet<string>());
                    }
                }
                else if (command[1] == "followed")
                {
                    string firstVlogger = command[0];
                    string secondVlogger = command[2];

                    if ((app.ContainsKey(firstVlogger) && app.ContainsKey(secondVlogger))
                        && (firstVlogger != secondVlogger)
                        && !app[firstVlogger]["following"].Contains(secondVlogger))
                    {
                        app[firstVlogger]["following"].Add(secondVlogger);
                        app[secondVlogger]["followers"].Add(firstVlogger);
                    }
                    else
                    {
                        command = Console.ReadLine()
                        .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                        continue;
                    }
                }

                command = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }

            app = app
                .OrderByDescending(x => x.Value["followers"].Count)
                .ThenBy(x => x.Value["following"].Count)
                .ToDictionary(x => x.Key, x => x.Value);

            Console.WriteLine($"The V-Logger has a total of {app.Count} vloggers in its logs.");

            int counter = 1;

            foreach (var vlogger in app)
            {
                Console.WriteLine($"{counter}. {vlogger.Key} : {vlogger.Value["followers"].Count} followers, {vlogger.Value["following"].Count} following");

                if (counter == 1 && vlogger.Value["followers"].Count > 0)
                {
                    foreach (var follower in vlogger.Value["followers"])
                    {
                        Console.WriteLine($"*  {follower}");
                    }
                }

                counter++;
            }
        }
    }
}
