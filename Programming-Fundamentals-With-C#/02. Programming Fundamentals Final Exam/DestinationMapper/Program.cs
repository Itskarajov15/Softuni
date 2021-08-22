using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace DestinationMapper
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(=|\/){1}(?<destination>[A-Z][A-Za-z]{2,})\1";

            List<string> destinations = new List<string>();
            int travelPoints = 0;

            string input = Console.ReadLine();

            MatchCollection matches = Regex.Matches(input, pattern);

            foreach (Match destination in matches)
            {
                travelPoints += destination.Groups["destination"].Value.Length;

                destinations.Add(destination.Groups["destination"].Value);
            }

            Console.WriteLine($"Destinations: {String.Join(", ", destinations)}");

            Console.WriteLine($"Travel Points: {travelPoints}");
        }
    }
}
