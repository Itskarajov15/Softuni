using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace MatchPhoneNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex regex = new Regex(@"\+359 2 [0-9]{3} [0-9]{4}|\+359-2-[0-9]{3}-[0-9]{4}\b");

            string input = Console.ReadLine();

            MatchCollection matches = regex.Matches(input);

            string[] matchedNumbers = matches
                .Cast<Match>()
                .Select(x => x.Value.Trim())
                .ToArray();

            Console.WriteLine(String.Join(", ", matchedNumbers));
        }
    }
}
