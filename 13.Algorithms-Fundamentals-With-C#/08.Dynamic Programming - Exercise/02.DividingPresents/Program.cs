using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.DividingPresents
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var presents = Console.ReadLine()
                                  .Split()
                                  .Select(int.Parse)
                                  .ToArray();

            var possibleSums = GetAllPossibleSums(presents);

            var sumOfPresents = presents.Sum();
            var alanSum = sumOfPresents / 2;

            while (true)
            {
                if (possibleSums.ContainsKey(alanSum))
                {
                    var alanPresents = GetPresentsForAlan(alanSum, possibleSums);
                    var bobSum = sumOfPresents - alanSum;
                    Console.WriteLine($"Difference: {bobSum - alanSum}");
                    Console.WriteLine($"Alan:{alanSum} Bob:{bobSum}");
                    Console.WriteLine($"Alan takes: {String.Join(" ", alanPresents)}");
                    Console.WriteLine("Bob takes the rest.");
                    break;
                }

                alanSum -= 1;
            }
        }

        private static List<int> GetPresentsForAlan(int target, Dictionary<int, int> sums)
        {
            var subset = new List<int>();

            while (target != 0)
            {
                var element = sums[target];
                subset.Add(element);
                target -= element;
            }

            return subset;
        }

        private static Dictionary<int, int> GetAllPossibleSums(int[] presents)
        {
            var sums = new Dictionary<int, int> { { 0, 0 } };

            foreach (var present in presents)
            {
                var currSums = sums.Keys.ToArray();
                    
                foreach (var sum in currSums)
                {
                    var newSum = present + sum;

                    if (sums.ContainsKey(newSum))
                    {
                        continue;
                    }

                    sums.Add(newSum, present); 
                }
            }

            return sums;
        }
    }
}