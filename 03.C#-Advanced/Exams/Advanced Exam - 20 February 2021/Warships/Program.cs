using System;
using System.Linq;

namespace Warships
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            var field = new char[size, size];

            int countOfFirstPlayerShips = 0;
            int countOfSecondPlayerShips = 0;

            bool firstPlayerTurn = false;

            var input = Console.ReadLine();
            var turns = input
                .Split(",", StringSplitOptions.RemoveEmptyEntries);

            for (int row = 0; row < field.GetLength(0); row++)
            {
                char[] array = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                for (int col = 0; col < field.GetLength(1); col++)
                {
                    field[row, col] = array[col];

                    if (field[row, col] == '<')
                    {
                        countOfFirstPlayerShips++;
                    }
                    else if (field[row, col] == '>')
                    {
                        countOfSecondPlayerShips++;
                    }
                }
            }

            for (int i = 0; i < turns.Length; i++)
            {
                var tokens = turns[i].Split(" ", StringSplitOptions.RemoveEmptyEntries);

                int currRow = int.Parse(tokens[0]);
                int currCol = int.Parse(tokens[1]);

                if (i % 2 == 0)
                {
                    firstPlayerTurn = true;
                }
                else
                {
                    firstPlayerTurn = false;
                }

                if (IsInTheField(currRow, currCol, field))
                {
                    if (field[currRow, currCol] == '#')
                    {
                        DestroyAdjacentCells(field, currRow, currCol, ref countOfFirstPlayerShips, ref countOfSecondPlayerShips);
                    }
                    else if (field[currRow, currCol] == '<' || field[currRow, currCol] == '>')
                    {
                        field[currRow, currCol] = 'X';

                        if (firstPlayerTurn)
                        {
                            countOfSecondPlayerShips--;
                        }
                        else
                        {
                            countOfFirstPlayerShips--;
                        }
                    }

                    if (countOfFirstPlayerShips == 0 || countOfSecondPlayerShips == 0)
                    {
                        break;
                    }
                }
            }

            int countOfSunkShips = ReturnCountOfSuckShips(field);

            if (countOfFirstPlayerShips > 0 && countOfSecondPlayerShips <= 0)
            {
                Console.WriteLine($"Player One has won the game! {countOfSunkShips} ships have been sunk in the battle.");
            }
            else if (countOfFirstPlayerShips <= 0 && countOfSecondPlayerShips > 0)
            {
                Console.WriteLine($"Player Two has won the game! {countOfSunkShips} ships have been sunk in the battle.");
            }
            else if (countOfFirstPlayerShips >= 0 && countOfSecondPlayerShips >= 0)
            {
                Console.WriteLine($"It's a draw! Player One has {countOfFirstPlayerShips} ships left. Player Two has {countOfSecondPlayerShips} ships left.");
            }
        }

        private static int ReturnCountOfSuckShips(char[,] field)
        {
            int count = 0;

            for (int row = 0; row < field.GetLength(0); row++)
            {
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    if (field[row, col] == 'X')
                    {
                        count++;
                    }
                }
            }

            return count;
        }

        private static void DestroyAdjacentCells(char[,] field, int row, int col, ref int countOfFirstPlayerShips,
            ref int countOfSecondPlayerShips)
        {
            if (IsInTheField(row - 1, col - 1, field))
            {
                ReduceCountOfShips(ref countOfFirstPlayerShips, ref countOfSecondPlayerShips, field, row - 1, col - 1);
            }
            if (IsInTheField(row - 1, col, field))
            {
                ReduceCountOfShips(ref countOfFirstPlayerShips, ref countOfSecondPlayerShips, field, row - 1, col);
            }
            if (IsInTheField(row - 1, col + 1, field))
            {
                ReduceCountOfShips(ref countOfFirstPlayerShips, ref countOfSecondPlayerShips, field, row - 1, col + 1);
            }
            if (IsInTheField(row, col - 1, field))
            {
                ReduceCountOfShips(ref countOfFirstPlayerShips, ref countOfSecondPlayerShips, field, row, col - 1);
            }
            if (IsInTheField(row, col, field))
            {
                ReduceCountOfShips(ref countOfFirstPlayerShips, ref countOfSecondPlayerShips, field, row, col);
            }
            if (IsInTheField(row, col + 1, field))
            {
                ReduceCountOfShips(ref countOfFirstPlayerShips, ref countOfSecondPlayerShips, field, row, col + 1);
            }
            if (IsInTheField(row + 1, col - 1, field))
            {
                ReduceCountOfShips(ref countOfFirstPlayerShips, ref countOfSecondPlayerShips, field, row + 1, col - 1);
            }
            if (IsInTheField(row + 1, col, field))
            {
                ReduceCountOfShips(ref countOfFirstPlayerShips, ref countOfSecondPlayerShips, field, row + 1, col);
            }
            if (IsInTheField(row + 1, col + 1, field))
            {
                ReduceCountOfShips(ref countOfFirstPlayerShips, ref countOfSecondPlayerShips, field, row + 1, col + 1);
            }
        }

        private static void ReduceCountOfShips(ref int countOfFirstPlayerShips, ref int countOfSecondPlayerShips, char[,] field
            , int row, int col)
        {
            if (field[row, col] == '<')
            {
                countOfFirstPlayerShips--;

                field[row, col] = 'X';
            }
            else if (field[row, col] == '>')
            {
                countOfSecondPlayerShips--;

                field[row, col] = 'X';
            }
        }

        private static bool IsInTheField(int row, int col, char[,] field)
        {
            return row >= 0 && row < field.GetLength(0) && col >= 0 && col < field.GetLength(1);
        }
    }
}
