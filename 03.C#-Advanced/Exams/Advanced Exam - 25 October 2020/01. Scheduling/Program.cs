using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Scheduling
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> tasks = new Stack<int>(ReadArray());

            var threadsInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> threads = new Queue<int>(threadsInput);

            var taskToBeKilled = int.Parse(Console.ReadLine());
            var isFound = false;

            while (true)
            {
                if (tasks.Peek() == taskToBeKilled)
                {
                    isFound = true;
                    break;
                }

                if (threads.Peek() >= tasks.Peek())
                {
                    threads.Dequeue();
                    tasks.Pop();
                }
                else
                {
                    threads.Dequeue();
                }
            }

            if (isFound)
            {
                Console.WriteLine($"Thread with value {threads.Peek()} killed task {taskToBeKilled}");
                Console.WriteLine(String.Join(" ", threads));
            }
        }

        private static int[] ReadArray()
        {
            return Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }
    }
}
