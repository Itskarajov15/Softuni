using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericSwapMethodString
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var listOfBoxes = new List<Box<string>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var currBox = new Box<string>(Console.ReadLine());

                listOfBoxes.Add(currBox);
            }

            var indices = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var firstIndex = indices[0];
            var secondIndex = indices[1];

            SwapIndices(listOfBoxes, firstIndex, secondIndex);

            foreach (var box in listOfBoxes)
            {
                Console.WriteLine(box);
            }
        }

        private static void SwapIndices<T>(List<Box<T>> listOfBoxes, int firstIndex, int secondIndex)
        {
            var temp = listOfBoxes[firstIndex];
            listOfBoxes[firstIndex] = listOfBoxes[secondIndex];
            listOfBoxes[secondIndex] = temp;
        }
    }
}
