using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;

namespace _03.PathFinder
{
    internal class Program
    {
        private static Dictionary<int, List<int>> graph;
        private static List<int> visited;
        private static List<List<int>> paths;

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

            var numberOfPaths = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfPaths; i++)
            {
                var path = Console.ReadLine()
                                  .Split()
                                  .Select(int.Parse)
                                  .ToList();

                paths = new List<List<int>>();
                visited = new List<int>();

                DFS(path[0], path[path.Count - 1]);

                if (paths.Any(x => x.SequenceEqual(path)))
                {
                    Console.WriteLine("yes");
                }
                else
                {
                    Console.WriteLine("no");
                }
            }
        }

        private static void DFS(int node, int destination)
        {
            if (visited.Contains(node))
            {
                return;
            }

            visited.Add(node);

            if (node == destination)
            {
                paths.Add(visited.ToList());
                return;
            }

            foreach (var child in graph[node])
            {
                DFS(child, destination);
                visited.Remove(child);
            }
        }
    }
}