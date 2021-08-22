using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftUniExamResults
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<int>> pointsByName = new Dictionary<string, List<int>>();

            Dictionary<string, List<string>> namesByLanguages = new Dictionary<string, List<string>>();

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "exam finished")
                {
                    break;
                }

                string[] parts = line
                    .Split('-', StringSplitOptions.RemoveEmptyEntries);

                string name = parts[0];
                string language = parts[1];

                if (parts[1] == "banned")
                {
                    pointsByName.Remove(name);
                    continue;
                }

                int points = int.Parse(parts[2]);

                if (!namesByLanguages.ContainsKey(language))
                {
                    namesByLanguages.Add(language, new List<string>());
                }

                if (!pointsByName.ContainsKey(name))
                {
                    pointsByName.Add(name, new List<int>());
                }

                namesByLanguages[language].Add(name);
                pointsByName[name].Add(points);
            }

            Dictionary<string, int> sortedPoints = new Dictionary<string, int>();

            foreach (var participant in pointsByName)
            {
                int currentMaxPoints = participant.Value.Max();

                sortedPoints.Add(participant.Key, currentMaxPoints);
            }

            sortedPoints = sortedPoints
                .OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            Console.WriteLine("Results:");

            foreach (var participant in sortedPoints)
            {
                Console.WriteLine($"{participant.Key} | {participant.Value}");
            }

            Console.WriteLine("Submissions:");

            namesByLanguages = namesByLanguages
                .OrderByDescending(x => x.Value.Count)
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var language in namesByLanguages)
            {
                Console.WriteLine($"{language.Key} - {language.Value.Count}");
            }
        }
    }
}
