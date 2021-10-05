using System;
using System.Linq;

namespace SuperMario
{
    class Program
    {
        static void Main(string[] args)
        {
            int lives = int.Parse(Console.ReadLine());
            int numberOfRows = int.Parse(Console.ReadLine());

            var field = new char[numberOfRows][];

            int playerRow = -1;
            int playerCol = -1;

            for (int row = 0; row < field.Length; row++)
            {
                var currRow = Console.ReadLine().ToCharArray();

                field[row] = currRow;

                for (int col = 0; col < field[row].Length; col++)
                {
                    if (field[row][col] == 'M')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }

            bool hasWon = false;
            bool isDead = false;

            while (!hasWon && !isDead)
            {
                var command = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                lives--;
                field[playerRow][playerCol] = '-';

                int browserRow = int.Parse(command[1]);
                int browserCol = int.Parse(command[2]);
                field[browserRow][browserCol] = 'B';

                MovePlayer(ref playerRow, ref playerCol, field, command[0]);

                if (lives <= 0 && field[playerRow][playerCol] != 'P')
                {
                    isDead = true;
                    field[playerRow][playerCol] = 'X';
                    Console.WriteLine($"Mario died at {playerRow};{playerCol}.");
                }
                else if (field[playerRow][playerCol] == 'B')
                {
                    lives -= 2;

                    if (lives <= 0)
                    {
                        isDead = true;
                        field[playerRow][playerCol] = 'X';
                        Console.WriteLine($"Mario died at {playerRow};{playerCol}.");
                    }
                    else
                    {
                        field[playerRow][playerCol] = 'M';
                    }
                }
                else if (field[playerRow][playerCol] == 'P')
                {
                    hasWon = true;
                    Console.WriteLine($"Mario has successfully saved the princess! Lives left: {lives}");
                    field[playerRow][playerCol] = '-';
                }
                else
                {
                    field[playerRow][playerCol] = 'M';
                }
            }

            PrintField(field);
        }

        private static void PrintField(char[][] field)
        {
            for (int row = 0; row < field.Length; row++)
            {
                Console.WriteLine(String.Join("", field[row]));
            }
        }

        private static void MovePlayer(ref int row, ref int col, char[][] field, string direction)
        {
            if (direction == "A")
            {
                if (IsInTheField(row, col - 1, field))
                {
                    col -= 1;
                }
            }
            else if (direction == "D")
            {
                if (IsInTheField(row, col + 1, field))
                {
                    col += 1;
                }
            }
            else if (direction == "W")
            {
                if (IsInTheField(row - 1, col, field))
                {
                    row -= 1;
                }
            }
            else if (direction == "S")
            {
                if (IsInTheField(row + 1, col, field))
                {
                    row += 1;
                }
            }
        }

        private static bool IsInTheField(int row, int col, char[][] field)
        {
            return row >= 0 && row < field.Length && col >= 0 && col < field[row].Length;
        }
    }
}
