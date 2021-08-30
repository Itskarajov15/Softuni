using System;
using System.Linq;

namespace SumMatrixElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = ReadArrayFromTheConsole();

            int[,] matrix = new int[sizes[0], sizes[1]];

            int sum = 0;

            for (int row = 0; row < sizes[0]; row++)
            {
                int[] arr = ReadArrayFromTheConsole();

                for (int col = 0; col < sizes[1]; col++)
                {
                    matrix[row, col] = arr[col];

                    sum += arr[col];
                }
            }

            Console.WriteLine(sizes[0]);
            Console.WriteLine(sizes[1]);
            Console.WriteLine(sum);
        }

        static int[] ReadArrayFromTheConsole()
        {
            return Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }
    }
}
