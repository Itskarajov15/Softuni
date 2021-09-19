using System;
using System.Linq;
using System.Collections.Generic;

namespace Lists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> list = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string[] command = Console.ReadLine()
                .Split(" - ", StringSplitOptions.RemoveEmptyEntries);


            while (command[0] != "Craft!")
            {
                if (command[0] == "Collect")
                {
                    string item = command[1];

                    if (list.Contains(item))
                    {
                        command = Console.ReadLine()
                            .Split(" - ", StringSplitOptions.RemoveEmptyEntries);
                        continue;
                    }
                    else
                    {
                        list.Add(item);
                    }
                }
                else if (command[0] == "Drop")
                {
                    string item = command[1];

                    if (list.Contains(item))
                    {
                        list.Remove(item);
                    }
                    else
                    {
                        command = Console.ReadLine()
                            .Split(" - ", StringSplitOptions.RemoveEmptyEntries);
                        continue;
                    }
                }
                else if (command[0] == "Combine Items")
                {
                    string[] wordsFromCommand = command[1].Split(':', StringSplitOptions.RemoveEmptyEntries)
                        .ToArray();

                    string oldItem = wordsFromCommand[0];
                    string newItem = wordsFromCommand[1];

                    if (list.Contains(oldItem))
                    {
                        int index = list.FindIndex(a => a.Contains(oldItem));

                        if (index == list.Count - 1)
                        {
                            list.Add(newItem);
                        }
                        else
                        {
                            list.Insert(index + 1, newItem);
                        }
                    }
                    else
                    {
                        command = Console.ReadLine()
                            .Split(" - ", StringSplitOptions.RemoveEmptyEntries);
                        continue;
                    }
                }
                else if (command[0] == "Renew")
                {
                    string item = command[1];

                    if (list.Contains(item))
                    {
                        list.Add(item);
                        list.Remove(item);
                    }
                    else
                    {
                        command = Console.ReadLine()
                            .Split(" - ", StringSplitOptions.RemoveEmptyEntries);
                        continue;
                    }
                }

                command = Console.ReadLine()
                .Split(" - ", StringSplitOptions.RemoveEmptyEntries);
            }

            Console.WriteLine(String.Join(", ", list));
        }
    }
}