using System;

namespace _02._Bee
{
    class Program
    {
        static void Main(string[] args)
        {
            var sizeOfMatrix = int.Parse(Console.ReadLine());

            var matrix = new char[sizeOfMatrix, sizeOfMatrix];

            var beeRow = 0;
            var beeCol = 0;
            var countOfPollinatedFlowers = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] input = Console.ReadLine().ToCharArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];

                    if (matrix[row, col] == 'B')
                    {
                        beeRow = row;
                        beeCol = col;
                    }
                }
            }

            var command = Console.ReadLine();

            while (command != "End")
            {
                matrix[beeRow, beeCol] = '.';

                MoveBee(ref beeRow, ref beeCol, command);

                if (!IsInTheMatrix(beeRow, beeCol, matrix))
                {
                    Console.WriteLine("The bee got lost!");
                    break;
                }

                DoActionsInTheMatrix(ref countOfPollinatedFlowers, ref beeRow, ref beeCol, matrix, command);             

                command = Console.ReadLine();
            }

            if (countOfPollinatedFlowers < 5)
            {
                Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {5 - countOfPollinatedFlowers} flowers more");
            }
            else
            {
                Console.WriteLine($"Great job, the bee managed to pollinate {countOfPollinatedFlowers} flowers!");
            }

            PrintMatrix(matrix);
        }

        private static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }
        }

        private static void DoActionsInTheMatrix(ref int countOfPollinatedFlowers, ref int beeRow, ref int beeCol, char[,] matrix,
            string direction)
        {
            if (matrix[beeRow, beeCol] == 'f')
            {
                countOfPollinatedFlowers++;
            }
            else if (matrix[beeRow, beeCol] == 'O')
            {
                matrix[beeRow, beeCol] = '.';

                MoveBee(ref beeRow, ref beeCol, direction);

                if (matrix[beeRow, beeCol] == 'f')
                {
                    countOfPollinatedFlowers++;
                }
            }

            matrix[beeRow, beeCol] = 'B';
        }

        private static bool IsInTheMatrix(int row, int col, char[,] matrix)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
        }

        private static void MoveBee(ref int row, ref int col, string direction)
        {
            if (direction == "right")
            {
                col++;
            }
            else if (direction == "left")
            {
                col--;
            }
            else if (direction == "up")
            {
                row--;
            }
            else if (direction == "down")
            {
                row++;
            }
        }
    }
}
