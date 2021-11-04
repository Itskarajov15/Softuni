using System;
using System.Collections.Generic;

namespace BorderControl
{
    class Program
    {
        static void Main(string[] args)
        {
            var citizens = new List<ICitizen>();

            while (true)
            {
                var line = Console.ReadLine();

                if (line == "End")
                {
                    break;
                }

                var parts = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (parts.Length == 2)
                {
                    citizens.Add(new Robot(parts[0], parts[1]));
                }
                else if (parts.Length == 3)
                {
                    citizens.Add(new Person(parts[0], int.Parse(parts[1]), parts[2]));
                }
            }

            var fakeIdNumber = Console.ReadLine();

            foreach (var citizen in citizens)
            {
                if (citizen.Id.EndsWith(fakeIdNumber))
                {
                    Console.WriteLine(citizen.Id);
                }
            }
        }
    }
}
