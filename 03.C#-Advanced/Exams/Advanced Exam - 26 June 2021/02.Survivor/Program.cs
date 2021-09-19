using System;
using System.Linq;

namespace _02.Survivor
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfRows = int.Parse(Console.ReadLine());

            char[][] beach = new char[numberOfRows][];

            for (int row = 0; row < numberOfRows; row++)
            {
                char[] array = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                beach[row] = array;
            }

            string[] command = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            int countOfCollectedTokens = 0;
            int countOfOpponentsTokens = 0;

            while (command[0] != "Gong")
            {
                if (command[0] == "Find")
                {
                    int row = int.Parse(command[1]);
                    int col = int.Parse(command[2]);

                    if (CheckIfCoordinatesExist(row, col, beach))
                    {
                        if (beach[row][col] == 'T')
                        {
                            countOfCollectedTokens++;
                            beach[row][col] = '-';
                        }
                    }
                }
                else if (command[0] == "Opponent")
                {
                    int row = int.Parse(command[1]);
                    int col = int.Parse(command[2]);
                    string direction = command[3];

                    if (CheckIfCoordinatesExist(row, col, beach))
                    {
                        if (beach[row][col] == 'T')
                        {
                            countOfOpponentsTokens++;
                            beach[row][col] = '-';

                            for (int i = 0; i < 3; i++)
                            {
                                if (direction == "up")
                                {
                                    row -= 1;
                                    countOfOpponentsTokens = MoveThePlayer(beach, row, col, countOfOpponentsTokens);
                                }
                                else if (direction == "down")
                                {
                                    row += 1;
                                    countOfOpponentsTokens = MoveThePlayer(beach, row, col, countOfOpponentsTokens);
                                }
                                else if (direction == "left")
                                {
                                    col -= 1;
                                    countOfOpponentsTokens = MoveThePlayer(beach, row, col, countOfOpponentsTokens);
                                }
                                else if (direction == "right")
                                {
                                    col += 1;
                                    countOfOpponentsTokens = MoveThePlayer(beach, row, col, countOfOpponentsTokens);
                                }
                            }
                        }
                    }
                }

                command = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }

            for (int row = 0; row < beach.Length; row++)
            {
                Console.WriteLine(String.Join(" ", beach[row]));
            }

            Console.WriteLine($"Collected tokens: {countOfCollectedTokens}");
            Console.WriteLine($"Opponent's tokens: {countOfOpponentsTokens}");
        }

        static int MoveThePlayer(char[][] beach, int row, int col, int countOfOpponentsTokens)
        {
            if (CheckIfCoordinatesExist(row, col, beach))
            {
                if (beach[row][col] == 'T')
                {
                    countOfOpponentsTokens++;
                    beach[row][col] = '-';
                }
            }

            return countOfOpponentsTokens;
        }

        static bool CheckIfCoordinatesExist(int row, int col, char[][] beach)
        {
            return (row >= 0 && row < beach.Length) && (col >= 0 && col < beach[row].Length);
        }
    }
}
