﻿using System;
using System.Linq;

namespace _04.InsertionSort
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
            for (int i = 0; i < numbers.Length; i++)
            {
                var j = i;

                while (j > 0 && numbers[j - 1] > numbers[j])
                {
                    Swap(numbers, j, j - 1);
                    j--;
                }
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