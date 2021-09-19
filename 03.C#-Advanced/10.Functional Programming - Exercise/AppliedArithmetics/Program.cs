using System;
using System.Collections.Generic;
using System.Linq;

namespace AppliedArithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            string input = Console.ReadLine();

            Action<List<int>> printCollection = list => Console.WriteLine(String.Join(" ", list));

            while (input != "end")
            {
                if (input == "print")
                {
                    printCollection(numbers);
                }
                else
                {
                    Func<int, int> function =GetFunction(input);

                    numbers = numbers.Select(x => function(x)).ToList();
                }

                input = Console.ReadLine();
            }
        }

        static Func<int, int> GetFunction(string input)
        {
            Func<int, int> function = x => x;

            if (input == "add")
            {
                function = x => x + 1;
            }
            else if (input == "multiply")
            {
                function = x => x * 2;
            }
            else if (input == "subtract")
            {
                function = x => x - 1;
            }

            return function;
        }
    }
}
