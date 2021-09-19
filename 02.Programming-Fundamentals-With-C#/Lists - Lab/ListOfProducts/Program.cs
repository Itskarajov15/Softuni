using System;
using System.Collections.Generic;
using System.Linq;

namespace SumAdjacentEqualNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<string> products = new List<string>();

            products = ReadProductsFromConsole(n);

            products.Sort();

            PrintProducts(products);
        }

        static List<string> ReadProductsFromConsole(int n)
        {
            List<string> products = new List<string>();

            for (int i = 0; i < n; i++)
            {
                string product = Console.ReadLine();

                products.Add(product);
            }

            return products;
        }

        static void PrintProducts(List<string> products)
        {
            for (int i = 0; i < products.Count; i++)
            {
                Console.WriteLine($"{i + 1}.{products[i]}");
            }
        }
    }
}
