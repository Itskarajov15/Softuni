using System;
using System.Text.RegularExpressions;

namespace _02._Problem
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(\*|@){1}(?<firstWord>[A-Z][a-z]{2,})\1: (\[(?<firstLetter>[A-Za-z])\])\|(\[(?<secondLetter>[A-Za-z])\])\|(\[(?<thirdLetter>[A-Za-z])\])\|$";

            int numberOfInputs = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfInputs; i++)
            {
                string input = Console.ReadLine();

                Match match = Regex.Match(input, pattern);

                if (!Regex.IsMatch(input, pattern))
                {
                    Console.WriteLine("Valid message not found!");
                    continue;
                }

                string word = match.Groups["firstWord"].Value;
                char firstLetter = char.Parse(match.Groups["firstLetter"].Value);
                char secondLetter = char.Parse(match.Groups["secondLetter"].Value);
                char thirdLetter = char.Parse(match.Groups["thirdLetter"].Value);

                int firstLetterNumber = (int)firstLetter;
                int secondLetterNumber = (int)secondLetter;
                int thirdLetterNumber = (int)thirdLetter;

                Console.WriteLine($"{word}: {firstLetterNumber} {secondLetterNumber} {thirdLetterNumber}");
            }
        }
    }
}
