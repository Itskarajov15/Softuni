using System;
using System.Collections.Generic;

namespace GenericCountMethodString
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Box<double>> listOfBoxes = new List<Box<double>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var currBox = new Box<double>(double.Parse(Console.ReadLine()));

                listOfBoxes.Add(currBox);
            }

            var boxToCompare = new Box<double>(double.Parse(Console.ReadLine()));

            int count = GetCount(listOfBoxes, boxToCompare);

            Console.WriteLine(count);
        }

        private static int GetCount<T>(List<Box<T>> boxes, Box<T> box)
            where T : IComparable
        {
            int count = 0;

            foreach (var item in boxes)
            {
                int compare = item.CompareTo(box);

                if (compare > 0)
                {
                    count++;
                }
            }

            return count;
        }
    }
}
