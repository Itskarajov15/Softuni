using System;
using System.Collections.Generic;
using System.Linq;

namespace Paths
{
    internal class Program
    {
        private static Dictionary<int, List<int>> graph;
        private static List<int> path;

        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            graph = new Dictionary<int, List<int>>();

            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine();

                if (String.IsNullOrEmpty(line))
                {
                    graph[i] = new List<int>();
                }
                else
                {
                    graph[i] = line.Split()
                                   .Select(int.Parse)
                                   .ToList();
                }
            }

            foreach (var node in graph.Keys)
            {
                if (node != graph.Keys.Last())
                {
                    path = new List<int>();
                    BFS(node);
                }
            }
        }

        private static void BFS(int start)
        {
            var queue = new Queue<int>();
            queue.Enqueue(start);

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                path.Add(node);

                if (node == graph.Keys.Last())
                {
                    Console.WriteLine(String.Join(" ", path));
                }

                foreach (var child in graph[node])
                {
                    BFS(child);
                    path.RemoveAt(path.Count - 1);
                }
            }
        }
    }
}