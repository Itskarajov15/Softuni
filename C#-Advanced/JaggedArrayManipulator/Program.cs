using System;
using System.Linq;

namespace JaggedArrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfRows = int.Parse(Console.ReadLine());

            double[][] jaggedArray = new double[numberOfRows][];

            jaggedArray = FillingTheJaggedArray(jaggedArray);

            string[] commands = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            while (commands[0] != "End")
            {
                if (commands[0] == "Add")
                {
                    char mathOperator = '+';
                    jaggedArray = DoMathActionsWithTheJaggedArray(jaggedArray, mathOperator, commands);
                }
                else if (commands[0] == "Subtract")
                {
                    char mathOperator = '-';
                    jaggedArray = DoMathActionsWithTheJaggedArray(jaggedArray, mathOperator, commands);
                }

                commands = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }

            PrintTheJaggedArray(jaggedArray);
        }

        static double[][] DoMathActionsWithTheJaggedArray(double[][] jaggedArray, char mathOperator, string[] commands)
        {
            if (mathOperator == '+')
            {
                int row = int.Parse(commands[1]);
                int col = int.Parse(commands[2]);
                int value = int.Parse(commands[3]);

                if ((row >= 0 && row < jaggedArray.Length) && (col >= 0 && col < jaggedArray[row].Length))
                {
                    jaggedArray[row][col] += value;
                }
            }
            else
            {
                int row = int.Parse(commands[1]);
                int col = int.Parse(commands[2]);
                int value = int.Parse(commands[3]);

                if ((row >= 0 && row < jaggedArray.Length) && (col >= 0 && col < jaggedArray[row].Length))
                {
                    jaggedArray[row][col] -= value;
                }
            }

            return jaggedArray;
        }

        static void PrintTheJaggedArray(double[][] jaggedArray)
        {
            for (int row = 0; row < jaggedArray.Length; row++)
            {
                Console.WriteLine(String.Join(" ", jaggedArray[row]));
            }
        }

        static double[][] FillingTheJaggedArray(double[][] jaggedArray)
        {
            for (int row = 0; row < jaggedArray.Length; row++)
            {
                double[] array = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse)
                    .ToArray();

                if (row >= 1 && row < jaggedArray.Length)
                {
                    if (array.Length == jaggedArray[row - 1].Length)
                    {
                        char mathOperator = '*';

                        jaggedArray = MathOperationsWithTheJaggedArray(jaggedArray, mathOperator, array, row);
                    }
                    else
                    {
                        char mathOperator = '/';

                        jaggedArray = MathOperationsWithTheJaggedArray(jaggedArray, mathOperator, array, row);
                    }
                }

                jaggedArray[row] = array;
            }

            return jaggedArray;
        }

        static double[][] MathOperationsWithTheJaggedArray(double[][] jaggedArray, char mathOperator, double[] array, int row)
        {
            int biggestLenght = Math.Max(array.Length, jaggedArray[row - 1].Length);

            if (mathOperator == '*')
            {
                for (int i = 0; i < biggestLenght; i++)
                {
                    if (array.Length <= i)
                    {
                        jaggedArray[row - 1][i] *= 2;
                    }
                    else if (jaggedArray[row - 1].Length <= i)
                    {
                        array[i] *= 2;
                    }
                    else
                    {
                        array[i] *= 2;
                        jaggedArray[row - 1][i] *= 2;
                    }
                }
            }
            else
            {
                for (int i = 0; i < biggestLenght; i++)
                {
                    if (array.Length <= i)
                    {
                        jaggedArray[row - 1][i] /= 2;
                    }
                    else if (jaggedArray[row - 1].Length <= i)
                    {
                        array[i] /= 2;
                    }
                    else
                    {
                        array[i] /= 2;
                        jaggedArray[row - 1][i] /= 2;
                    }
                }
            }

            return jaggedArray;
        }
    }
}
