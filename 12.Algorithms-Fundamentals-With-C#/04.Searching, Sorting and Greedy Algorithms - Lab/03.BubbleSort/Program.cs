using System;
using System.Linq;

namespace _03.BubbleSort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                                 .Split()
                                 .Select(int.Parse)
                                 .ToArray();

            SortArray(numbers);
            Console.WriteLine(String.Join(" ", numbers));
        }

        private static void SortArray(int[] numbers)
        {
            var isSorted = false;
            var sortCount = 0;

            while (!isSorted)
            {
                isSorted = true;

                for (int i = 0; i < numbers.Length - 1 - sortCount; i++)
                {
                    if (numbers[i] > numbers[i + 1])
                    {
                        Swap(numbers, i, i + 1);
                        isSorted = false;
                    }
                }

                sortCount++;
            }
        }

        private static void Swap(int[] numbers, int first, int second)
        {
            var temp = numbers[first];
            numbers[first] = numbers[second];
            numbers[second] = temp;
        }
    }
}