using System;
using System.Linq;

namespace SumNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintSumAndCount(int.Parse
                , array => array.Length
                , array =>
                {
                    int sum = 0;

                    foreach (var item in array)
                    {
                        sum += item;
                    }

                    return sum;
                });
        }

        static void PrintSumAndCount(Func<string, int> parser,
            Func<int[], int> countGetter,
            Func<int[], int> sumGetter)
        {
            int[] numbers = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(parser)
                .ToArray();

            Console.WriteLine(countGetter(numbers));
            Console.WriteLine(sumGetter(numbers));
        }
    }
}
