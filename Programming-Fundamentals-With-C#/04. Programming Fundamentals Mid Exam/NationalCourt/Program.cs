using System;

namespace NationalCourt
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstEmployee = int.Parse(Console.ReadLine());
            int secondEmployee = int.Parse(Console.ReadLine());
            int thirdEmployee = int.Parse(Console.ReadLine());
            int totalPeopleCount = int.Parse(Console.ReadLine());

            int hours = 0;

            while (totalPeopleCount > 0)
            {
                hours++;

                if (hours % 4 == 0 && hours != 0)
                {
                    hours++;
                    continue;
                }
                else
                {
                    totalPeopleCount -= firstEmployee + secondEmployee + thirdEmployee;
                }
            }

            Console.WriteLine($"Time needed: {hours}h.");
        }
    }
}
