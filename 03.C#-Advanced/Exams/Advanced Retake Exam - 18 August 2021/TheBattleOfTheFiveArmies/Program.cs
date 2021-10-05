using System;

namespace TheBattleOfTheFiveArmies
{
    class Program
    {
        static void Main(string[] args)
        {
            int armor = int.Parse(Console.ReadLine());
            int numberOfRows = int.Parse(Console.ReadLine());

            var field = new char[numberOfRows][];

            int armyRow = -1;
            int armyCol = -1;
            bool isDead = false;
            bool hasWon = false;

            for (int row = 0; row < field.Length; row++)
            {
                var currRow = Console.ReadLine().ToCharArray();

                field[row] = currRow;

                for (int col = 0; col < currRow.Length; col++)
                {
                    if (currRow[col] == 'A')
                    {
                        armyRow = row;
                        armyCol = col;
                    }
                }
            }

            while (!isDead && !hasWon)
            {
                string[] command = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                armor--;
                field[armyRow][armyCol] = '-';

                int orcRow = int.Parse(command[1]);
                int orcCol = int.Parse(command[2]);

                field[orcRow][orcCol] = 'O';

                Controller(ref armyRow, ref armyCol, field, command[0]);

                if (armor <= 0 && field[armyRow][armyCol] != 'M')
                {
                    field[armyRow][armyCol] = 'X';
                    isDead = true;
                }
                else if (field[armyRow][armyCol] == 'O')
                {
                    armor -= 2;

                    if (armor <= 0)
                    {
                        isDead = true;
                        field[armyRow][armyCol] = 'X';
                    }
                    else
                    {
                        field[armyRow][armyCol] = 'A';
                    }
                }
                else if (field[armyRow][armyCol] == 'M')
                {
                    hasWon = true;
                    field[armyRow][armyCol] = '-';
                }
                else
                {
                    field[armyRow][armyCol] = 'A';
                }
            }

            if (isDead || armor <= 0)
            {
                Console.WriteLine($"The army was defeated at {armyRow};{armyCol}.");
            }
            else if (hasWon)
            {
                Console.WriteLine($"The army managed to free the Middle World! Armor left: {armor}");
            }

            PrintMatrixOnTheConsole(field);
        }

        private static void PrintMatrixOnTheConsole(char[][] field)
        {
            for (int row = 0; row < field.Length; row++)
            {
                Console.WriteLine(String.Join("", field[row]));
            }
        }

        private static void Controller(ref int row, ref int col, char[][] field, string direction)
        {
            if (direction == "left")
            {
                if (IsInTheMatrix(row, col - 1, field))
                {
                    col -= 1;
                }
            }
            else if (direction == "right")
            {
                if (IsInTheMatrix(row, col + 1, field))
                {
                    col += 1;
                }
            }
            else if (direction == "up")
            {
                if (IsInTheMatrix(row - 1, col, field))
                {
                    row -= 1;
                }
            }
            else if (direction == "down")
            {
                if (IsInTheMatrix(row + 1, col, field))
                {
                    row += 1;
                }
            }
        }

        private static bool IsInTheMatrix(int row, int col, char[][] field)
        {
            return row >= 0 && row < field.Length && col >= 0 && col < field[row].Length;
        }
    }
}
