using System;
using System.Collections.Generic;
using System.Linq;

namespace ReverseStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string line = Console.ReadLine();

                if (line == "end")
                {
                    break;
                }

                //char[] reversedLineChars = line.Reverse().ToArray();

                //string reversedLine = new string(reversedLineChars);

                //Console.WriteLine($"{line} = {reversedLine}");

                string reversedLine = String.Empty;

                for (int i = line.Length - 1; i >= 0; i--)
                {
                    reversedLine += line[i];
                }

                Console.WriteLine($"{line} = {reversedLine}");
            }
        }
    }
}
