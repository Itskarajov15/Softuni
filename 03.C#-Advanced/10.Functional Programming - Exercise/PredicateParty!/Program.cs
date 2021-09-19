using System;
using System.Collections.Generic;
using System.Linq;

namespace PredicateParty_
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string[] command = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            while (command[0] != "Party!")
            {
                Predicate<string> predicate = GetPredicate(command[1], command[2]);

                if (command[0] == "Double")
                {
                    List<string> doubleIt = names.FindAll(predicate);

                    if (doubleIt.Any())
                    {
                        int index = names.FindIndex(predicate);

                        names.InsertRange(index, doubleIt);
                    }
                }
                else if (command[0] == "Remove")
                {
                    names.RemoveAll(predicate);
                }

                command = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }

            Console.WriteLine(names.Any() ? $"{String.Join(", ", names)} are going to the party!" : "Nobody is going to the party!");
        }

        static Predicate<string> GetPredicate(string command, string arg)
        {
            switch (command)
            {
                case "StartsWith": return name => name.StartsWith(arg);
                case "EndsWith": return name => name.EndsWith(arg);
                case "Length": return name => name.Length == int.Parse(arg);
                default:
                    return null;
            }
        }
    }
}
