using System;
using System.Linq;

namespace _04.VariationsWithRepetition
{
    internal class Program
    {
        private static string[] elements;
        private static string[] variations;
        private static int k;

        static void Main(string[] args)
        {
            elements = Console.ReadLine()
                              .Split()
                              .ToArray();

            k = int.Parse(Console.ReadLine());
            variations = new string[k];

            GenVariations(0);
        }

        private static void GenVariations(int idx)
        {
            if (idx >= variations.Length)
            {
                Console.WriteLine(String.Join(" ", variations));
                return;
            }

            for (int i = 0; i < elements.Length; i++)
            {
                variations[idx] = elements[i];
                GenVariations(idx + 1);
            }
        }
    }
}