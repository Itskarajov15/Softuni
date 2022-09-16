using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace _01.TwoMinutesToMidnight
{
    internal class Program
    {
        private static Dictionary<string, long> values;

        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var k = int.Parse(Console.ReadLine());

            values = new Dictionary<string, long>();

            Console.WriteLine(GetBinom(n, k));
        }

        private static long GetBinom(int row, int col)
        {
            var key = $"{row}-{col}";

            if (values.ContainsKey(key))
            {
                return values[key];
            }

            if (row <= 1 || col == row || col == 0)
            {
                return 1;
            }

            var result = GetBinom(row - 1, col - 1) + GetBinom(row - 1, col);

            values.Add(key, result);

            return result;
        }
    }
}