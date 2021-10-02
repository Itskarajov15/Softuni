using System;
using System.Linq;

namespace SnakeMoves
{
    class Program
    {
        static void Main(string[] args)
        {
            var sizes = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var matrix = new char[sizes[0], sizes[1]];

            bool isLeftToRight = true;
            int counter = 0;

            string snake = Console.ReadLine();

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                if (isLeftToRight)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        matrix[row, col] = snake[counter++];

                        if (counter == snake.Length)
                        {
                            counter = 0;
                        }
                    }

                    isLeftToRight = false;
                }
                else
                {
                    for (int col = matrix.GetLength(1) - 1; col >= 0; col--)
                    {
                        matrix[row, col] = snake[counter++];

                        if (counter == snake.Length)
                        {
                            counter = 0;
                        }
                    }

                    isLeftToRight = true;
                }
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}
