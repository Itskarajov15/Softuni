using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var person = new Person();
            List<Person> people = new List<Person>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] currPerson = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = currPerson[0];
                int age = int.Parse(currPerson[1]);

                people.Add(new Person(name, age));
            }

            Func<int, bool> predicateForAges = x => x > 30;

            var peopleOverThirty = people
                .Where(x => predicateForAges(x.Age))
                .OrderBy(x => x.Name)
                .ToList();

            foreach (var currPerson in peopleOverThirty)
            {
                Console.WriteLine($"{currPerson.Name} - {currPerson.Age}");
            }
        }
    }
}
