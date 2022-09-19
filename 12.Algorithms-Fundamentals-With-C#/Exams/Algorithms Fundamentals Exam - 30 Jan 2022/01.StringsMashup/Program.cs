using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.StringsMashup
{
    internal class Program
    {
        private static char[] input;
        private static char[] combination;

        static void Main(string[] args)
        {
            input = Console.ReadLine().ToCharArray().OrderBy(x => x).ToArray();
            var k = int.Parse(Console.ReadLine());

            combination = new char[k];

            GetCombinations(0, 0);
        }

        private static void GetCombinations(int idx, int startIdx)
        {
            if (idx >= combination.Length)
            {
                Console.WriteLine(String.Join("", combination));
                return;
            }

            for (int i = startIdx; i < input.Length; i++)
            {
                combination[idx] = input[i];
                GetCombinations(idx + 1, i);
            }
        }
    }
}