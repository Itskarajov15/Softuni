using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.SubsetSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var nums = new[] { 3, 5, 1, 4, 2 };
            var target = 6;

            var possibleSums = GetAllPossibleSums(nums);

            if (possibleSums.ContainsKey(target))
            {
                var includedNums = FindSubset(possibleSums, target);

                Console.WriteLine(String.Join(" ", includedNums));
            }
            else
            {
                Console.WriteLine("Sum was not possible");
            }
        }

        private static List<int> FindSubset(Dictionary<int, int> possibleSums,int target)
        {
            var subset = new List<int>();

            while (target > 0)
            {
                var num = possibleSums[target];
                subset.Add(num);
                target -= num;
            }

            return subset;
        }

        private static Dictionary<int, int> GetAllPossibleSums(int[] nums)
        {
            var sums = new Dictionary<int, int>() { { 0, 0 } };

            foreach (var num in nums)
            {
                var currSums = sums.Keys.ToArray();

                foreach (var sum in currSums)
                {
                    var newSum = sum + num;

                    if (sums.ContainsKey(newSum))
                    {
                        continue;
                    }

                    sums.Add(newSum, num);
                }
            }

            return sums;
        }
    }
}