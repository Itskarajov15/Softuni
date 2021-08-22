using System;
using System.Text;

namespace LettersChangeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            double result = 0d;

            string[] parts = input
             .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < parts.Length; i++)
            {
                result = ReturnSumFromMathematicalOperations(parts, i, result);
            }

            Console.WriteLine($"{result:f2}");
        }

        static double ReturnSumFromMathematicalOperations(string[] parts, int i, double result)
        {
            double sum = 0d;

            string currentPart = parts[i];

            char firstSymbol = char.Parse(currentPart[0].ToString());
            double number = int.Parse(currentPart.Substring(1, currentPart.Length - 2));
            char secondLetter = char.Parse(currentPart[currentPart.Length - 1].ToString());

            sum = ReturnResultFromTheFirstLetter(firstSymbol, number);

            sum = ReturnResultFromTheSecondLetter(secondLetter, number, sum); // 2,134.125

            return sum + result;
        }

        static double ReturnResultFromTheSecondLetter(char secondLetter, double number, double result)
        {
            if (Char.IsUpper(secondLetter))
            {
                result -= secondLetter - 64;
            }
            else
            {
                result += secondLetter - 96;
            }

            return result;
        }

        static double ReturnResultFromTheFirstLetter(char firstSymbol, double number)
        {
            double result = 0d;

            if (Char.IsUpper(firstSymbol))
            {
                result += number / (firstSymbol - 64);
            }
            else
            {
                result += number * (firstSymbol - 96);
            }

            return result;
        }
    }
}
