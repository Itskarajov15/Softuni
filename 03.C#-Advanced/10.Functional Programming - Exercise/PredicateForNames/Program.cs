using System;
using System.Collections.Generic;
using System.Linq;

namespace PredicateForNames
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());

            Func<string, int, bool> predicate = (name, lenght) => name.Length <= lenght;

            List<string> names = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Where(name => predicate(name, length))
                .ToList();

            Action<List<string>> printNames = names =>
            {
                Console.WriteLine(String.Join(Environment.NewLine, names));
            };

            printNames(names);
        }
    }
}
