using System;

namespace ComputerStore
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            decimal priceWithoutTaxes = 0m;
            decimal taxes = 0m;
            decimal totalPrice = 0m;

            while (input != "special" && input != "regular")
            {
                decimal currentPrice = decimal.Parse(input);

                if (currentPrice < 0)
                {
                    Console.WriteLine("Invalid price!");
                }
                else
                {
                    priceWithoutTaxes += currentPrice;
                }

                input = Console.ReadLine();
            }

            taxes = priceWithoutTaxes * 0.2m;

            if (priceWithoutTaxes == 0)
            {
                Console.WriteLine("Invalid order!");
            }
            else
            {
                Console.WriteLine("Congratulations you've just bought a new computer!");
                Console.WriteLine($"Price without taxes: {priceWithoutTaxes:f2}$");
                Console.WriteLine($"Taxes: {taxes:f2}$");
                Console.WriteLine("-----------");

                totalPrice = priceWithoutTaxes + taxes;

                if (input == "special")
                {
                    totalPrice = totalPrice - (totalPrice * 0.1m);
                }

                Console.WriteLine($"Total price: {totalPrice:f2}$");
            }
        }
    }
}
