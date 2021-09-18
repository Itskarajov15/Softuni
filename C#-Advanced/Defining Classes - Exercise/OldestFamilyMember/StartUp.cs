using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Family family = new Family();

            for (int i = 0; i < n; i++)
            {
                string[] currPerson = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = currPerson[0];
                int age = int.Parse(currPerson[1]);

                var person = new Person(name, age);

                family.AddMember(person);
            }

            var oldestPerson = new Person();

            oldestPerson = family.ReturnTheOldestMember();

            Console.WriteLine($"{oldestPerson.Name} {oldestPerson.Age}");
        }
    }
}
