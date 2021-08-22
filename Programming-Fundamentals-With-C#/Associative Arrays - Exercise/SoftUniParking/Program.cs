using System;
using System.Collections.Generic;

namespace SoftUniParking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> parking = new Dictionary<string, string>();

            int input = int.Parse(Console.ReadLine());

            for (int i = 0; i < input; i++)
            {
                string[] command = Console.ReadLine()
                    .Split();

                if (command[0] == "register")
                {
                    string name = command[1];
                    string licensePlateNumber = command[2];

                    if (parking.ContainsKey(name))
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {licensePlateNumber}");
                    }
                    else
                    {
                        parking.Add(name, licensePlateNumber);

                        Console.WriteLine($"{name} registered {licensePlateNumber} successfully");
                    }
                }
                else if (command[0] == "unregister")
                {
                    string name = command[1];

                    if (parking.ContainsKey(name))
                    {
                        parking.Remove(name);

                        Console.WriteLine($"{name} unregistered successfully");
                    }
                    else
                    {
                        Console.WriteLine($"ERROR: user {name} not found");
                    }
                }
            }

            foreach (var name in parking)
            {
                Console.WriteLine($"{name.Key} => {name.Value}");
            }
        }
    }
}
