using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text.RegularExpressions;

namespace EmojiDetector
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> sumsByEmojis = new Dictionary<string, int>();

            Regex emojiRegex = new Regex(@"(:{2}|\*{2})(?<emojiName>[A-Z][a-z]{2,})(\1)");
            Regex digitRegex = new Regex(@"[0-9]");

            BigInteger coolThreshold = 1;

            string input = Console.ReadLine();

            MatchCollection digitMatches = digitRegex.Matches(input);

            foreach (Match digit in digitMatches)
            {
                coolThreshold *= int.Parse(digit.Value);
            }

            MatchCollection emojiMatch = emojiRegex.Matches(input);

            foreach (Match emoji in emojiMatch)
            {
                int sumOfCurrEmoji = 0;

                if (!sumsByEmojis.ContainsKey(emoji.Value))
                {
                    sumsByEmojis.Add(emoji.Value, 0);
                }

                foreach (char letter in emoji.Value)
                {
                    if (Char.IsLetterOrDigit(letter))
                    {
                        sumOfCurrEmoji += (char)letter;
                    }
                }

                sumsByEmojis[emoji.Value] = sumOfCurrEmoji;
            }

            sumsByEmojis = sumsByEmojis
            .Where(x => x.Value > coolThreshold)
            .ToDictionary(x => x.Key, x => x.Value);

            Console.WriteLine($"Cool threshold: {coolThreshold}");
            Console.WriteLine($"{emojiMatch.Count} emojis found in the text. The cool ones are:");

            if (sumsByEmojis.Count != 0)
            {
                foreach (var emoji in sumsByEmojis)
                {
                    Console.WriteLine(emoji.Key);
                }
            }
        }
    }
}