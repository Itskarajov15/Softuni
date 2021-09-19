using System;
using System.Collections.Generic;
using System.Linq;

namespace FindEvensOrOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] bounds = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            int lowerBound = int.Parse(bounds[0]);
            int higherBound = int.Parse(bounds[1]);

            string input = Console.ReadLine();

            Func<int, int, List<int>> returnListWithNumbers = (lowerBound, higherBound) =>
            {
                List<int> numbers = new List<int>();

                for (int i = lowerBound; i <= higherBound; i++)
                {
                    numbers.Add(i);
                }

                return numbers;
            };
            List<int> numbers = returnListWithNumbers(lowerBound, higherBound);

            Predicate<int> predicate = x => true;

            if (input == "even")
            {
                predicate = x => x % 2 == 0;
            }
            else if (input == "odd")
            {
                predicate = x => x % 2 != 0;
            }

            Console.WriteLine(String.Join(" ", MyWhere(numbers, predicate)));
        }

        static List<int> MyWhere(List<int> numbers, Predicate<int> predicate)
        {
            List<int> newList = new List<int>();

            foreach (int currNumber in numbers)
            {
                if (predicate(currNumber))
                {
                    newList.Add(currNumber);
                }
            }

            return newList;
        }
    }
}
