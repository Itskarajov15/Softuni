using System;
using System.Linq;

namespace _01.RecursiveArraySum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var nums = Console.ReadLine()
                              .Split()
                              .Select(int.Parse)
                              .ToArray();

            Console.WriteLine(SumRecursively(nums, 0));
        }

        private static int SumRecursively(int[] nums, int idx)
        {
            if (idx == nums.Length - 1)
            {
                return nums[idx];
            }

            return nums[idx] + SumRecursively(nums, idx + 1);
        }
    }
}