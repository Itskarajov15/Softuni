using System;

namespace _01._Problem
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            string[] commands = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            while (commands[0] != "End")
            {
                if (commands[0] == "Translate")
                {
                    char oldChar = char.Parse(commands[1]);
                    char newChar = char.Parse(commands[2]);

                    text = text.Replace(oldChar, newChar);

                    Console.WriteLine(text);
                }
                else if (commands[0] == "Includes")
                {
                    string textToCheck = commands[1];

                    bool isInTheText = text.Contains(textToCheck);

                    Console.WriteLine(isInTheText);
                }
                else if (commands[0] == "Start")
                {
                    string givenString = commands[1];

                    bool startsWithTheString = text.StartsWith(givenString);

                    Console.WriteLine(startsWithTheString);
                }
                else if (commands[0] == "Lowercase")
                {
                    text = text.ToLower();

                    Console.WriteLine(text);
                }
                else if (commands[0] == "FindIndex")
                {
                    char givenChar = char.Parse(commands[1]);

                    int lastIndex = text.LastIndexOf(givenChar);

                    Console.WriteLine(lastIndex);
                }
                else if (commands[0] == "Remove")
                {
                    int startIndex = int.Parse(commands[1]);
                    int count = int.Parse(commands[2]);

                    text = text.Remove(startIndex, count);

                    Console.WriteLine(text);
                }

                commands = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }
        }
    }
}
