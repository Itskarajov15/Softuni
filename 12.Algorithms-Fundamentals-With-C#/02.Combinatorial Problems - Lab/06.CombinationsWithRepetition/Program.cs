using System;
using System.Linq;

namespace _06.CombinationsWithRepetition
{
    internal class Program
    {
        private static string[] elements;
        private static string[] combinations;
        private static int k;

        static void Main(string[] args)
        {
            elements = Console.ReadLine()
                              .Split()
                              .ToArray();

            k = int.Parse(Console.ReadLine());
            combinations = new string[k];

            GenCombinations(0, 0);
        }

        private static void GenCombinations(int idx, int elementStartIdx)
        {
            if (idx >= combinations.Length)
            {
                Console.WriteLine(String.Join(" ", combinations));
                return;
            }

            for (int i = elementStartIdx; i < elements.Length; i++)
            {
                combinations[idx] = elements[i];
                GenCombinations(idx + 1, i);
            }
        }
    }
}