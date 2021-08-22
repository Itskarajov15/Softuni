using System;
using System.Text;
using System.Linq;

namespace DigitsLettersAndOther
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            StringBuilder digits = new StringBuilder();
            StringBuilder letters = new StringBuilder();
            StringBuilder others = new StringBuilder();

            foreach (var character in input)
            {
                if (Char.IsDigit(character))
                {
                    digits.Append(character);
                }
                else if (Char.IsLetter(character))
                {
                    letters.Append(character);
                }
                else
                {
                    others.Append(character);
                }
            }

            Console.WriteLine(digits);
            Console.WriteLine(letters);
            Console.WriteLine(others);
        }
    }
}
