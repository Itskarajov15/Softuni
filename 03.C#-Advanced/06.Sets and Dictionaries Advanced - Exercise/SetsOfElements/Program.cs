using System;
using System.Collections.Generic;
using System.Linq;

namespace SetsOfElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int n = input[0];
            int m = input[1];

            HashSet<int> firstSet = new HashSet<int>();
            HashSet<int> secondSet = new HashSet<int>();
            HashSet<int> result = new HashSet<int>();

            for (int i = 0; i < n + m; i++)
            {
                int number = int.Parse(Console.ReadLine());

                if (i < n)
                {
                    firstSet.Add(number);
                }
                else
                {
                    secondSet.Add(number);
                }
            }

            foreach (var number in firstSet)
            {
                if (secondSet.Contains(number))
                {
                    result.Add(number);
                }
            }

            Console.WriteLine(String.Join(" ", result));
        }
    }
}
