using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.WarmWinter
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> sets = new List<int>();

            int[] hats = ReadingArrayFromTheConsole();
            int[] scarfs = ReadingArrayFromTheConsole();

            var stackOfHats = new Stack<int>(hats);
            var queueOfScarfs = new Queue<int>(scarfs);

            while (stackOfHats.Count > 0 && queueOfScarfs.Count > 0)
            {
                if (stackOfHats.Peek() > queueOfScarfs.Peek())
                {
                    sets.Add(stackOfHats.Pop() + queueOfScarfs.Dequeue());
                }
                else if (stackOfHats.Peek() == queueOfScarfs.Peek())
                {
                    queueOfScarfs.Dequeue();
                    int currHat = stackOfHats.Pop() + 1;

                    stackOfHats.Push(currHat);

                    for (int i = 0; i < stackOfHats.Count; i++)
                    {
                        stackOfHats.Push(stackOfHats.Pop());
                    }
                }
                else if (stackOfHats.Peek() < queueOfScarfs.Peek())
                {
                    stackOfHats.Pop();
                }
            }

            Console.WriteLine($"The most expensive set is: {sets.OrderByDescending(x => x).FirstOrDefault()}");

            Console.WriteLine(String.Join(" ", sets));
        }

        static int[] ReadingArrayFromTheConsole()
        {
            return Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }
    }
}
