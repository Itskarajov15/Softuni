using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Garden
{
    class Program
    {
        static void Main(string[] args)
        {
            var size = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var matrix = new int[size[0], size[1]];

            var command = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            var listOfCoordinates = new List<int[]>();

            while (command[0] != "Bloom")
            {
                var row = int.Parse(command[0]);
                var col = int.Parse(command[1]);

                if (IsInTheMatrix(row, col, matrix))
                {
                    for (int i = 0; i < matrix.GetLength(0); i++)
                    {
                        for (int j = 0; j < matrix.GetLength(1); j++)
                        {
                            if (i == row || j == col)
                            {
                                matrix[i, j]++;
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Invalid coordinates.");
                }

                command = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }

            PrintMatrix(matrix);
        }

        private static void PrintMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }

                Console.WriteLine();
            }
        }

        private static bool IsInTheMatrix(int row, int col, int[,] matrix)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
        }
    }
}
