using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace testing
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"^%(?<customer>[A-Z][a-z]+)%[^|$%.]*<(?<product>[A-Za-z]+)>[^|$%.]*\|(?<count>[0-9]+)\|[^|$%.]*?(?<price>[0-9]+\.?[0-9]*)\$$";

            decimal finalPrice = 0;

            string input = Console.ReadLine();

            while (input != "end of shift")
            {
                Match match = Regex.Match(input, pattern);

                if (Regex.IsMatch(input, pattern))
                {
                    string customer = match.Groups["customer"].Value;
                    string product = match.Groups["product"].Value;
                    int count = int.Parse(match.Groups["count"].Value);
                    decimal price = decimal.Parse(match.Groups["price"].Value);

                    decimal currPrice = count * price;

                    finalPrice += currPrice;

                    Console.WriteLine($"{customer}: {product} - {currPrice:f2}");
                }               

                input = Console.ReadLine();
            }

            Console.WriteLine($"Total income: {finalPrice:f2}");
        }
    }
}
