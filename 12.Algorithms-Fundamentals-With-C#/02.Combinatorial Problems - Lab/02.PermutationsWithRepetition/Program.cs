﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.PermutationsWithRepetition
{
    internal class Program
    {
        private static string[] elements;

        static void Main(string[] args)
        {
            elements = Console.ReadLine()
                              .Split()
                              .ToArray();

            Permute(0);
        }

        private static void Permute(int idx)
        {
            if (idx >= elements.Length)
            {
                Console.WriteLine(String.Join(" ", elements));
                return;
            }

            Permute(idx + 1);

            var used = new HashSet<string>() { elements[idx] };

            for (int i = idx + 1; i < elements.Length; i++)
            {
                if (!used.Contains(elements[i]))
                {
                    Swap(idx, i);
                    Permute(idx + 1);
                    Swap(idx, i);
                    used.Add(elements[i]);
                }
            }
        }

        private static void Swap(int first, int second)
        {
            var temp = elements[first];
            elements[first] = elements[second];
            elements[second] = temp;
        }
    }
}