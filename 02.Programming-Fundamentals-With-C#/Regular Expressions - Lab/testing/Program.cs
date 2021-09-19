using System;
using System.Text.RegularExpressions;

namespace MatchFullName
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex regex = new Regex(@"[A-Z][a-z]+ [A-Z][a-z]+");

            string input = "Asen Karadzhov is the best and John Smith is not!";

            MatchCollection matches = regex.Matches(input);

            string newString = String.Empty;

            newString = regex.Replace(input, new string('*', matches[0].Value.Length));

            Console.WriteLine(newString);
        }
    }
}
