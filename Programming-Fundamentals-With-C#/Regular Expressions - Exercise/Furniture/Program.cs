using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Furniture
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"^>>([A-Za-z]+)<<([0-9]+\.{0,1}[0-9]{0,})!([0-9]+)";

            List<string> boughtItems = new List<string>();

            decimal totalMoneySpend = 0;

            string input = Console.ReadLine();

            Console.WriteLine("Bought furniture:");

            while (input != "Purchase")
            {
                Match items = Regex.Match(input, pattern);

                if (!items.Success)
                {
                    input = Console.ReadLine();
                    continue;
                }
                else
                {
                    string name = items.Groups[1].Value;
                    decimal price = decimal.Parse(items.Groups[2].Value);
                    int quantity = int.Parse(items.Groups[3].Value);

                    Console.WriteLine(name);

                    totalMoneySpend += price * quantity;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Total money spend: {totalMoneySpend:f2}");
        }
    }
}
