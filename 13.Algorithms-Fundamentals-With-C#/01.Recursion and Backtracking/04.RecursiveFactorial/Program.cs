using System;

namespace _04.RecursiveFactorial
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var factorial = int.Parse(Console.ReadLine());

            Console.WriteLine(CalculateFactorial(factorial));
        }

        private static int CalculateFactorial(int factorial)
        {
            if (factorial <= 1)
            {
                return 1;
            }

            return factorial * CalculateFactorial(factorial - 1);
        }
    }
}