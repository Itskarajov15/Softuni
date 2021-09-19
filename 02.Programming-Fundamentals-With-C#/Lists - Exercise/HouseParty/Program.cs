using System;
using System.Collections.Generic;

namespace HouseParty
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfCommands = int.Parse(Console.ReadLine());

            List<string> guests = new List<string>();

            for (int i = 0; i < numberOfCommands; i++)
            {
                string[] command = Console.ReadLine()
                    .Split();

                string name = command[0];

                if (command[2] == "not")
                {
                    bool isInTheList = CheckIfTheNameIsInTheList(name, guests);

                    if (isInTheList)
                    {
                        guests.Remove(name);

                    }
                    else
                    {
                        Console.WriteLine($"{name} is not in the list!");
                    }
                }
                else
                {
                    bool isInTheList = CheckIfTheNameIsInTheList(name, guests);

                    if (isInTheList)
                    {
                        Console.WriteLine($"{name} is already in the list!");
                    }
                    else
                    {
                        guests.Add(name);
                    }
                }
            }

            PrintNamesOfGuests(guests);
        }

        private static void PrintNamesOfGuests(List<string> guests)
        {
            for (int i = 0; i < guests.Count; i++)
            {
                Console.WriteLine(guests[i]);
            }
        }

        static bool CheckIfTheNameIsInTheList(string name, List<string> guests)
        {
            bool isInTheList = guests.Contains(name);

            return isInTheList;
        }
    }
}
