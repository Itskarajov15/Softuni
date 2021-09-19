using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonDon_tGo
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            List<int> removedElements = new List<int>();          

            while (true)
            {
                int index = int.Parse(Console.ReadLine());

                if (index < 0)
                {
                    int firstElement = numbers[0];
                    int lastElement = numbers[numbers.Count - 1];
                    removedElements.Add(firstElement);
                    numbers[0] = lastElement;

                    numbers = IncreasingOrDecreasingNumbersInTheList(numbers, firstElement);
                }
                else if (index >= numbers.Count)
                {
                    int firstElement = numbers[0];
                    int lastElement = numbers[numbers.Count - 1];
                    removedElements.Add(lastElement);
                    numbers[numbers.Count - 1] = firstElement;

                    numbers = IncreasingOrDecreasingNumbersInTheList(numbers, lastElement);
                }
                else
                {
                    int currentNumber = numbers[index];
                    numbers.RemoveAt(index);
                    removedElements.Add(currentNumber);

                    numbers = IncreasingOrDecreasingNumbersInTheList(numbers, currentNumber);
                }

                if (numbers.Count <= 0)
                {
                    break;
                }
            }

            int sum = removedElements.Sum();

            Console.WriteLine(sum);
        }

        static List<int> IncreasingOrDecreasingNumbersInTheList(List<int> numbers, int currentNumber)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] <= currentNumber)
                {
                    numbers[i] += currentNumber;
                }
                else
                {
                    numbers[i] -= currentNumber;
                }
            }

            return numbers;
        }
    }
}
