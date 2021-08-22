using System;
using System.Collections.Generic;
using System.Linq;

namespace Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, decimal> priceByProduct = new Dictionary<string, decimal>();

            Dictionary<string, int> quantityByProduct = new Dictionary<string, int>();

            string[] input = Console.ReadLine()
                .Split();

            while (input[0] != "buy")
            {
                string product = input[0];
                decimal price = decimal.Parse(input[1]);
                int quantity = int.Parse(input[2]);

                if (priceByProduct.ContainsKey(product))
                {
                    priceByProduct[product] = price;
                    quantityByProduct[product] += quantity;
                }
                else
                {
                    priceByProduct.Add(product, price);
                    quantityByProduct.Add(product, quantity);
                }

                input = Console.ReadLine()
                .Split();
            }

            foreach (var kvp in priceByProduct)
            {
                string product = kvp.Key;
                decimal price = kvp.Value;
                int quantity = quantityByProduct[product];

                decimal totalPrice = price * quantity;
                
                Console.WriteLine($"{product} -> {totalPrice:f2}");
            }
        }
    }
}

