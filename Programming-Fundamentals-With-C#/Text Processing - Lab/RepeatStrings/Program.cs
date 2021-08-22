using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RepeatStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split();

            StringBuilder result = new StringBuilder();

            //for (int i = 0; i < input.Length; i++)
            //{
            //    int currentLength = input[i].Length;

            //    for (int a = 0; a < currentLength; a++)
            //    {
            //        result += input[i];
            //    }
            //}

            //foreach (var item in input)
            //{
            //    for (int i = 0; i < item.length; i++)
            //    {
            //        result += item;
            //    }
            //}

            foreach (var item in input)
            {
                for (int i = 0; i < item.Length; i++)
                {
                    result.Append(item);
                }
            }

            Console.WriteLine(result);
        }
    }
}
