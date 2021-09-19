using System;
using System.Collections.Generic;
using System.Linq;

namespace Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> list = Console.ReadLine()
                .Split()
                .Select(double.Parse)
                .ToList();

            double average = Queryable.Average(list.AsQueryable());

            List<double> result = new List<double>();

            result = AddingNumbersInTheNewList(list, average);

            result.Sort();
            result.Reverse();

            PrintFinalResult(result);
        }

        static void PrintFinalResult(List<double> result)
        {
            if (result.Count == 0)
            {
                Console.WriteLine("No");
            }
            else if (result.Count < 5)
            {
                for (int i = 0; i < result.Count; i++)
                {
                    Console.Write(result[i] + " ");
                }
            }
            else
            {
                for (int i = 0; i < 5; i++)
                {
                    Console.Write(result[i] + " ");
                }
            }
        }

        static List<double> AddingNumbersInTheNewList(List<double> list, double average)
        {
            List<double> result = new List<double>();

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] > average)
                {
                    result.Add(list[i]);
                }
            }

            return result;
        }
    }
}
