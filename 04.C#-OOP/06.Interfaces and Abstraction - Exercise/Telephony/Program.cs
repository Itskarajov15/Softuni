using System;
using System.Linq;

namespace Telephony
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            var urls = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            foreach (var number in numbers)
            {
                try
                {
                    if (!number.All(char.IsDigit))
                    {
                        throw new ArgumentException("Invalid number!");
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }

                if (number.Length == 10)
                {
                    var smartphone = new Smartphone();

                    smartphone.Call(number);
                }
                else if (number.Length == 7)
                {
                    var stationaryPhone = new StationaryPhone();

                    stationaryPhone.Call(number);
                }
            }

            foreach (var url in urls)
            {
                try
                {
                    if (url.Any(char.IsDigit))
                    {
                        throw new ArgumentException("Invalid URL!");
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }

                var smartphone = new Smartphone();

                smartphone.Browse(url);
            }
        }
    }
}
