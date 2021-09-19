using System;
using System.Collections.Generic;
using System.Linq;

namespace Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contests = new Dictionary<string, string>();

            SortedDictionary<string, Dictionary<string, int>> candidates = new SortedDictionary<string, Dictionary<string, int>>();

            string[] input = Console.ReadLine()
                .Split(":", StringSplitOptions.RemoveEmptyEntries);

            while (input[0] != "end of contests")
            {
                string nameOfContest = input[0];
                string password = input[1];

                if (!contests.ContainsKey(nameOfContest))
                {
                    contests.Add(nameOfContest, password);
                }

                input = Console.ReadLine()
                .Split(":", StringSplitOptions.RemoveEmptyEntries);
            }

            string[] submissions = Console.ReadLine()
                .Split("=>", StringSplitOptions.RemoveEmptyEntries);

            while (submissions[0] != "end of submissions")
            {
                string contest = submissions[0];
                string password = submissions[1];
                string username = submissions[2];
                int points = int.Parse(submissions[3]);

                if (!contests.ContainsKey(contest) || password != contests[contest])
                {
                    submissions = Console.ReadLine()
                    .Split("=>", StringSplitOptions.RemoveEmptyEntries);
                    continue;
                }

                if (!candidates.ContainsKey(username))
                {
                    candidates.Add(username, new Dictionary<string, int>());
                }

                if (!candidates[username].ContainsKey(contest))
                {
                    candidates[username].Add(contest, points);
                }
                else
                {
                    if (candidates[username][contest] < points)
                    {
                        candidates[username][contest] = points;
                    }
                }


                submissions = Console.ReadLine()
                .Split("=>", StringSplitOptions.RemoveEmptyEntries);
            }

            KeyValuePair<string, Dictionary<string, int>> bestCandidate =
                candidates.OrderByDescending(x => x.Value.Values.Sum()).First();

            Console.WriteLine($"Best candidate is {bestCandidate.Key} with total {bestCandidate.Value.Values.Sum()} points.");
            Console.WriteLine("Ranking:");

            foreach (var candidate in candidates)
            {
                Console.WriteLine(candidate.Key);

                foreach (var contest in candidate.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {contest.Key} -> {contest.Value}");
                }
            }
        }
    }
}
