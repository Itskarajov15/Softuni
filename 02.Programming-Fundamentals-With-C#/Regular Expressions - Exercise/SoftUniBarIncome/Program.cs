using System;
using System.Text.RegularExpressions;

namespace SoftUniBarIncome
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"^%(?<customer>[A-Z][a-z]+)%[^|$%.]*<(?<product>\w+)>[^|$%.]*\|(?<count>\d+)\|[^|$%.]*?(?<price>\d+\.?\d*)\$$";

            decimal totalIncome = 0;

            string input = Console.ReadLine();

            while (input != "end of shift")
            {
                Match infoAboutPurchase = Regex.Match(input, pattern);

                if (Regex.IsMatch(input, pattern))
                {
                    string customerName = infoAboutPurchase.Groups["customer"].Value;
                    string product = infoAboutPurchase.Groups["product"].Value;
                    int quantity = int.Parse(infoAboutPurchase.Groups["count"].Value);
                    decimal price = decimal.Parse(infoAboutPurchase.Groups["price"].Value);

                    decimal currPrice = price * quantity;
                    totalIncome += currPrice;

                    Console.WriteLine($"{customerName}: {product} - {currPrice:f2}");       
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Total income: {totalIncome:f2}");
        }
    }
}
