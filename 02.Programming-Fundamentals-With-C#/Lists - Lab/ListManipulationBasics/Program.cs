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

            while (command[0] != "end")
            {
                if (command[0] == "Add")
                {
                    int number = int.Parse(command[1]);

                    numbers = AddNumbersInTheList(number, numbers);
                }
                else if (command[0] == "Remove")
                {
                    int number = int.Parse(command[1]);

                    numbers = RemoveNumberFromTheList(number, numbers);
                }
                else if (command[0] == "RemoveAt")
                {
                    int index = int.Parse(command[1]);

                    numbers = RemoveNumberAtCurrentIndex(index, numbers);
                }
                else if (command[0] == "Insert")
                {
                    int number = int.Parse(command[1]);
                    int index = int.Parse(command[2]);

                    numbers = InsertNumberAtCurrentIndex(number, index, numbers);
                }

                command = Console.ReadLine()
                    .Split();
            }

            Console.WriteLine(String.Join(" ", numbers));
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
