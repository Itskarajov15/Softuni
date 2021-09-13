using System;
using System.Linq;

namespace KnightsOfHonor
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(x => $"Sir {x}")
                .ToArray();

            Action<string> printNames = name => Console.WriteLine(name);

            foreach (var name in names)
            {
                printNames(name);
            }
        }
    }
}
