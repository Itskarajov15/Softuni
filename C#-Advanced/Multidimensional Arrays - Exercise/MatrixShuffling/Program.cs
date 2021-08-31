using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace MatrixShuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sizesOfMatrix = ReadIntegerArrayFromTheConsole();

            string[,] matrix = new String[sizesOfMatrix[0], sizesOfMatrix[1]];

            matrix = FillingTheMatrix(matrix);

            string[] command = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            while (command[0] != "END")
            {
                if (command[0] == "swap" && command.Length == 5)
                {
                    int oldRow = int.Parse(command[1]);
                    int oldCol = int.Parse(command[2]);
                    int newRow = int.Parse(command[3]);
                    int newCol = int.Parse(command[4]);

                    if ((oldRow >= 0 && oldRow < matrix.GetLength(0))
                        && (newRow >= 0 && newRow < matrix.GetLength(0))
                        && (oldCol >= 0 && oldCol < matrix.GetLength(1))
                        && (newCol >= 0 && newCol < matrix.GetLength(1)))
                    {
                        string temp = matrix[oldRow, oldCol];

                        matrix[oldRow, oldCol] = matrix[newRow, newCol];

                        matrix[newRow, newCol] = temp;

                        PrintMatrix(matrix);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input!");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }

                command = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }
        }

        static void PrintMatrix(string[,] matrix)
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

        static string[,] FillingTheMatrix(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] array = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = array[col];
                }
            }

            return matrix;
        }
        static int[] ReadIntegerArrayFromTheConsole()
        {
            return Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }

    }
}
