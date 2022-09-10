using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace _01.DistanceBetweenVertices
{
    internal class Program
    {
        private static Dictionary<int, List<int>> graph;
        static void Main(string[] args)
        {
            var nodes = int.Parse(Console.ReadLine());
            var pairs = int.Parse(Console.ReadLine());

            graph = new Dictionary<int, List<int>>();

            for (int i = 0; i < nodes; i++)
            {
                var parts = Console.ReadLine()
                                   .Split(":", StringSplitOptions.RemoveEmptyEntries)
                                   .ToArray();

                var key = int.Parse(parts[0]);

                if (parts.Length == 1)
                {
                    graph[key] = new List<int>();
                }
                else
                {
                    graph[key] = parts[1].Split().Select(int.Parse).ToList();
                }
            }

            for (int i = 0; i < pairs; i++)
            {
                var line = Console.ReadLine()
                                  .Split("-", StringSplitOptions.RemoveEmptyEntries)
                                  .Select(int.Parse)
                                  .ToArray();

                var start = line[0];
                var destination = line[1];

                var steps = FindPath(start, destination);

                Console.WriteLine($"{{{start}, {destination}}} -> {steps}");
            }
        }

        private static int FindPath(int start, int destination)
        {
            var queue = new Queue<int>();
            queue.Enqueue(start);

            var visited = new HashSet<int>() { start };
            var parent = new Dictionary<int, int>() { { start, -1 } };

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();

                if (node == destination)
                {
                    return GetSteps(parent, destination);
                }

                foreach (var child in graph[node])
                {
                    if (!visited.Contains(child))
                    {
                        queue.Enqueue(child);
                        visited.Add(child);
                        parent[child] = node;
                    }
                }
            }

            return -1;
        }

        private static int GetSteps(Dictionary<int, int> parent, int destination)
        {
            var steps = 0;
            var node = destination;

            while (node != -1)
            {
                node = parent[node];
                steps++;
            }

            return steps - 1;
        }
    }
}