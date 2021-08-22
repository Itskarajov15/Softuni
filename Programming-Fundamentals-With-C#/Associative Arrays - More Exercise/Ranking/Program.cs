using System;
using System.Collections.Generic;
using System.Linq;

namespace Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> passwordsByContest = new Dictionary<string, string>();

            Dictionary<string, int> pointsByName = new Dictionary<string, int>();

            Dictionary<string, List<string>> namesByContest = new Dictionary<string, List<string>>();

            passwordsByContest = AddingContestsInTheDictionary(passwordsByContest);

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "end of submissions")
                {
                    break;
                }

                string[] parts = line
                    .Split("=>", StringSplitOptions.RemoveEmptyEntries);

                string contest = parts[0];
                string password = parts[1];
                string name = parts[2];
                int points = int.Parse(parts[3]);

                if (passwordsByContest.ContainsKey(contest) && passwordsByContest.ContainsValue(password))
                {
                    if (!namesByContest.ContainsKey(contest))
                    {
                        namesByContest.Add(contest, new List<string>());
                    }

                    if (!pointsByName.ContainsKey(name))
                    {
                        pointsByName.Add(name, points);
                    }
                    else
                    {
                        if (pointsByName.Any(x => x.Value < points))
                        {
                            pointsByName[name] = points;
                        }
                    }
                }
                else
                {
                    continue;
                }

                namesByContest[contest].Add(name);
            }
        }

        static Dictionary<string, string> AddingContestsInTheDictionary(Dictionary<string, string> passwordsByContest)
        {
            while (true)
            {
                string line = Console.ReadLine();

                if (line == "end of contests")
                {
                    break;
                }

                string[] parts = line
                    .Split(":", StringSplitOptions.RemoveEmptyEntries);

                string contest = parts[0];
                string password = parts[1];

                if (!passwordsByContest.ContainsKey(contest))
                {
                    passwordsByContest.Add(contest, password);
                }
            }

            return passwordsByContest;
        }
    }
}
