using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;

namespace _02.AreasInMatrix
{
    internal class Program
    {
        private static char[,] graph;
        private static bool[,] visited;
        private static Dictionary<char, int> areas;

        static void Main(string[] args)
        {
            var rows = int.Parse(Console.ReadLine());
            var cols = int.Parse(Console.ReadLine());

            graph = new char[rows, cols];
            visited = new bool[rows, cols];
            areas = new Dictionary<char, int>();

            for (int row = 0; row < rows; row++)
            {
                var currRow = Console.ReadLine();

                for (int col = 0; col < cols; col++)
                {
                    graph[row, col] = currRow[col];
                }
            }

            var countOfAreas = 0;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (visited[row, col])
                    {
                        continue;
                    }

                    var nodeValue = graph[row, col];
                    DFS(row, col, nodeValue);

                    if (areas.ContainsKey(nodeValue))
                    {
                        areas[nodeValue]++;
                    }
                    else
                    {
                        areas[nodeValue] = 1;
                    }

                    countOfAreas++;
                }
            }

            Console.WriteLine($"Areas: {countOfAreas}");

            foreach (var kvp in areas.OrderBy(a => a.Key))
            {
                Console.WriteLine($"Letter '{kvp.Key}' -> {kvp.Value}");
            }
        }

        private static void DFS(int row, int col, char parentNode)
        {
            if (!IsValid(row, col) || visited[row, col] || graph[row, col] != parentNode)
            {
                return;
            }

            visited[row, col] = true;

            DFS(row, col - 1, parentNode);
            DFS(row, col + 1, parentNode);
            DFS(row - 1, col, parentNode);
            DFS(row + 1, col, parentNode);
        }

        private static bool IsValid(int row, int col)
            => row >= 0 && row < graph.GetLength(0) && col >= 0 && col < graph.GetLength(1);
    }
}