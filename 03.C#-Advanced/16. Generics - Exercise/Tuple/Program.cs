using System;

namespace Tuple
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstTupleDate = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string fullName = $"{firstTupleDate[0]} {firstTupleDate[1]}";
            var firstTuple = new CustomTuple<string, string>(fullName, firstTupleDate[2]);
            Console.WriteLine(firstTuple);

            var secondTupleDate = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var secondTuple = new CustomTuple<string, int>(secondTupleDate[0],
                int.Parse(secondTupleDate[1]));
            Console.WriteLine(secondTuple);

            var thirdTupleDate = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var thirdTuple = new CustomTuple<int, double>(int.Parse(thirdTupleDate[0]),
                double.Parse(thirdTupleDate[1]));
            Console.WriteLine(thirdTuple);
        }
    }
}
