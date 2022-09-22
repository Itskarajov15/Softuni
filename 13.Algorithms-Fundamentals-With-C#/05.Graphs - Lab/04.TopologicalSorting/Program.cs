using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.TopologicalSorting
{
    internal class Program
    {
        private static Dictionary<string, List<string>> graph;
        private static Dictionary<string, int> dependecies;

        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            graph = ReadGraph(n);

            dependecies = ExtractDependency(graph);

            var sorted = new List<string>();

            while (dependecies.Count > 0)
            {
                var nodeToRemove = dependecies.FirstOrDefault(d => d.Value == 0).Key;

                if (nodeToRemove == null)
                {
                    break;
                }

                dependecies.Remove(nodeToRemove);

                foreach (var child in graph[nodeToRemove])
                {
                    dependecies[child]--;
                }

                sorted.Add(nodeToRemove);
            }

            if (dependecies.Count > 0)
            {
                Console.WriteLine("Invalid topological sorting");
            }
            else
            {
                Console.WriteLine($"Topological sorting: {String.Join(", ", sorted)}");
            }
        }

        private static Dictionary<string, int> ExtractDependency(Dictionary<string, List<string>> graph)
        {
            var result = new Dictionary<string, int>();

            foreach (var kvp in graph)
            {
                var key = kvp.Key;
                var value = kvp.Value;

                if (!result.ContainsKey(key))
                {
                    result[key] = 0;
                }

                foreach (var child in value)
                {
                    if (!result.ContainsKey(child))
                    {
                        result[child] = 1;
                    }
                    else
                    {
                        result[child]++;
                    }
                }
            }

            return result;
        }

        private static Dictionary<string, List<string>> ReadGraph(int n)
        {
            var result = new Dictionary<string, List<string>>();

            for (int node = 0; node < n; node++)
            {
                var parts = Console.ReadLine()
                                  .Split("->", StringSplitOptions.RemoveEmptyEntries)
                                  .Select(x => x.Trim())
                                  .ToArray();

                var key = parts[0];

                if (parts.Length == 1)
                {
                    result[key] = new List<string>();
                }
                else
                {
                    result[key] = parts[1].Split(", ").ToList();
                }
            }

            return result;
        }
    }
}