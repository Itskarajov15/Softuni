using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01._FoodFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<char> vowels = new Queue<char>(ReadCharArray());
            Stack<char> consonants = new Stack<char>(ReadCharArray());

            string flour = String.Empty;
            string pork = String.Empty;
            string olive = String.Empty;
            string pear = String.Empty;

            while (consonants.Count > 0)
            {
                char currVowel = vowels.Peek();
                char currConsonant = consonants.Peek();

                if ("flour".Contains(currVowel) && !flour.Contains(currVowel))
                {
                    flour += currVowel;
                }

                if ("flour".Contains(currConsonant) && !flour.Contains(currConsonant))
                {
                    flour += currConsonant;
                }

                if ("pork".Contains(currVowel) && !pork.Contains(currVowel))
                {
                    pork += currVowel;
                }

                if ("pork".Contains(currConsonant) && !pork.Contains(currConsonant))
                {
                    pork += currConsonant;
                }

                if ("olive".Contains(currVowel) && !olive.Contains(currVowel))
                {
                    olive += currVowel;
                }

                if ("olive".Contains(currConsonant) && !olive.Contains(currConsonant))
                {
                    olive += currConsonant;
                }

                if ("pear".Contains(currVowel) && !pear.Contains(currVowel))
                {
                    pear += currVowel;
                }

                if ("pear".Contains(currConsonant) && !pear.Contains(currConsonant))
                {
                    pear += currConsonant;
                }

                vowels.Enqueue(vowels.Dequeue());
                consonants.Pop();
            }

            var listOfWords = new List<string>();

            if (flour.Length == "flour".Length)
            {
                listOfWords.Add("flour");
            }

            if (pork.Length == "pork".Length)
            {
                listOfWords.Add("pork");
            }

            if (olive.Length == "olive".Length)
            {
                listOfWords.Add("olive");
            }

            if (pear.Length == "pear".Length)
            {
                listOfWords.Add("pear");
            }

            Console.WriteLine($"Words found: {listOfWords.Count}");

            for (int i = 0; i < listOfWords.Count; i++)
            {
                var currWord = String.Empty;

                if (listOfWords.Contains("pear"))
                {
                    Console.WriteLine("pear");
                    listOfWords.Remove("pear");
                }
                else if (listOfWords.Contains("flour"))
                {
                    Console.WriteLine("flour");
                    listOfWords.Remove("flour");
                }
                else if (listOfWords.Contains("pork"))
                {
                    Console.WriteLine("pork");
                    listOfWords.Remove("pork");
                }
                else
                {
                    Console.WriteLine("olive");
                    listOfWords.Remove("olive");
                }

                i--;
            }
        }

        private static char[] ReadCharArray()
        {
            return Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(char.Parse)
                .ToArray();
        }
    }
}
