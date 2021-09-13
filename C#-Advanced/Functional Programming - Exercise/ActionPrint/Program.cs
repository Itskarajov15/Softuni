using System;

namespace ActionPrint
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Action<string> printNames = name => Console.WriteLine(name);

            foreach (var name in names)
            {
                printNames(name);
            }
        }
    }
}
