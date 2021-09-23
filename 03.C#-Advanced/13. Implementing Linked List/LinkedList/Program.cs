using System;

namespace LinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            var linkedList = new SoftuniLinkedList();

            for (int i = 1; i <= 10; i++)
            {
                linkedList.AddFirst(i);
            }

            //for (int i = 1; i <= 10; i++)
            //{
            //    linkedList.AddLast(i);
            //}

            Console.WriteLine($"Count: {linkedList.Count}");

            Console.WriteLine($"Remove first element: {linkedList.RemoveFirst()}");
            Console.WriteLine($"Remove last element: {linkedList.RemoveLast()}");

            linkedList.Foreach(x => Console.WriteLine(x));
        }
    }
}
