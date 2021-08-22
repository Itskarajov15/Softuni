using System;
using System.Text.RegularExpressions;

namespace MatchFullName
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex regex = new Regex(@"\b[A-Z][a-z]+ [A-Z][a-z]+\b");

            string input = Console.ReadLine();

            MatchCollection matches = regex.Matches(input);

            foreach (Match fullName in matches)
            {
                Console.Write(fullName + " ");
            }
        }
    }
}
