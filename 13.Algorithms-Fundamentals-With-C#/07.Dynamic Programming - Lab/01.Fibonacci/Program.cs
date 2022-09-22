using System;
using System.Collections.Generic;

namespace _01.Fibonacci
{
    internal class Program
    {
        private static Dictionary<int, long> cache;

        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            cache = new Dictionary<int, long>();

            Console.WriteLine(FindFib(n));
        }

        private static long FindFib(int n)
        {
            if (cache.ContainsKey(n))
            {
                return cache[n];
            }

            if (n < 2)
            {
                return n;
            }

            var result = FindFib(n - 1) + FindFib(n - 2);

            cache[n] = result;

            return result;
        }
    }
}