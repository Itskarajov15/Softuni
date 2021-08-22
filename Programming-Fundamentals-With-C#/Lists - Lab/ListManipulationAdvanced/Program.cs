using System;
using System.Collections.Generic;
using System.Linq;

namespace SumAdjacentEqualNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            string[] command = Console.ReadLine()
                .Split();

            bool isChanged = false;

            while (command[0] != "end")
            {
                if (command[0] == "Add")
                {
                    int number = int.Parse(command[1]);

                    numbers = AddNumbersInTheList(number, numbers);

                    isChanged = true;
                }
                else if (command[0] == "Remove")
                {
                    int number = int.Parse(command[1]);

                    numbers = RemoveNumberFromTheList(number, numbers);

                    isChanged = true;
                }
                else if (command[0] == "RemoveAt")
                {
                    int index = int.Parse(command[1]);

                    numbers = RemoveNumberAtCurrentIndex(index, numbers);

                    isChanged = true;
                }
                else if (command[0] == "Insert")
                {
                    int number = int.Parse(command[1]);
                    int index = int.Parse(command[2]);

                    numbers = InsertNumberAtCurrentIndex(number, index, numbers);

                    isChanged = true;
                }
                else if (command[0] == "Contains")
                {
                    int number = int.Parse(command[1]);

                    string result = CheckIfTheListContainsCurrentNumber(number, numbers);

                    Console.WriteLine(result);
                }
                else if (command[0] == "PrintEven")
                {
                    List<int> result = new List<int>();

                    result = FindAllEvenOrOddNumbersInTheList(numbers, 0);

                    Console.WriteLine(String.Join(" ", result));
                }
                else if (command[0] == "PrintOdd")
                {
                    List<int> result = new List<int>();

                    result = FindAllEvenOrOddNumbersInTheList(numbers, 1);

                    Console.WriteLine(String.Join(" ", result));
                }
                else if (command[0] == "GetSum")
                {
                    int sum = numbers.Sum();

                    Console.WriteLine(sum);
                }
                else if (command[0] == "Filter")
                {
                    string condition = command[1];
                    int number = int.Parse(command[2]);

                    List<int> result = new List<int>();

                    result = FulfillGivenCondition(condition, number, numbers);

                    Console.WriteLine(String.Join(" ", result));
                }

                command = Console.ReadLine()
                    .Split();
            }

            if (isChanged)
            {
                Console.WriteLine(String.Join(" ", numbers));
            }
        }

        static List<int> FulfillGivenCondition(string condition, int number, List<int> numbers)
        {
            List<int> result = new List<int>();

            if (condition == "<")
            {
                for (int i = 0; i < numbers.Count; i++)
                {
                    if (numbers[i] < number)
                    {
                        result.Add(numbers[i]);
                    }
                }
            }
            else if (condition == ">")
            {
                for (int i = 0; i < numbers.Count; i++)
                {
                    if (numbers[i] > number)
                    {
                        result.Add(numbers[i]);
                    }
                }
            }
            else if (condition == ">=")
            {
                for (int i = 0; i < numbers.Count; i++)
                {
                    if (numbers[i] >= number)
                    {
                        result.Add(numbers[i]);
                    }
                }
            }
            else if (condition == "<=")
            {
                for (int i = 0; i < numbers.Count; i++)
                {
                    if (numbers[i] <= number)
                    {
                        result.Add(numbers[i]);
                    }
                }
            }

            return result;
        }

        static List<int> FindAllEvenOrOddNumbersInTheList(List<int> numbers, int divisionResult)
        {
            List<int> result = new List<int>();

            for (int i = 0; i < numbers.Count; i++)
            {
                int currentNumber = numbers[i];

                if (currentNumber % 2 == divisionResult)
                {
                    result.Add(currentNumber);
                }
            }

            return result;
        }

        static string CheckIfTheListContainsCurrentNumber(int number, List<int> numbers)
        {
            string result = string.Empty;

            if (numbers.Contains(number))
            {
                result = "Yes";
            }
            else
            {
                result = "No such number";
            }

            return result;
        }

        static List<int> InsertNumberAtCurrentIndex(int number, int index, List<int> numbers)
        {
            numbers.Insert(index, number);

            return numbers;
        }

        static List<int> RemoveNumberAtCurrentIndex(int index, List<int> numbers)
        {
            numbers.RemoveAt(index);

            return numbers;
        }

        static List<int> RemoveNumberFromTheList(int number, List<int> numbers)
        {
            numbers.Remove(number);

            return numbers;
        }

        static List<int> AddNumbersInTheList(int number, List<int> numbers)
        {
            numbers.Add(number);

            return numbers;
        }
    }
}
