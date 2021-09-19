using System;
using System.Text;

namespace CaesarCipher
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            StringBuilder result = new StringBuilder();

            foreach (var item in text)
            {
                char letter = item;

                letter += (char)3;

                result.Append(letter);
            }

            Console.WriteLine(result);
        }
    }
}
