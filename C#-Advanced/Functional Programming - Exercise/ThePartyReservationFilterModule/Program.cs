using System;
using System.Collections.Generic;
using System.Linq;

namespace ThePartyReservationFilterModule
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> invitationList = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string[] command = Console.ReadLine()
                .Split(";", StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, Predicate<string>> filters = new Dictionary<string, Predicate<string>>();

            while (command[0] != "Print")
            {
                Predicate<string> predicate = GetPredicate(command[1], command[2]);

                if (command[0] == "Add filter")
                {
                    filters.Add(command[2], predicate);
                }
                else if (command[0] == "Remove filter")
                {
                    filters.Remove(command[2]);
                }

                command = Console.ReadLine()
                .Split(";", StringSplitOptions.RemoveEmptyEntries);
            }

            foreach (var currPredicate in filters)
            {
                invitationList.RemoveAll(currPredicate.Value);
            }

            Console.WriteLine(String.Join(" ", invitationList));
        }

        static Predicate<string> GetPredicate(string command, string arg)
        {
            switch (command)
            {
                case "Starts with": return name => name.StartsWith(arg);
                case "Ends with": return name => name.EndsWith(arg);
                case "Length": return name => name.Length == int.Parse(arg);
                case "Contains": return name => name.Contains(arg);
                default:
                    return null;
            }
        }
    }
}
