using System;

namespace ImplementingList
{
    class Program
    {
        static void Main(string[] args)
        {
            var stack = new CustomStack();

            stack.Push(100);
            stack.Push(200);
            stack.Push(300);
            stack.Push(400);
            stack.Push(500);

            stack.Pop();
            stack.Pop();

            Console.WriteLine($"{stack.Pop()}, {stack.Peek()}");
        }
    }
}
