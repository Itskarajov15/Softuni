using System;

namespace DateModifier
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstDate = Console.ReadLine();
            string secondDate = Console.ReadLine();

            int diff = DateModifier.GetDiffBetweenDates(firstDate, secondDate);

            Console.WriteLine(Math.Abs(diff));
        }
    }
}
