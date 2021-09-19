using System;

namespace testing
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            int multiplier = int.Parse(Console.ReadLine());

            if (multiplier > 10)
            {
                int result = input * multiplier;

                Console.WriteLine($"{input} X {multiplier} = {result}");
            }
            else
            {
                for (int i = multiplier; i <= 10; i++)
                {
                    int result = input * i;

                    Console.WriteLine($"{input} X {i} = {result}");
                }
            }
        }
    }
}
