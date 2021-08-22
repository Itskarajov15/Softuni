using System;
using System.Collections.Generic;
using System.Linq;

namespace SumAdjacentEqualNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            List<int> result = new List<int>();

            result = SumNumbersInCurrentOrder(numbers);

            if (numbers.Count % 2 != 0)
            {
                int element = numbers[numbers.Count / 2];
                result.Add(element);
            }

            Console.WriteLine(String.Join(" ", result));
        }

        static List<int> SumNumbersInCurrentOrder(List<int> numbers)
        {
            List<int> result = new List<int>();

            for (int i = 0; i < numbers.Count / 2; i++)
            {
                int sum = numbers[i] + numbers[numbers.Count - 1 - i];

                result.Add(sum);
            }

            return result;
        }
    }
}
