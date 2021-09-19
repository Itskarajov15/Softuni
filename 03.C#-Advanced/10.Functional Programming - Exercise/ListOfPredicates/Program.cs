using System;
using System.Collections.Generic;
using System.Linq;

namespace ListOfPredicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int range = int.Parse(Console.ReadLine());

            List<int> dividers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            List<int> numbers = Enumerable.Range(1, range).ToList();

            Func<int, int, bool> predicate = (num, d) => num % d == 0;

            foreach (int num in numbers)
            {
                if (dividers.All(d => predicate(num, d)))
                {
                    Console.Write(num + " ");
                }
            }

            //List<int> listOfPredicates = ReturnListOfPredicates(dividers, range, (x, y) => x % y == 0);

            //Action<List<int>> printList = list => Console.WriteLine(String.Join(" ", list));

            //printList(listOfPredicates);
        }

        //static List<int> ReturnListOfPredicates(List<int> dividers, int range, Func<int, int, bool> predicate)
        //{
        //    List<int> listOfPredicates = new List<int>();

        //    bool isDivisible = false;

        //    for (int i = 1; i <= range; i++)
        //    {
        //        isDivisible = false;

        //        for (int j = 0; j < dividers.Count; j++)
        //        {
        //            if (predicate(i, dividers[j]))
        //            {
        //                isDivisible = true;
        //            }
        //            else
        //            {
        //                isDivisible = false;
        //                break;
        //            }
        //        }

        //        if (isDivisible)
        //        {
        //            listOfPredicates.Add(i);
        //        }
        //    }

        //    return listOfPredicates;
        //}
    }
}
