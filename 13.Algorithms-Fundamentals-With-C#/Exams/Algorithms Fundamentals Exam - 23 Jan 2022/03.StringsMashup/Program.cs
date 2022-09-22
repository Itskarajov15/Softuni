using System;
using System.Collections.Generic;
using System.ComponentModel.Design;

namespace _03.StringsMashup
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var text = Console.ReadLine();
            var list = new List<string>();

            DFS(text.ToLower().ToCharArray(), list, 0, text.Length);

            Console.WriteLine(String.Join("\n", list));
        }

        private static void DFS(char[] charArr, List<string> list, int i, int len)
        {
            if (i >= len)
            {
                list.Add(String.Join("", charArr));
            }

            if (i < len)
            {
                DFS(charArr, list, i + 1, len);

                if (Char.IsLetter(charArr[i]))
                {
                    charArr[i] = Char.ToUpper(charArr[i]);
                    DFS(charArr, list, i + 1, len);
                    charArr[i] = Char.ToLower(charArr[i]);
                }
            }
        }
    }
}