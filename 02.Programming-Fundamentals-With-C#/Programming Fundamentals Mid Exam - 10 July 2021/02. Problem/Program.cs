using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Problem
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> partsOfAWeapon = Console.ReadLine()
                .Split('|', StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string[] command = Console.ReadLine()
                .Split();

            while (command[0] != "Done")
            {
                if (command[0] == "Add")
                {
                    string particle = command[1];
                    int index = int.Parse(command[2]);

                    if (index >= 0 && index < partsOfAWeapon.Count)
                    {
                        partsOfAWeapon.Insert(index, particle);
                    }
                    else
                    {
                        command = Console.ReadLine()
                        .Split();
                        continue;
                    }
                }
                else if (command[0] == "Remove")
                {
                    int index = int.Parse(command[1]);

                    if (index >= 0 && index < partsOfAWeapon.Count)
                    {
                        partsOfAWeapon.RemoveAt(index);
                    }
                    else
                    {
                        command = Console.ReadLine()
                        .Split();
                        continue;
                    }
                }
                else if (command[0] == "Check")
                {
                    if (command[1] == "Even")
                    {
                        PrintElementsAtEvenOrOddIndexPositions(partsOfAWeapon, 0);
                    }
                    else if (command[1] == "Odd")
                    {
                        PrintElementsAtEvenOrOddIndexPositions(partsOfAWeapon, 1);
                    }
                }

                command = Console.ReadLine()
                .Split();
            }

            string name = ConcatenatingTheParts(partsOfAWeapon);

            Console.WriteLine($"You crafted {name}!");
        }

        static string ConcatenatingTheParts(List<string> partsOfAWeapon)
        {
            string name = String.Empty;

            for (int i = 0; i < partsOfAWeapon.Count; i++)
            {
                name += partsOfAWeapon[i];
            }

            return name;
        }

        static void PrintElementsAtEvenOrOddIndexPositions(List<string> partsOfAWeapon, int number)
        {
            for (int i = 0; i < partsOfAWeapon.Count; i++)
            {
                if (i % 2 == number)
                {
                    Console.Write(partsOfAWeapon[i] + " ");
                }
            }

            Console.WriteLine();
        }
    }
}
