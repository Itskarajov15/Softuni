using System;

namespace _01._Problem
{
    class Program
    {
        static void Main(string[] args)
        {
            double expForTheTank = double.Parse(Console.ReadLine());
            short countOfBattles = short.Parse(Console.ReadLine());

            double expOfPlayer = 0d;
            bool isEnough = false;
            int count = 0;

            for (int i = 1; i <= countOfBattles; i++)
            {
                double currExp = double.Parse(Console.ReadLine());

                count++;

                expOfPlayer += currExp;

                if (i % 3 == 0)
                {
                    expOfPlayer += currExp * 0.15;
                }
                
                if (i % 5 == 0)
                {
                    expOfPlayer -= (currExp * 0.1);
                }

                if (i % 15 == 0)
                {
                    expOfPlayer += currExp * 0.05;
                }

                if (expOfPlayer >= expForTheTank)
                {
                    isEnough = true;
                    break;
                }
            }

            if (isEnough)
            {
                Console.WriteLine($"Player successfully collected his needed experience for {count} battles.");
            }
            else
            {
                double neededExp = expForTheTank - expOfPlayer;
                Console.WriteLine($"Player was not able to collect the needed experience, {neededExp:f2} more needed.");
            }
        }
    }
}
