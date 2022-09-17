using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.SuperSet
{
    internal class Program
    {
        private static List<int[]> combinations;
        private static int[] elements;
        private static int[] combination;

        static void Main(string[] args)
        {
            elements = Console.ReadLine()
                                  .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                                  .Select(int.Parse)
                                  .ToArray();

            combinations = new List<int[]>();

            for (int i = 0; i < elements.Length; i++)
            {
                combination = new int[i + 1];

                GetCombinations(0, 0);
            }

            foreach (var set in combinations)
            {
                Console.WriteLine(String.Join(" ", set));
            }
        }

        private static void GetCombinations(int idx, int start)
        {
            if (idx >= combination.Length)
            {
                combinations.Add(combination.ToArray());
                return;
            }

            for (int i = start; i < elements.Length; i++)
            {
                combination[idx] = elements[i];
                GetCombinations(idx + 1, i + 1);
            }
        }
    }
}