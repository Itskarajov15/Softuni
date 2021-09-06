using System;
using System.Collections.Generic;
using System.Linq;

namespace EvenTimes
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, int> numbers = new Dictionary<int, int>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());

                if (!numbers.ContainsKey(number))
                {
                    numbers.Add(number, 0);
                }

                numbers[number]++;
            }

            numbers = numbers
                .Where(x => x.Value % 2 == 0)
                .ToDictionary(x => x.Key, x => x.Value);

            Console.WriteLine(numbers.First().Key);

            //foreach (var number in numbers)
            //{
            //    if (number.Value % 2 == 0)
            //    {
            //        Console.WriteLine(number.Key);
            //    }
            //}
        }
    }
}
