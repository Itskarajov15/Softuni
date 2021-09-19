using System;
using System.Linq;

namespace Miner
{
    class Program
    {
        static void Main(string[] args)
        {
            int fieldSize = int.Parse(Console.ReadLine());

            char[,] field = new char[fieldSize, fieldSize];

            string[] commands = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            int amountOfCoalOnTheField = 0;
            int collectedCoal = 0;
            int[] currPosition = new int[2];

            amountOfCoalOnTheField = FillingTheField(field, amountOfCoalOnTheField, currPosition);

            for (int i = 0; i < commands.Length; i++)
            {
                string direction = commands[i];

                if (direction == "left")
                {
                    currPosition = MovesTheMiner(field, direction, currPosition);
                }
                else if (direction == "right")
                {
                    currPosition = MovesTheMiner(field, direction, currPosition);

                }
                else if (direction == "up")
                {
                    currPosition = MovesTheMiner(field, direction, currPosition);
                }
                else if (direction == "down")
                {
                    currPosition = MovesTheMiner(field, direction, currPosition);
                }

                char symbolAtCurrPosition = field[currPosition[0], currPosition[1]];

                if (symbolAtCurrPosition == 'e')
                {
                    Console.WriteLine($"Game over! ({currPosition[0]}, {currPosition[1]})");
                    return;
                }
                else if (symbolAtCurrPosition == 'c')
                {
                    amountOfCoalOnTheField--;
                    collectedCoal++;

                    if (amountOfCoalOnTheField <= 0)
                    {
                        Console.WriteLine($"You collected all coals! ({currPosition[0]}, {currPosition[1]})");
                        return;
                    }
                    else
                    {
                        field[currPosition[0], currPosition[1]] = '*';
                    }
                }
            }

            Console.WriteLine($"{amountOfCoalOnTheField} coals left. ({currPosition[0]}, {currPosition[1]})");
        }

        static int[] MovesTheMiner(char[,] field, string direction, int[] currPosition)
        {
            int row = currPosition[0];
            int col = currPosition[1];

            if (direction == "left")
            {
                if (col - 1 >= 0)
                {
                    col -= 1;
                }
            }
            else if (direction == "right")
            {
                if (col + 1 < field.GetLength(1))
                {
                    col += 1;
                }
            }
            else if (direction == "up")
            {
                if (row - 1 >= 0)
                {
                    row -= 1;
                }
            }
            else if (direction == "down")
            {
                if (row + 1 < field.GetLength(0))
                {
                    row += 1;
                }
            }

            currPosition[0] = row;
            currPosition[1] = col;

            return currPosition;
        }

        static int FillingTheField(char[,] field, int amountOfCoalOnTheField, int[] currPosition)
        {
            for (int row = 0; row < field.GetLength(0); row++)
            {
                char[] currRow = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                for (int col = 0; col < field.GetLength(1); col++)
                {
                    if (currRow[col] == 'c')
                    {
                        amountOfCoalOnTheField++;
                    }

                    if (currRow[col] == 's')
                    {
                        currPosition[0] = row;
                        currPosition[1] = col;
                    }

                    field[row, col] = currRow[col];
                }
            }

            return amountOfCoalOnTheField;
        }
    }
}
