using System;
using System.Text;

namespace MultiplyBigNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            byte multiplier = byte.Parse(Console.ReadLine());

            if (multiplier == 0 || input == "0")
            {
                Console.WriteLine(0);
                return;
            }

            int reminder = 0;

            StringBuilder finalSum = new StringBuilder();

            for (int i = input.Length - 1; i >= 0; i--)
            {
                int currentDigit = int.Parse(input[i].ToString());

                int product = currentDigit * multiplier + reminder;

                int result = product % 10;

                reminder = product / 10;

                finalSum.Insert(0, result);
            }

            if (reminder > 0)
            {
                finalSum.Insert(0, reminder);
            }

            Console.WriteLine(finalSum);
        }
    }
}
