using FoodShortage.Implementations;
using FoodShortage.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace FoodShortage
{
    class Program
    {
        static void Main(string[] args)
        {
            var listOfPeople = new List<IBuyer>();

            var numberOfPeople = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfPeople; i++)
            {
                var personData = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                var name = personData[0];
                var age = int.Parse(personData[1]);

                if (personData.Length == 4)
                {
                    var id = personData[2];
                    var birthDate = DateTime.ParseExact(personData[3], "dd/MM/yyyy", CultureInfo.InvariantCulture);

                    var citizen = new Person(name, age, id, birthDate);

                    listOfPeople.Add(citizen);
                }
                else if (personData.Length == 3)
                {
                    var group = personData[2];

                    var rebel = new Rebel(name, age, group);

                    listOfPeople.Add(rebel);
                }
            }

            var command = Console.ReadLine();

            while (command != "End")
            {

                var currCitizen = listOfPeople.FirstOrDefault(c => c.Name == command);

                if (currCitizen == null)
                {
                    command = Console.ReadLine();
                    continue;
                }

                currCitizen.BuyFood();

                command = Console.ReadLine();
            }

            Console.WriteLine(listOfPeople.Sum(b => b.Food));
        }
    }
}
