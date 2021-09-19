using System;
using System.Linq;

namespace SquareWithMaximumSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSize = ReadArrayFromTheConsole();

            int[,] matrix = new int[matrixSize[0], matrixSize[1]];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] array = ReadArrayFromTheConsole();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = array[col];
                }
            }

            int bestSum = int.MinValue;
            int bestRow = 0;
            int bestCol = 0;

            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    int sum = 0;

                    sum = matrix[row, col] + matrix[row + 1, col] + matrix[row, col + 1] + matrix[row + 1, col + 1];

                    if (sum > bestSum)
                    {
                        bestSum = sum;
                        bestRow = row;
                        bestCol = col;
                    }
                }
            }

            Console.WriteLine($"{matrix[bestRow, bestCol]} {matrix[bestRow, bestCol + 1]}");
            Console.WriteLine($"{matrix[bestRow + 1, bestCol]} {matrix[bestRow + 1, bestCol + 1]}");
            Console.WriteLine(bestSum);

            //int[,] resultMatrix = new int[2, 2];

            //int rowIndex = 0;

            //for (int row = bestRow; row <= bestRow + 1; row++)
            //{

            //    int colIndex = 0;
            //    for (int col = bestCol; col <= bestCol + 1; col++)
            //    {
            //        resultMatrix[rowIndex, colIndex] = matrix[row, col];
            //        colIndex++;
            //    }

            //    rowIndex++;
            //}

            //for (int row = bestRow; row <= bestRow + 1; row++)
            //{
            //    for (int col = bestCol; col <= bestCol + 1; col++)
            //    {
            //        Console.Write(matrix[row, col] + " ");
            //    }

            //    Console.WriteLine();
            //}

            //Console.WriteLine(bestSum);
        }

        static int[] ReadArrayFromTheConsole()
        {
            return Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }
    }
}
