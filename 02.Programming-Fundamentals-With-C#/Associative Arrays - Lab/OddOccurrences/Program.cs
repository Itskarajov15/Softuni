using System;
using System.Collections.Generic;
using System.Linq;

namespace OddOccurrences
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> words = new Dictionary<string, int>();

            string[] input = Console.ReadLine()
                .Split();

            foreach (var word in input)
            {
                if (words.ContainsKey(word.ToLower()))
                {
                    words[word.ToLower()] ++;
                }
                else
                {
                    words.Add(word.ToLower(), 1);
                }
            }

            foreach (var word in words)
            {
                if (word.Value % 2 != 0)
                {
                    Console.Write(word.Key + " ");
                }
            }
        }
    }
}
