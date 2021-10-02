using System;

namespace KnightGame
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var matrix = new char[n, n];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var charArr = Console.ReadLine().ToCharArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = charArr[col];
                }
            }

            int removedKnights = 0;

            while (true)
            {
                int maxAtacks = 0;
                int knightRow = 0;
                int knightCol = 0;

                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        if (matrix[row, col] != 'K')
                        {
                            continue;
                        }

                        int atacks = ReturnNumberOfAtacks(row, col, matrix);

                        if (atacks > maxAtacks)
                        {
                            maxAtacks = atacks;
                            knightRow = row;
                            knightCol = col;
                        }
                    }
                }

                if (maxAtacks == 0)
                {
                    Console.WriteLine(removedKnights);
                    break;
                }
                else
                {
                    matrix[knightRow, knightCol] = '0';
                    removedKnights++;
                }
            }
        }

        private static int ReturnNumberOfAtacks(int row, int col, char[,] matrix)
        {
            int atacks = 0;

            if (ValidateIndices(row + 2, col + 1, matrix) && matrix[row + 2, col + 1] == 'K')
            {
                atacks++;
            }
            if (ValidateIndices(row + 1, col + 2, matrix) && matrix[row + 1, col + 2] == 'K')
            {
                atacks++;
            }
            if (ValidateIndices(row - 1, col + 2, matrix) && matrix[row - 1, col + 2] == 'K')
            {
                atacks++;
            }
            if (ValidateIndices(row - 2, col + 1, matrix) && matrix[row - 2, col + 1] == 'K')
            {
                atacks++;
            }
            if (ValidateIndices(row - 2, col - 1, matrix) && matrix[row - 2, col - 1] == 'K')
            {
                atacks++;
            }
            if (ValidateIndices(row - 1, col - 2, matrix) && matrix[row - 1, col - 2] == 'K')
            {
                atacks++;
            }
            if (ValidateIndices(row + 1, col - 2, matrix) && matrix[row + 1, col - 2] == 'K')
            {
                atacks++;
            }
            if (ValidateIndices(row + 2, col - 1, matrix) && matrix[row + 2, col - 1] == 'K')
            {
                atacks++;
            }

            return atacks;
        }

        private static bool ValidateIndices(int row, int col, char[,] matrix)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
        }
    }
}
