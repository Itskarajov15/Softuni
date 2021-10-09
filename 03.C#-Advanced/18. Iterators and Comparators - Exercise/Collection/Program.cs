using System;
using System.Linq;
using System.Collections.Generic;

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
                    try
                    {
                        list.Print();
                    }
                    catch (InvalidOperationException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else if (command == "PrintAll")
                {
                    Console.WriteLine(String.Join(" ", list));
                }

                command = Console.ReadLine();
            }
        }
    }
}
