using System;
using System.Linq;

namespace ValidUsernames
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] usernames = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);

            foreach (var username in usernames)
            {
                if (username.Length >= 3 && username.Length <= 16)
                {
                    if (username.All(c => Char.IsLetterOrDigit(c) || c.Equals('-') || c.Equals('_')))
                    {
                        Console.WriteLine(username);
                    }
                }
            }
        }
    }
}
