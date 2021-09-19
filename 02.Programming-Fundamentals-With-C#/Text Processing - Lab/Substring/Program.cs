using System;

namespace Substring
{
    class Program
    {
        static void Main(string[] args)
        {
            string wordToRemove = Console.ReadLine();

            string line = Console.ReadLine();

            while (line.Contains(wordToRemove))
            {
                int index = line.IndexOf(wordToRemove);

                line = line.Remove(index, wordToRemove.Length);
            }

            //int index = line.IndexOf(wordToRemove);

            //while (index != -1)
            //{
            //    line = line.Remove(index, wordToRemove.Length);

            //    index = line.IndexOf(wordToRemove);
            //}

            Console.WriteLine(line);
        }
    }
}
