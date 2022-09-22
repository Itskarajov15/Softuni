using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.BankRobbery
{
    internal class Program
    {
        private static List<int> elements;

        static void Main(string[] args)
        {
            elements = Console.ReadLine()
                                  .Split()
                                  .Select(int.Parse)
                                  .ToList();

            var elementsSum = elements.Sum();
            var half = elementsSum / 2;
            var sums = GetAllSums(elements);

            while (true)
            {
                if (sums.ContainsKey(half))
                {
                    var firstSums = GetSums(half, sums);
                    Console.WriteLine(String.Join(" ", firstSums.OrderBy(x => x)));
                    Console.WriteLine(String.Join(" ", elements.OrderBy(x => x)));
                    break;
                }

                half--;
            }
        }

        private static List<int> GetSums(int target, Dictionary<int, int> sums)
        {
            var result = new List<int>();

            while (target > 0)
            {
                var element = sums[target];
                result.Add(element);
                elements.Remove(element);
                target -= element;
            }

            return result;
        }

        private static Dictionary<int, int> GetAllSums(List<int> elements)
        {
            var sums = new Dictionary<int, int>() { { 0, 0 } };

            foreach (var element in elements)
            {
                var currSums = sums.Keys.ToArray();

                foreach (var sum in currSums)
                {
                    var newSum = element + sum;

                    if (sums.ContainsKey(newSum))
                    {
                        continue;
                    }

                    sums.Add(newSum, element);
                }
            }

            return sums;
        }
    }
}