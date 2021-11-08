using ExplicitInterfaces.Implementations;
using ExplicitInterfaces.Interfaces;
using System;
using System.Collections.Generic;

namespace ExplicitInterfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            var citizens = new List<Citizen>();

            var input = Console.ReadLine();

            while (input != "End")
            {
                var personInfo = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                var name = personInfo[0];
                var country = personInfo[1];
                var age = int.Parse(personInfo[2]);

                citizens.Add(new Citizen(name, country, age));

                input = Console.ReadLine();
            }

            foreach (var citizen in citizens)
            {
                Console.WriteLine(citizen);
            }
        }
    }
}
