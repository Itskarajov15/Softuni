using System;
using System.Collections.Generic;

namespace ShoppingSpree
{
    class Program
    {
        static void Main(string[] args)
        {
            var people = new Dictionary<string, Person>();
            var products = new Dictionary<string, Product>();

            try
            {
                people = ReadPeople();
                products = ReadProducts();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            while (true)
            {
                var input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (input[0] == "END")
                {
                    break;
                }

                var personName = input[0];
                var productName = input[1];

                var person = people[personName];
                var product = products[productName];

                try
                {
                    person.BuyAProduct(product);
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            foreach (var person in people.Values)
            {
                Console.WriteLine(person);
            }
        }

        private static Dictionary<string, Product> ReadProducts()
        {
            var result = new Dictionary<string, Product>();

            var parts = Console.ReadLine()
                .Split(";", StringSplitOptions.RemoveEmptyEntries);

            foreach (var part in parts)
            {
                var productData = part
                    .Split("=", StringSplitOptions.RemoveEmptyEntries);

                var name = productData[0];
                var cost = decimal.Parse(productData[1]);

                if (!result.ContainsKey(name))
                {
                    result.Add(name, new Product(name, cost));
                }
            }

            return result;
        }

        private static Dictionary<string, Person> ReadPeople()
        {
            var result = new Dictionary<string, Person>();

            var parts = Console.ReadLine()
                .Split(";", StringSplitOptions.RemoveEmptyEntries);

            foreach (var part in parts)
            {
                var personData = part
                    .Split("=", StringSplitOptions.RemoveEmptyEntries);

                var name = personData[0];
                var money = decimal.Parse(personData[1]);

                if (!result.ContainsKey(name))
                {
                    result.Add(name, new Person(name, money));
                }
            }

            return result;
        }
    }
}
