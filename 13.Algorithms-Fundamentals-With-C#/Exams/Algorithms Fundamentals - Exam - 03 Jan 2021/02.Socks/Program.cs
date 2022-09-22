using System;
using System.Data;
using System.Linq;

namespace _02.Socks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var leftSocks = Console.ReadLine()
                                   .Split()
                                   .Select(int.Parse)
                                   .ToArray();

            var rightSocks = Console.ReadLine()
                                   .Split()
                                   .Select(int.Parse)
                                   .ToArray();

            var matrix = new int[leftSocks.Length + 1, rightSocks.Length + 1];

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
                    if (leftSocks[row - 1] == rightSocks[col - 1])
                    {
                        matrix[row, col] = matrix[row - 1, col - 1] + 1;
                    }
                    else
                    {
                        matrix[row, col] = Math.Max(matrix[row - 1, col], matrix[row, col - 1]);
                    }
                }
            }

            Console.WriteLine(matrix[leftSocks.Length, rightSocks.Length]);
        }
    }
}