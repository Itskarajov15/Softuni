using System;

namespace _01.TBC
{
    internal class Program
    {
        private static char[,] map;
        private static bool[,] visited;

        static void Main(string[] args)
        {
            var rows = int.Parse(Console.ReadLine());
            var cols = int.Parse(Console.ReadLine());

            map = new char[rows, cols];
            visited = new bool[rows, cols];

            for (int row = 0; row < map.GetLength(0); row++)
            {
                var rowElements = Console.ReadLine();

                for (int col = 0; col < map.GetLength(1); col++)
                {
                    map[row, col] = rowElements[col];
                }
            }

            var paths = 0;

            for (int row = 0; row < map.GetLength(0); row++)
            {
                for (int col = 0; col < map.GetLength(1); col++)
                {
                    if (visited[row, col] || map[row, col] == 'd')
                    {
                        continue;
                    }

                    DFS(row, col);
                    paths++;
                }
            }

            Console.WriteLine(paths);
        }

        private static void DFS(int row, int col)
        {
            if (!IsValid(row, col) || visited[row, col])
            {
                return;
            }

            visited[row, col] = true;

            if (map[row, col] == 'd')
            {
                return;
            }

            DFS(row - 1, col);
            DFS(row + 1, col);
            DFS(row, col - 1);
            DFS(row, col + 1);
            DFS(row - 1, col + 1);
            DFS(row - 1, col - 1);
            DFS(row + 1, col + 1);
            DFS(row + 1, col - 1);
        }

        private static bool IsValid(int row, int col)
            => row >= 0 && row < map.GetLength(0) && col >= 0 && col < map.GetLength(1);
    }
}