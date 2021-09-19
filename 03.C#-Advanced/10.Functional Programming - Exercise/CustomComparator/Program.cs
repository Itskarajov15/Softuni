using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomComparator
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            List<int> listOfEvenNumbers = ReturnListOfEvenNumbers(numbers, x => x % 2 == 0);
            List<int> listOfOddNumbers = ReturnListOfEvenNumbers(numbers, x => x % 2 != 0);

            int[] evenNumbers = listOfEvenNumbers.ToArray();
            int[] oddNumbers = listOfOddNumbers.ToArray();

            Array.Sort(evenNumbers);
            Array.Sort(oddNumbers);

            Func<int[], int[], List<int>> returnFinalList = (evenNumbers, oddNumbers) =>
            {
                List<int> result = new List<int>();

                foreach (int currNumber in evenNumbers)
                {
                    result.Add(currNumber);
                }

                foreach (int currNumber in oddNumbers)
                {
                    result.Add(currNumber);
                }

                return result;
            };

            List<int> result = returnFinalList(evenNumbers, oddNumbers);

            Action<List<int>> printList = list => Console.WriteLine(String.Join(" ", list));

            printList(result);
        }

        static List<int> ReturnListOfEvenNumbers(List<int> numbers, Func<int, bool> predicate)
        {
            List<int> listOfEvenNumbers = new List<int>();

            foreach (int currNumber in numbers)
            {
                if (predicate(currNumber))
                {
                    listOfEvenNumbers.Add(currNumber);
                }
            }

            return listOfEvenNumbers;
        }

        static List<int> ReturnListOfOddNumbers(List<int> numbers, Func<int, bool> predicate)
        {
            List<int> listOfOddNumbers = new List<int>();

            foreach (int currNumber in numbers)
            {
                if (predicate(currNumber))
                {
                    listOfOddNumbers.Add(currNumber);
                }
            }

            return listOfOddNumbers;
        }
    }
}
