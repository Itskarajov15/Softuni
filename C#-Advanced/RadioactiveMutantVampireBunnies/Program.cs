using System;
using System.Collections.Generic;
using System.Linq;

namespace RadioactiveMutantVampireBunnies
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sizesOfField = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int n = sizesOfField[0];
            int m = sizesOfField[1];

            char[,] field = new char[n, m];

            int playerRow = -1;
            int playerCol = -1;

            for (int row = 0; row < n; row++)
            {
                char[] currRow = Console.ReadLine().ToCharArray();

                for (int col = 0; col < m; col++)
                {
                    field[row, col] = currRow[col];

                    if (field[row, col] == 'P')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }

            char[] commands = Console.ReadLine().ToCharArray();

            bool isWon = false;
            bool isDead = false;

            foreach (var item in commands)
            {
                int newPlayerRow = playerRow;
                int newPlayerCol = playerCol;

                if (item == 'U')
                {
                    newPlayerRow--;
                }
                else if (item == 'D')
                {
                    newPlayerRow++;
                }
                else if (item == 'L')
                {
                    newPlayerCol--;
                }
                else if (item == 'R')
                {
                    newPlayerCol++;
                }

                if (!isValid(newPlayerRow, newPlayerCol, n, m))
                {
                    isWon = true;
                    field[playerRow, playerCol] = '.';

                    List<int[]> bunniesCoordinates = ReturnCoordinatesOfBunnies(field);

                    SpreadBunnies(field, bunniesCoordinates);
                }
                else if (field[newPlayerRow, newPlayerCol] == '.')
                {
                    field[newPlayerRow, newPlayerCol] = 'P';
                    field[playerRow, playerCol] = '.';

                    playerRow = newPlayerRow;
                    playerCol = newPlayerCol;

                    List<int[]> bunniesCoordinates = ReturnCoordinatesOfBunnies(field);

                    SpreadBunnies(field, bunniesCoordinates);

                    if (field[playerRow, playerCol] == 'B')
                    {
                        isDead = true;
                    }
                }
                else if (field[newPlayerRow, newPlayerCol] == 'B')
                {
                    isDead = true;
                    field[playerRow, playerCol] = '.';
                    playerRow = newPlayerRow;
                    playerCol = newPlayerCol;

                    List<int[]> bunniesCoordinates = ReturnCoordinatesOfBunnies(field);

                    SpreadBunnies(field, bunniesCoordinates);
                }

                if (isDead || isWon)
                {
                    break;
                }
            }

            PrintField(field);

            if (isWon)
            {
                Console.WriteLine($"won: {playerRow} {playerCol}");
            }
            else
            {
                Console.WriteLine($"dead: {playerRow} {playerCol}");
            }
        }

        static void PrintField(char[,] field)
        {
            for (int row = 0; row < field.GetLength(0); row++)
            {
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    Console.Write(field[row, col]);
                }

                Console.WriteLine();
            }
        }

        static void SpreadBunnies(char[,] field, List<int[]> bunniesCoordinates)
        {
            foreach (var bunnyCoordinates in bunniesCoordinates)
            {
                int row = bunnyCoordinates[0];
                int col = bunnyCoordinates[1];

                SpreadBunny(row - 1, col, field);
                SpreadBunny(row + 1, col, field);
                SpreadBunny(row, col - 1, field);
                SpreadBunny(row, col + 1, field);
            }
        }

        static void SpreadBunny(int row, int col, char[,] field)
        {
            int n = field.GetLength(0);
            int m = field.GetLength(1);

            if (isValid(row, col, n, m))
            {
                field[row, col] = 'B';
            }
        }

        static List<int[]> ReturnCoordinatesOfBunnies(char[,] field)
        {
            List<int[]> bunniesCoordinates = new List<int[]>();

            for (int row = 0; row < field.GetLength(0); row++)
            {
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    if (field[row, col] == 'B')
                    {
                        bunniesCoordinates.Add(new int[] { row, col });
                    }
                }
            }

            return bunniesCoordinates;
        }

        static bool isValid(int row, int col, int n, int m)
        {
            return row >= 0 && row < n && col >= 0 && col < m;
        }
    }
}
