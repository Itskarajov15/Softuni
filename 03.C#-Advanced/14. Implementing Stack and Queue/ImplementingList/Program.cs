using System;

namespace ImplementingList
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = new CustomList();

            for (int i = 1; i <= 3; i++)
            {
                numbers.Add(i);
            }

            numbers.InsertAt(0, 100);
            numbers.InsertAt(1, 200);
            numbers.InsertAt(5, 500);
        }
    }
}
