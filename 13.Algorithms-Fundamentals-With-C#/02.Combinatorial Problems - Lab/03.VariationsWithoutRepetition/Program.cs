using System;
using System.Linq;

namespace _03.VariationsWithoutRepetition
{
    internal class Program
    {
        private static string[] elements;
        private static string[] variations;
        private static bool[] used;
        private static int k;

        static void Main(string[] args)
        {
            elements = Console.ReadLine()
                              .Split()
                              .ToArray();

            k = int.Parse(Console.ReadLine());

            variations = new string[k];
            used = new bool[elements.Length];

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
                if (used[i] == false)
                {
                    used[i] = true;
                    variations[idx] = elements[i];
                    GenVariations(idx + 1);
                    used[i] = false;
                }
            }
        }
    }
}