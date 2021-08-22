using System;
using System.Collections.Generic;
using System.Linq;

namespace ListOperations
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

            while (command[0] != "End")
            {
                if (command[0] == "Add")
                {
                    int number = int.Parse(command[1]);

                    numbers.Add(number);
                }
                else if (command[0] == "Insert")
                {
                    int number = int.Parse(command[1]);
                    int index = int.Parse(command[2]);

                    if (index < 0 || index >= numbers.Count)
                    {
                        Console.WriteLine("Invalid index");
                    }
                    else
                    {
                        numbers.Insert(index, number);
                    }
                }
                else if (command[0] == "Remove")
                {
                    int index = int.Parse(command[1]);

                    if (index < 0 || index >= numbers.Count)
                    {
                        Console.WriteLine("Invalid index");
                    }
                    else
                    {
                        numbers.RemoveAt(index);                       
                    }
                }
                else if (command[0] == "Shift")
                {
                    int count = int.Parse(command[2]);

                    if (command[1] == "left")
                    {
                        numbers = ShiftFirstNumberNTimes(numbers, count);
                    }
                    else if (command[1] == "right")
                    {
                        numbers = ShiftLastNumberNTimes(numbers, count);
                    }
                }

                command = Console.ReadLine()
                .Split();
            }

            Console.WriteLine(String.Join(" ", numbers));
        }

        static List<int> ShiftFirstNumberNTimes(List<int> numbers, int count)
        {
            for (int i = 0; i < count % numbers.Count; i++)
            {
                int firstNumber = numbers[0];
                numbers.RemoveAt(0);
                numbers.Add(firstNumber);
            }

            return numbers;
        }

        static List<int> ShiftLastNumberNTimes(List<int> numbers, int count)
        {
            for (int i = 0; i < count % numbers.Count; i++)
            {
                int lastNumber = numbers[numbers.Count - 1];
                numbers.RemoveAt(numbers.Count - 1);
                numbers.Insert(0, lastNumber);
            }

            return numbers;
        }
    }
}
