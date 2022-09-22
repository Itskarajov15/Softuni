using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.SetCover
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var universe = Console.ReadLine()
                                  .Split(", ")
                                  .Select(int.Parse)
                                  .ToHashSet();

            var countOfSets = int.Parse(Console.ReadLine());

            var sets = new List<int[]>();

            for (int i = 0; i < countOfSets; i++)
            {
                var currSet = Console.ReadLine()
                                     .Split(", ")
                                     .Select(int.Parse)
                                     .ToArray();

                sets.Add(currSet);
            }

            var usedSets = new List<int[]>();

            while (universe.Count > 0)
            {
                var set = sets
                    .OrderByDescending(s => s.Count(x => universe.Contains(x)))
                    .FirstOrDefault();

                usedSets.Add(set);
                sets.Remove(set);

                foreach (var element in set)
                {
                    universe.Remove(element);
                }
            }

            Console.WriteLine($"Sets to take ({usedSets.Count}):");

            foreach (var set in usedSets)
            {
                Console.WriteLine(String.Join(", ", set));
            }
        }
    }
}