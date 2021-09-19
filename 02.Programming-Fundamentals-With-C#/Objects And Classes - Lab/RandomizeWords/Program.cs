using System;

namespace RandomizeWords
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine()
                .Split();

            Random random = new Random();

            for (int i = 0; i < words.Length; i++)
            {
                int randomNumber = random.Next(words.Length);

                string temp = words[i];
                words[i] = words[randomNumber];
                words[randomNumber] = temp;
            }

            Console.WriteLine(String.Join(Environment.NewLine, words));
        }
    }
}
