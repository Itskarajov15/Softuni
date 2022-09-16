using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace _03.TheStoryTelling
{
    internal class Program
    {
        private static Dictionary<string, List<string>> graph;
        private static HashSet<string> visited;

        static void Main(string[] args)
        {
            graph = new Dictionary<string, List<string>>();

            var line = Console.ReadLine();

            while (line != "End")
            {
                var parts = line.Split("->", StringSplitOptions.RemoveEmptyEntries)
                                .Select(x => x.Trim())
                                .ToArray();

                if (parts.Length == 1)
                {
                    graph.Add(parts[0], new List<string>());
                }
                else
                {
                    graph[parts[0]] = parts[1].Split()
                                              .ToList();
                }

                line = Console.ReadLine();
            }

            visited = new HashSet<string>();

            foreach (var node in graph.Keys)
            {
                DFS(node);
            }

            Console.WriteLine(String.Join(" ", visited.Reverse()));
        }

        private static void DFS(string node)
        {
            if (visited.Contains(node))
            {
                return;
            }

            foreach (var child in graph[node])
            {
                DFS(child);
            }

            visited.Add(node);
        }
    }
}