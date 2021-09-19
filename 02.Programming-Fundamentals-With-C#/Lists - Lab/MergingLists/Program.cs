using System;
using System.Collections.Generic;
using System.Linq;

namespace SumAdjacentEqualNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> firstList = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            List<int> secondList = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            List<int> result = new List<int>();

            int maxCount = Math.Max(firstList.Count, secondList.Count);

            result = AddNumbersInTheResult(firstList, secondList, maxCount);

            Console.WriteLine(String.Join(" ", result));
        }

        static List<int> AddNumbersInTheResult(List<int> firstList, List<int> secondList, int maxCount)
        {
            List<int> result = new List<int>();

            for (int i = 0; i < maxCount; i++)
            {
                if (i < firstList.Count)
                {
                    result.Add(firstList[i]);
                }

                if (i < secondList.Count)
                {
                    result.Add(secondList[i]);
                }
            }

            return result;
        }
    }
}
