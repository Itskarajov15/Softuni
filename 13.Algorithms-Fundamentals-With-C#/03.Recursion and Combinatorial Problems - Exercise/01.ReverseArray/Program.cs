using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.ReverseArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var elements = Console.ReadLine()
                              .Split()
                              .Select(int.Parse)
                              .ToArray();

            ReverseArray(elements, 0);
        }

        private static void ReverseArray(int[] elements, int idx)
        {
            if (idx == elements.Length / 2)
            {
                Console.WriteLine(String.Join(" ", elements));
                return;
            }

            var temp = elements[idx];
            elements[idx] = elements[elements.Length - 1 - idx];
            elements[elements.Length - 1 - idx] = temp;

            ReverseArray(elements, idx + 1);
        }
    }
}