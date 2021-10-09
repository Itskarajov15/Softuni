using System;
using System.Collections.Generic;

namespace ComparingObjects
{
    class Program
    {
        static void Main(string[] args)
        {
            var listOfPeople = new List<Person>();

            var input = Console.ReadLine();

            while (input != "END")
            {
                var tokens = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = tokens[0];
                int age = int.Parse(tokens[1]);
                string town = tokens[2];

                var currPerson = new Person(name, age, town);

                listOfPeople.Add(currPerson);

                input = Console.ReadLine();
            }

            int n = int.Parse(Console.ReadLine());
            int countOfMatches = 0;
            int countOfNotEqualPeople = 0;

            foreach (var person in listOfPeople)
            {
                if (person.CompareTo(listOfPeople[n - 1]) == 0)
                {
                    countOfMatches++;
                }
                else
                {
                    countOfNotEqualPeople++;
                }
            }

            if (countOfMatches == 0 || countOfMatches == 1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine($"{countOfMatches} {countOfNotEqualPeople} {listOfPeople.Count}");
            }
        }
    }
}
