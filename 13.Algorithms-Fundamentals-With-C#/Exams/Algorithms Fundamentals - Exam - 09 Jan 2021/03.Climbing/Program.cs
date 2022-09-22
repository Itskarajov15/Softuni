using System;
using System.Collections.Generic;
using System.Linq;

namespace Climbing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var rows = int.Parse(Console.ReadLine());
            var cols = int.Parse(Console.ReadLine());

            var matrix = new int[rows, cols];

            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                var rowElements = Console.ReadLine()
                                         .Split()
                                         .Select(int.Parse)
                                         .ToArray();

                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    matrix[r, c] = rowElements[c];
                }
            }

            var dp = new int[rows, cols];
            dp[0, 0] = matrix[0, 0];

            for (int r = 1; r < rows; r++)
            {
                dp[r, 0] = dp[r - 1, 0] + matrix[r, 0];
            }

            for (int c = 1; c < cols; c++)
            {
                dp[0, c] = dp[0, c - 1] + matrix[0, c];
            }

            for (int r = 1; r < rows; r++)
            {
                for (int c = 1; c < cols; c++)
                {
                    dp[r, c] = Math.Max(dp[r, c - 1], dp[r - 1, c]) + matrix[r, c];
                }
            }

            var row = rows - 1;
            var col = cols - 1;

            var path = new List<int>();
            path.Add(matrix[row, col]);

            while (row > 0 && col > 0)
            {
                var upper = dp[row - 1, col];
                var left = dp[row, col - 1];

                if (upper > left)
                {
                    path.Add(matrix[row - 1, col]);
                    row--;
                }
                else
                {
                    path.Add(matrix[row, col - 1]);
                    col--;
                }
            }

            while (row > 0)
            {
                path.Add(matrix[row - 1, col]);
                row--;
            }

            while (col > 0)
            {
                path.Add(matrix[row, col - 1]);
                col--;
            }

            Console.WriteLine(dp[rows - 1, cols - 1]);
            Console.WriteLine(String.Join(" ", path));
        }
    }
}