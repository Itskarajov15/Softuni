using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomMinFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            Func<List<int>, int> returnTheSmallestNumber = x =>
            {
                int smallestNumber = int.MaxValue;

                for (int i = 0; i < numbers.Count; i++)
                {
                    if (numbers[i] < smallestNumber)
                    {
                        smallestNumber = numbers[i];
                    }
                }

                return smallestNumber;
            };

            int smallestNumber = returnTheSmallestNumber(numbers);

            Console.WriteLine(smallestNumber);
        }
    }
}
