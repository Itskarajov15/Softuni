using System;
using System.Collections.Generic;
using System.Data;

namespace _01.BinomialCoefficients
{
    internal class Program
    {
        private static Dictionary<string, long> cache;

        static void Main(string[] args)
        {
            var r = int.Parse(Console.ReadLine());
            var c = int.Parse(Console.ReadLine());

            cache = new Dictionary<string, long>();

            Console.WriteLine(FindBinomial(r, c));
        }

        private static long FindBinomial(int r, int c)
        {
            if (c == 0 || c == r)
            {
                return 1;
            }

            var key = $"{r}-{c}";

            if (cache.ContainsKey(key))
            {
                return cache[key];
            }

            var result = FindBinomial(r - 1, c - 1) + FindBinomial(r - 1, c);

            cache.Add(key, result);

            return result;
        }
    }
}