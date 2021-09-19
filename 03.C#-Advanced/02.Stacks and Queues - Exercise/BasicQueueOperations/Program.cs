using System;
using System.Collections.Generic;
using System.Linq;

namespace BasicQueueOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> commands = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            List<int> numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            int elementsToEnqueue = commands[0];
            int elementsToDequeue = commands[1];
            int elementsToLookFor = commands[2];

            Queue<int> intQueue = new Queue<int>(elementsToEnqueue);

            EnqueueElements(intQueue, elementsToEnqueue, numbers);
            DequeueElements(intQueue, elementsToDequeue);
            Checks(intQueue, elementsToLookFor);
        }

        static void Checks(Queue<int> intQueue, int elementsToLookFor)
        {
            if (intQueue.Any())
            {
                if (intQueue.Contains(elementsToLookFor))
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine(intQueue.Min());
                }
            }
            else
            {
                Console.WriteLine(0);
            }
        }

        static void DequeueElements(Queue<int> intQueue, int elementsToDequeue)
        {
            for (int i = 0; i < elementsToDequeue; i++)
            {
                intQueue.Dequeue();
            }
        }

        static void EnqueueElements(Queue<int> intQueue, int elementsToEnqueue, List<int> numbers)
        {
            for (int i = 0; i < elementsToEnqueue; i++)
            {
                intQueue.Enqueue(numbers[i]);
            }
        }
    }
}
