using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Time
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var firstNumbers = Console.ReadLine()
                                      .Split()
                                      .Select(int.Parse)
                                      .ToArray();

            var secondNumbers = Console.ReadLine()
                                       .Split()
                                       .Select(int.Parse)
                                       .ToArray();

            var matrix = new int[firstNumbers.Length + 1, secondNumbers.Length + 1];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                matrix[row, 0] = 0;
            }

            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                matrix[0, col] = 0;
            }

            for (int row = 1; row < matrix.GetLength(0); row++)
            {
                for (int col = 1; col < matrix.GetLength(1); col++)
                {
                    if (firstNumbers[row - 1] == secondNumbers[col - 1])
                    {
                        matrix[row, col] = matrix[row - 1, col - 1] + 1;
                    }
                    else
                    {
                        matrix[row, col] = Math.Max(matrix[row - 1, col], matrix[row, col - 1]);
                    }
                }
            }

            var path = new Stack<int>();
            var rows = firstNumbers.Length;
            var cols = secondNumbers.Length;

            while (rows > 0 && cols > 0)
            {
                if (firstNumbers[rows - 1] == secondNumbers[cols - 1])
                {
                    path.Push(firstNumbers[rows - 1]);
                    rows--;
                    cols--;
                }
                else if (matrix[rows, cols - 1] >= matrix[rows - 1, cols])
                {
                    cols--;
                }
                else
                {
                    rows--;
                }
            }

            Console.WriteLine(String.Join(" ", path));
            Console.WriteLine(matrix[firstNumbers.Length, secondNumbers.Length]);
        }
    }
}