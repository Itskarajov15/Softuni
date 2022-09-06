using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04.Cinema
{
    internal class Program
    {
        private static List<string> nonStaticPeople;
        private static string[] people;
        private static bool[] locked;

        static void Main(string[] args)
        {
            nonStaticPeople = Console.ReadLine()
                               .Split(", ")
                               .ToList();

            people = new string[nonStaticPeople.Count];
            locked = new bool[nonStaticPeople.Count];

            var input = Console.ReadLine();

            while (input != "generate")
            {
                var splitedInput = input.Split(" - ").ToArray();

                var name = splitedInput[0];
                var position = int.Parse(splitedInput[1]) - 1;

                people[position] = name;
                locked[position] = true;

                nonStaticPeople.Remove(name);

                input = Console.ReadLine();
            }

            Permute(0);
        }

        private static void Permute(int idx)
        {
            if (idx >= nonStaticPeople.Count)
            {
                Print();
                return;
            }

            Permute(idx + 1);

            for (int i = idx + 1; i < nonStaticPeople.Count; i++)
            {
                Swap(idx, i);
                Permute(idx + 1);
                Swap(idx, i);
            }
        }

        private static void Print()
        {
            var peopleIdx = 0;
            var sb = new StringBuilder();

            for (int i = 0; i < people.Length; i++)
            {
                if (!locked[i])
                {
                    people[i] = nonStaticPeople[peopleIdx++];
                }
            }

            Console.WriteLine(String.Join(" ", people));
        }

        private static void Swap(int first, int second)
        {
            var temp = nonStaticPeople[first];
            nonStaticPeople[first] = nonStaticPeople[second];
            nonStaticPeople[second] = temp;
        }
    }
}