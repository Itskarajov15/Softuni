using System;
using System.Collections.Generic;

namespace _01.MoveDownRight
{
    internal class Program
    {
        private static Dictionary<string, long> values;

        static void Main(string[] args)
        {
            var rows = int.Parse(Console.ReadLine());
            var cols = int.Parse(Console.ReadLine());

            values = new Dictionary<string, long>();

            Console.WriteLine(GetNumberPaths(rows, cols));
        }

        private static long GetNumberPaths(int rows, int cols)
        {
            var key = $"{rows}-{cols}";

            if (values.ContainsKey(key))
            {
                return values[key];
            }

            if (rows == 1 || cols == 1)
            {
                return 1;
            }

            var result = GetNumberPaths(rows - 1, cols) + GetNumberPaths(rows, cols - 1);

            values.Add(key, result);

            return result;
        }
    }
}