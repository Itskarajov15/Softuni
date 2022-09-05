using System;
using System.Linq;

namespace _04.Cinema
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var names = Console.ReadLine()
                               .Split(", ")
                               .ToList();

            var input = Console.ReadLine();

            while (input != "generate")
            {
                var splitedInput = input.Split(" - ").ToArray();

                input = Console.ReadLine();
            }
        }
    }
}