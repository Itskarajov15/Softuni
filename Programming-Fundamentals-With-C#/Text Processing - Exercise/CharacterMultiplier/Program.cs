using System;

namespace CharacterMultiplier
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string firstText = input[0];
            string secondText = input[1];

            string longerText = ReturnTheLongerText(firstText, secondText);

            int sum = 0;

            for (int i = 0; i < longerText.Length; i++)
            {
                if (i > firstText.Length - 1)
                {
                    sum += secondText[i];
                }
                else if (i > secondText.Length - 1)
                {
                    sum += firstText[i];
                }
                else
                {
                    sum += firstText[i] * secondText[i];
                }
            }

            Console.WriteLine(sum);
        }

        static string ReturnTheLongerText(string firstText, string secondText)
        {
            if (firstText.Length < secondText.Length)
            {
                return secondText;
            }
            else if (firstText.Length > secondText.Length)
            {
                return firstText;
            }
            else
            {
                return firstText;
            }
        }
    }
}
