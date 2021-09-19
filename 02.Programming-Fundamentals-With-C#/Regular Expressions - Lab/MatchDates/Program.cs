using System;
using System.Text.RegularExpressions;

namespace MatchDates
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex regex = new Regex(@"\b(?<day>[0-9]{2})(.)(?<month>[A-Z][a-z]{2})\1(?<year>[0-9]{4})");

            string input = Console.ReadLine();

            MatchCollection date = regex.Matches(input);

            foreach (Match item in date)
            {
                var day = item.Groups["day"];
                var month = item.Groups["month"];
                var year = item.Groups["year"];

                Console.WriteLine($"Day: {day}, Month: {month}, Year: {year}");
            }
        }
    }
}
