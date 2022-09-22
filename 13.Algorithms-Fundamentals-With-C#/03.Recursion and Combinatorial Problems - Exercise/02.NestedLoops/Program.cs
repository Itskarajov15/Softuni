using System;

namespace _02.NestedLoops
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var elements = new int[n];

            GenNumbers(elements, 0);
        }

        private static void GenNumbers(int[] elements, int idx)
        {
            if (idx >= elements.Length)
            {
                Console.WriteLine(String.Join(" ", elements));
                return;
            }

            for (int i = 1; i <= elements.Length; i++)
            {
                elements[idx] = i;
                GenNumbers(elements, idx + 1);
            }
        }
    }
}