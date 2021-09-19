using System;
using System.Collections.Generic;
using System.Linq;

namespace BombNumbers
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

            int specialNumber = int.Parse(command[0]);
            int power = int.Parse(command[1]);

            numbers = RemoveTheNumbersNearTheSpecialNumber(numbers, specialNumber, power);

            int sum = numbers.Sum();

            Console.WriteLine(sum);
        }

        static List<int> RemoveTheNumbersNearTheSpecialNumber(List<int> numbers, int specialNumber, int power)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] == specialNumber)
                {
                    int start = i - power;
                    int end = i + power;

                    for (int a = start; a <= end; a++)
                    {
                        if (a < 0 || a >= numbers.Count)
                        {
                            continue;
                        }
                        else
                        {
                            numbers[a] = 0;
                        }
                    }
                }
            }

            return numbers;
        }
    }
}
