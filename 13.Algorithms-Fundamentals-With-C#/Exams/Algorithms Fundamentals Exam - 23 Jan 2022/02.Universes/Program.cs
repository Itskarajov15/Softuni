using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Universes
{
    internal class Program
    {
        private static Dictionary<string, List<string>> graph;
        private static HashSet<string> visited;

        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            graph = new Dictionary<string, List<string>>();

            for (int i = 0; i < n; i++)
            {
                var parts = Console.ReadLine()
                                   .Split(" - ")
                                   .ToArray();

                if (!graph.ContainsKey(parts[0]))
                {
                    graph.Add(parts[0], new List<string>());
                }

                if (!graph.ContainsKey(parts[1]))
                {
                    graph.Add(parts[1], new List<string>());
                }

                graph[parts[0]].Add(parts[1]);
                graph[parts[1]].Add(parts[0]);
            }

            visited = new HashSet<string>();
            var count = 0;

            foreach (var node in graph.Keys)
            {
                if (!visited.Contains(node))
                {
                    DFS(node);
                    count++;
                }
            }

            Console.WriteLine(count);
        }

        private static void DFS(string node)
        {
            if (visited.Contains(node))
            {
                return;
            }

            visited.Add(node);

            foreach (var child in graph[node])
            {
                DFS(child);
            }
        }
    }
}