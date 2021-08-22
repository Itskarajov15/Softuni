using System;
using System.Text;
using System.Text.RegularExpressions;

namespace ActivationKeys
{
    class Program
    {
        static void Main(string[] args)
        {
            string key = Console.ReadLine();

            string command = Console.ReadLine();

            while (command != "Generate")
            {
                if (command.Contains("Contains"))
                {
                    string pattern = @">>>(?<substring>\w+)";

                    Match match = Regex.Match(command, pattern);

                    if (!Regex.IsMatch(command, pattern))
                    {
                        command = Console.ReadLine();
                        continue;
                    }

                    string substring = match.Groups["substring"].Value;

                    if (key.Contains(substring))
                    {
                        Console.WriteLine($"{key} contains {substring}");
                    }
                    else
                    {
                        Console.WriteLine($"Substring not found!");
                    }
                }
                else if (command.Contains("Flip"))
                {
                    StringBuilder result = new StringBuilder();

                    string pattern = @">>>(?<token>[A-Z][a-z]+)>>>(?<startIndex>[0-9]+)>>>(?<endIndex>[0-9]+)";

                    Match match = Regex.Match(command, pattern);

                    string token = match.Groups["token"].Value;
                    int startIndex = int.Parse(match.Groups["startIndex"].Value);
                    int endIndex = int.Parse(match.Groups["endIndex"].Value);

                    for (int i = 0; i < key.Length; i++)
                    {
                        if (i >= startIndex && i < endIndex)
                        {
                            if (token == "Upper")
                            {
                                result.Append(key[i].ToString().ToUpper());
                            }
                            else if (token == "Lower")
                            {
                                result.Append(key[i].ToString().ToLower());
                            }
                        }
                        else
                        {
                            result.Append(key[i]);
                        }
                    }

                    key = result.ToString();

                    Console.WriteLine(key);
                }
                else if (command.Contains("Slice"))
                {
                    string pattern = @">>>(?<startIndex>[0-9]+)>>>(?<endIndex>[0-9]+)";

                    Match match = Regex.Match(command, pattern);

                    int startIndex = int.Parse(match.Groups["startIndex"].Value);
                    int endIndex = int.Parse(match.Groups["endIndex"].Value);
                    int count = endIndex - startIndex;

                    string currString = key.Remove(startIndex, count);

                    key = currString;

                    Console.WriteLine(key);
                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"Your activation key is: {key}");
        }
    }
}
