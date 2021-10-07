using System;
using System.Collections.Generic;

namespace _02._Selling
{
    class Program
    {
        static void Main(string[] args)
        {
            byte size = byte.Parse(Console.ReadLine());

            var matrix = new char[size, size];

            var firstPillar = new List<int>();
            var secondPillar = new List<int>();

            int playerRow = -1;
            int playerCol = -1;
            int money = 0;
            bool hasLeftTheMatrix = false;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string input = Console.ReadLine();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];

                    if (matrix[row, col] == 'S')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                    else if (matrix[row, col] == 'O' && firstPillar.Count == 0)
                    {
                        firstPillar.Add(row);
                        firstPillar.Add(col);
                    }
                    else if (matrix[row, col] == 'O' && firstPillar.Count != 0)
                    {
                        secondPillar.Add(row);
                        secondPillar.Add(col);
                    }
                }
            }

            while (money < 50 && !hasLeftTheMatrix)
            {
                string currCommand = Console.ReadLine();

                matrix[playerRow, playerCol] = '-';

                MovePlayer(ref playerRow, ref playerCol, matrix, currCommand, ref hasLeftTheMatrix);

                if (!hasLeftTheMatrix)
                {
                    if (matrix[playerRow, playerCol] == 'O')
                    {
                        var firstPillarRow = firstPillar[0];
                        var firstPillarCol = firstPillar[1];
                        var secondPillarRow = secondPillar[0];
                        var secondPillarCol = secondPillar[1];

                        matrix[firstPillarRow, firstPillarCol] = '-';
                        matrix[secondPillarRow, secondPillarCol] = '-';

                        if (firstPillarRow == playerRow && firstPillarCol == playerCol)
                        {
                            playerRow = secondPillarRow;
                            playerCol = secondPillarCol;
                        }
                        else if (secondPillarRow == playerRow && secondPillarCol == playerCol)
                        {
                            playerRow = firstPillarRow;
                            playerCol = firstPillarCol;
                        }
                    }
                    else if (Char.IsDigit(matrix[playerRow, playerCol]))
                    {
                        money += (int)Char.GetNumericValue(matrix[playerRow, playerCol]);
                    }

                    matrix[playerRow, playerCol] = 'S';
                }
            }

            Console.WriteLine(money >= 50 ? "Good news! You succeeded in collecting enough money!" 
                : "Bad news, you are out of the bakery.");

            Console.WriteLine($"Money: {money}");

            PrintMatrixOnTheConsole(matrix);
        }

        private static void PrintMatrixOnTheConsole(char[,] matrix)
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

        private static void MovePlayer(ref int row, ref int col, char[,] matrix, string currCommand, ref bool hasLeftTheMatrix)
        {
            if (currCommand == "left")
            {
                if (IsInTheMatrix(row, col - 1, matrix))
                {
                    col -= 1;
                }
                else
                {
                    hasLeftTheMatrix = true;
                }
            }
            else if (currCommand == "right")
            {
                if (IsInTheMatrix(row, col + 1, matrix))
                {
                    col += 1;
                }
                else
                {
                    hasLeftTheMatrix = true;
                }
            }
            else if (currCommand == "up")
            {
                if (IsInTheMatrix(row - 1, col, matrix))
                {
                    row -= 1;
                }
                else
                {
                    hasLeftTheMatrix = true;
                }
            }
            else if (currCommand == "down")
            {
                if (IsInTheMatrix(row + 1, col, matrix))
                {
                    row += 1;
                }
                else
                {
                    hasLeftTheMatrix = true;
                }
            }
        }

        private static bool IsInTheMatrix(int row, int col, char[,] matrix)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
        }
    }
}
