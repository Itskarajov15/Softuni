using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.SumWithLimitedCoins
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                                 .Split()
                                 .Select(int.Parse)
                                 .ToArray();

            var target = int.Parse(Console.ReadLine());

            Console.WriteLine(CountOfSums(numbers, target));
        }

        private static int CountOfSums(int[] numbers, int target)
        {
            var count = 0;

            var sums = new HashSet<int> { 0 };

            foreach (var number in numbers)
            {
                var newSums = new HashSet<int>();

                foreach (var sum in sums)
                {
                    var newSum = number + sum;

                    if (newSum == target)
                    {
                        count++;
                    }

                    newSums.Add(newSum);
                }

                sums.UnionWith(newSums);
            }

            return count;
        }
    }
}