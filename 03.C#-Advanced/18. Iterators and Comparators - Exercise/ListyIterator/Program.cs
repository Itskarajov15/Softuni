using System;
using System.Collections.Generic;
using System.Linq;

namespace ListIterator
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Skip(1)
                .ToList();

            var list = new ListyIterator<string>(input);

            string command = Console.ReadLine();

            while (command != "END")
            {
                if (command == "HasNext")
                {
                    Console.WriteLine(list.HasNext());
                }
                else if (command == "Move")
                {
                    Console.WriteLine(list.Move());
                }
                else if (command == "Print")
                {
                    list.Print();
                }

                command = Console.ReadLine();
            }
        }
    }
}
