using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.ConnectedAreas
{
    public class Area
    {
        public int Row { get; set; }

        public int Col { get; set; }

        public int Size { get; set; }
    }

    internal class Program
    {
        private static char[,] matrix;
        private static int size;
        private const char VisitedSymbol = 'v';

        static void Main(string[] args)
        {
            var rows = int.Parse(Console.ReadLine());
            var cols = int.Parse(Console.ReadLine());

            matrix = new char[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                var colElements = Console.ReadLine();

                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = colElements[j];
                }
            }

            var areas = new List<Area>();

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    size = 0;

                    ExploreArea(i, j);

                    if (size != 0)
                    {
                        areas.Add(new Area { Row = i, Col = j, Size = size });
                    }
                }
            }

            var sorted = areas.OrderByDescending(a => a.Size)
                              .ThenBy(a => a.Row)
                              .ThenBy(a => a.Col)
                              .ToList();

            Console.WriteLine($"Total areas found: {sorted.Count}");

            for (int i = 0; i < sorted.Count; i++)
            {
                Console.WriteLine($"Area #{i + 1} at ({sorted[i].Row}, {sorted[i].Col}), size: {sorted[i].Size}");
            }
        }

        private static void ExploreArea(int row, int col)
        {
            if (IsOutside(row, col) || IsWall(row, col) || IsVisited(row, col))
            {
                return;
            }

            size += 1;
            matrix[row, col] = VisitedSymbol;

            ExploreArea(row - 1, col);
            ExploreArea(row + 1, col);
            ExploreArea(row, col - 1); 
            ExploreArea(row, col + 1);
        }

        private static bool IsVisited(int row, int col)
            => matrix[row, col] == VisitedSymbol;

        private static bool IsWall(int row, int col)
            => matrix[row, col] == '*';

        private static bool IsOutside(int row, int col)
            => row < 0 || row >= matrix.GetLength(0) || col < 0 || col >= matrix.GetLength(1);
    }
}