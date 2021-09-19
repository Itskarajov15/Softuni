using System;
using System.Linq;

namespace AddVAT
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal[] prices = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(decimal.Parse)
                .ToArray();

            prices = Select(prices, x => x * 1.2M);

            foreach (var item in prices)
            {
                Console.WriteLine($"{item:f2}");
            }
        }

        static decimal[] Select(decimal[] prices, Func<decimal, decimal> transformer)
        {
            decimal[] newArray = new decimal[prices.Length];

            for (int i = 0; i < prices.Length; i++)
            {
                newArray[i] = transformer(prices[i]);
            }

            return newArray;
        }
    }
}
