using System;
using System.Collections.Generic;
using System.Linq;

namespace KnightGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int sizeOfMatrix = int.Parse(Console.ReadLine());

            int[,] matrix = new int[sizeOfMatrix, sizeOfMatrix];

            FillingTheMatrix(matrix);

            List<string> bombs = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            Explosion(bombs, matrix);

            int aliveCells = 0;
            int sum = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] > 0)
                    {
                        aliveCells++;
                        sum += matrix[row, col];
                    }
                }
            }

            Console.WriteLine($"Alive cells: {aliveCells}");
            Console.WriteLine($"Sum: {sum}");

            PrintMatrix(matrix);
        }

        static void PrintMatrix(int[,] matrix)
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

        static void Explosion(List<string> bombs, int[,] matrix)
        {
            for (int i = 0; i < bombs.Count; i++)
            {
                List<int> currBomb = bombs[i]
                        .Split(",", StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToList();

                int bombRow = currBomb[0];
                int bombCol = currBomb[1];

                int bombPower = matrix[bombRow, bombCol];

                if (matrix[bombRow, bombCol] <= 0)
                {
                    continue;
                }
                else
                {
                    if (IsToExplode(bombRow - 1, bombCol - 1, matrix))
                    {
                        matrix[bombRow - 1, bombCol - 1] -= bombPower;
                    }

                    if (IsToExplode(bombRow - 1, bombCol, matrix))
                    {
                        matrix[bombRow - 1, bombCol] -= bombPower;
                    }

                    if (IsToExplode(bombRow - 1, bombCol + 1, matrix))
                    {
                        matrix[bombRow - 1, bombCol + 1] -= bombPower;
                    }

                    if (IsToExplode(bombRow, bombCol - 1, matrix))
                    {
                        matrix[bombRow, bombCol - 1] -= bombPower;
                    }

                    if (IsToExplode(bombRow, bombCol + 1, matrix))
                    {
                        matrix[bombRow, bombCol + 1] -= bombPower;
                    }

                    if (IsToExplode(bombRow + 1, bombCol - 1, matrix))
                    {
                        matrix[bombRow + 1, bombCol - 1] -= bombPower;
                    }

                    if (IsToExplode(bombRow + 1, bombCol, matrix))
                    {
                        matrix[bombRow + 1, bombCol] -= bombPower;
                    }

                    if (IsToExplode(bombRow + 1, bombCol + 1, matrix))
                    {
                        matrix[bombRow + 1, bombCol + 1] -= bombPower;
                    }

                    matrix[bombRow, bombCol] = 0;
                }

            }
        }

        static int[] ReadIntArrayFromTheConsole()
        {
            return Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }

        static void FillingTheMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] currRow = ReadIntArrayFromTheConsole();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = currRow[col];
                }
            }
        }

        static bool IsToExplode(int bombRow, int bombCol, int[,] matrix)
        {
            return bombRow >= 0 && bombRow < matrix.GetLength(0) && bombCol >= 0 && bombCol < matrix.GetLength(1) && matrix[bombRow, bombCol] > 0;
        }
    }
}
