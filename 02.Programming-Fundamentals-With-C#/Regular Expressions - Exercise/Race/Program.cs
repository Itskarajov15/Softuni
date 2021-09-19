using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Race
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> participants = new Dictionary<string, int>();

            Regex nameRegex = new Regex(@"[A-Za-z]");
            Regex distanceRegex = new Regex(@"[0-9]");

            List<string> names = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            foreach (var name in names)
            {
                participants.Add(name, 0);
            }

            string input = Console.ReadLine();

            while (input != "end of race")
            {
                MatchCollection nameMatch = nameRegex.Matches(input);

                string name = String.Empty;

                foreach (Match letter in nameMatch)
                {
                    name += letter.Value;
                }
                
                if (!participants.ContainsKey(name))
                {
                    input = Console.ReadLine();
                    continue;
                }
                else
                {
                    MatchCollection distanceMatch = distanceRegex.Matches(input);

                    int distance = 0;

                    foreach (Match digit in distanceMatch)
                    {
                        distance += int.Parse(digit.Value);
                    }

                    participants[name] += distance;
                }

                input = Console.ReadLine();
            }

            int counter = 1;

            foreach (var participant in participants.OrderByDescending(x => x.Value))
            {
                if (counter == 1)
                {
                    Console.WriteLine($"1st place: {participant.Key}");
                }
                else if (counter == 2)
                {
                    Console.WriteLine($"2nd place: {participant.Key}");
                }
                else if (counter == 3)
                {
                    Console.WriteLine($"3rd place: {participant.Key}");
                }

                counter++;
            }
        }
    }
}
