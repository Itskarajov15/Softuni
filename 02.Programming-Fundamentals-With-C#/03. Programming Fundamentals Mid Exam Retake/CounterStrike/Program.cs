using System;

namespace CounterStrike
{
    class Program
    {
        static void Main(string[] args)
        {
            int initialEnergy = int.Parse(Console.ReadLine());

            int numberOfWins = 0;

            string command = Console.ReadLine();

            while (command != "End of battle")
            {
                int distance = int.Parse(command);

                if (initialEnergy >= distance)
                {
                    numberOfWins++;
                    initialEnergy -= distance;

                    if (numberOfWins % 3 == 0)
                    {
                        initialEnergy += numberOfWins;
                    }
                }
                else
                {
                    Console.WriteLine($"Not enough energy! Game ends with {numberOfWins} won battles and {initialEnergy} energy");
                    return;
                }


                command = Console.ReadLine();
            }


            Console.WriteLine($"Won battles: {numberOfWins}. Energy left: {initialEnergy}");
        }
    }
}
