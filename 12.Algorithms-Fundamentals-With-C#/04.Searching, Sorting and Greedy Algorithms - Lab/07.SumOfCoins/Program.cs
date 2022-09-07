using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;

namespace _07.SumOfCoins
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var coins = new Queue<int>(Console.ReadLine()
                                              .Split(", ")
                                              .Select(int.Parse)
                                              .OrderByDescending(x => x));

            var target = int.Parse(Console.ReadLine());
            var selectedCoins = new Dictionary<int, int>();
            var totalCoins = 0;

            while (target > 0 && coins.Count > 0)
            {
                var coin = coins.Dequeue();
                var count = target / coin;

                if (count <= 0)
                {
                    continue;
                }

                selectedCoins.Add(coin, count);
                totalCoins += count;

                target %= coin;
            }

            if (target == 0)
            {
                Console.WriteLine($"Number of coins to take: {totalCoins}");

                foreach (var item in selectedCoins)
                {
                    Console.WriteLine($"{item.Value} coin(s) with value {item.Key}");
                }
            }
            else
            {
                Console.WriteLine("Error");
            }
        }
    }
}