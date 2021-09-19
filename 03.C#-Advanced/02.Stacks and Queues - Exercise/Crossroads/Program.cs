using System;
using System.Collections.Generic;

namespace Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> traficJam = new Queue<string>();

            int totalCarsPassed = 0;

            int durationOfGreenLight = int.Parse(Console.ReadLine());
            int durationOfFreeWindow = int.Parse(Console.ReadLine());

            string input = Console.ReadLine();

            while (input != "END")
            {
                if (input == "green")
                {
                    int greenLight = durationOfGreenLight;
                    int freeWindow = durationOfFreeWindow;

                    while (traficJam.Count > 0 && greenLight > 0)
                    {
                        string currCar = traficJam.Dequeue();

                        greenLight -= currCar.Length;

                        if (greenLight < 0)
                        {
                            int timeWithFreeWindow = greenLight + freeWindow;

                            if (timeWithFreeWindow < 0)
                            {
                                int crashIndex = currCar.Length + timeWithFreeWindow;

                                Console.WriteLine("A crash happened!");

                                Console.WriteLine($"{currCar} was hit at {currCar[crashIndex]}.");

                                return;
                            }
                        }

                        totalCarsPassed++;
                    }
                }
                else
                {
                    traficJam.Enqueue(input);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{totalCarsPassed} total cars passed the crossroads.");
        }
    }
}
