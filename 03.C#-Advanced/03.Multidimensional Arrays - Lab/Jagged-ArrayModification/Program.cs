using System;
using System.Linq;

namespace Jagged_ArrayModification
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            int[][] jaggedArray = new int[rows][];

            for (int i = 0; i < jaggedArray.Length; i++)
            {
                jaggedArray[i] = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            }

            string[] command = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            while (command[0] != "END")
            {
                if (command[0] == "Add")
                {
                    int row = int.Parse(command[1]);
                    int col = int.Parse(command[2]);
                    int value = int.Parse(command[3]);

                    if (row < 0 || row >= jaggedArray.Length || col < 0 || col >= jaggedArray[row].Length)
                    {
                        Console.WriteLine("Invalid coordinates");
                        command = Console.ReadLine()
                            .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                        continue;
                    }

                    jaggedArray[row][col] += value;
                }
                else if (command[0] == "Subtract")
                {
                    int row = int.Parse(command[1]);
                    int col = int.Parse(command[2]);
                    int value = int.Parse(command[3]);

                    if (row < 0 || row >= jaggedArray.Length || col < 0 || col >= jaggedArray[row].Length)
                    {
                        Console.WriteLine("Invalid coordinates");
                        command = Console.ReadLine()
                            .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                        continue;
                    }

                    jaggedArray[row][col] -= value;
                }

                command = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }

            //for (int row = 0; row < jaggedArray.Length; row++)
            //{
            //    for (int col = 0; col < jaggedArray[row].Length; col++)
            //    {
            //        Console.Write(jaggedArray[row][col] + " ");
            //    }

            //    Console.WriteLine();
            //}

            for (int i = 0; i < jaggedArray.Length; i++)
            {
                Console.WriteLine(String.Join(' ', jaggedArray[i]));
            }
        }
    }
}
