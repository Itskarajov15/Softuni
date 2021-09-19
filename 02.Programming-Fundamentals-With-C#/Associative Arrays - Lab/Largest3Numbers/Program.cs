using System;
using System.Collections.Generic;
using System.Linq;

namespace Largest3Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int[] result = input.OrderByDescending(x => x)
                .ToArray();

            Array.Sort(input);

            if (input.Length < 3)
            {
                for (int i = 0; i < result.Length; i++)
                {
                    Console.Write(result[i] + " ");
                }
            }
            else
            {
                for (int i = 0; i < 3; i++)
                {
                    Console.Write(result[i] + " ");
                }
            }
        }
    }
}
