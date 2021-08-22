using System;
using System.Collections.Generic;
using System.Linq;

namespace Train
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> wagons = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            int capacity = int.Parse(Console.ReadLine());

            string[] command = Console.ReadLine()
                .Split();

            while (command[0] != "end")
            {
                if (command[0] == "Add")
                {
                    int numberOfPassengers = int.Parse(command[1]);

                    wagons = AddNewWagonWithPeople(wagons, numberOfPassengers);
                }
                else
                {
                    int passengers = int.Parse(command[0]);

                    wagons = FitPassengersInWagons(wagons, passengers, capacity);
                }

                command = Console.ReadLine()
                .Split();
            }

            Console.WriteLine(String.Join(" ", wagons));
        }

        static List<int> FitPassengersInWagons(List<int> wagons, int passengers, int capacity)
        {
            for (int i = 0; i < wagons.Count; i++)
            {
                wagons[i] += passengers;

                if (wagons[i] > capacity)
                {
                    wagons[i] -= passengers;
                }
                else
                {
                    break;
                }
            }

            return wagons;
        }

        static List<int> AddNewWagonWithPeople(List<int> wagons, int numberOfPassengers)
        {
            wagons.Add(numberOfPassengers);

            return wagons;
        }
    }
}
