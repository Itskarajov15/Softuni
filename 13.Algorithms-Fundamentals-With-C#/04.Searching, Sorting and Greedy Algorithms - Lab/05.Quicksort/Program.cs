using System;
using System.Linq;

namespace _05.Quicksort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                                 .Split()
                                 .Select(int.Parse)
                                 .ToArray();

            Quicksort(numbers, 0, numbers.Length - 1);
            Console.WriteLine(String.Join(" ", numbers));
        }

        private static void Quicksort(int[] numbers, int start, int end)
        {
            if (start >= end)
            {
                return;
            }

            var pivot = start;
            var left = start + 1;
            var right = end;

            while (left <= right)
            {
                if (numbers[left] > numbers[pivot] && numbers[right] < numbers[pivot])
                {
                    Swap(numbers, left, right);
                }

                if (numbers[left] <= numbers[pivot])
                {
                    left++;
                }

                if (numbers[right] >= numbers[pivot])
                {
                    right--;
                }
            }

            Swap(numbers, pivot, right);

            Quicksort(numbers, start, right - 1);
            Quicksort(numbers, right + 1, end);
        }

        private static void Swap(int[] numbers, int first, int second)
        {
            var temp = numbers[first];
            numbers[first] = numbers[second];
            numbers[second] = temp;
        }
    }
}