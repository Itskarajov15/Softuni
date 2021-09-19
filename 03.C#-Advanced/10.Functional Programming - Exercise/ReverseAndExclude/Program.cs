using System;
using System.Collections.Generic;
using System.Linq;

namespace ReverseAndExclude
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            int givenNumber = int.Parse(Console.ReadLine());

            numbers = MyWhere(numbers, x => x % givenNumber != 0);

            Func<List<int>, List<int>> reverseTheList = list =>
            {
                List<int> reversedList = new List<int>();

                for (int i = numbers.Count - 1; i >= 0; i--)
                {
                    reversedList.Add(numbers[i]);
                }

                return reversedList;
            };

            numbers = reverseTheList(numbers);

            Console.WriteLine(String.Join(" ", numbers));
        }

        static List<int> MyWhere(List<int> numbers, Predicate<int> predicate)
        {
            List<int> newList = new List<int>();

            foreach (int number in numbers)
            {
                if (predicate(number))
                {
                    newList.Add(number);
                }
            }

            return newList;
        }
    }
}
