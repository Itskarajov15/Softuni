using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Problem
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> originalDeck = Console.ReadLine()
                .Split(':', StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            List<string> newDeck = new List<string>();

            string[] command = Console.ReadLine()
                .Split();

            while (command[0] != "Ready")
            {
                if (command[0] == "Add")
                {
                    string card = command[1];

                    if (originalDeck.Contains(card))
                    {
                        newDeck.Add(card);
                    }
                    else
                    {
                        Console.WriteLine("Card not found.");
                    }
                }
                else if (command[0] == "Insert")
                {
                    string card = command[1];
                    int index = int.Parse(command[2]);

                    if (originalDeck.Contains(card))
                    {
                        if (index >= 0 && index < newDeck.Count)
                        {
                            newDeck.Insert(index, card);
                        }
                        else
                        {
                            Console.WriteLine("Error!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Error!");
                    }
                }
                else if (command[0] == "Remove")
                {
                    string card = command[1];

                    if (newDeck.Contains(card))
                    {
                        newDeck.Remove(card);
                    }
                    else
                    {
                        Console.WriteLine("Card not found.");
                    }
                }
                else if (command[0] == "Swap")
                {
                    string firstCard = command[1];
                    string secondCard = command[2];

                    newDeck = SwapsThePositionsOfTwoCards(newDeck, firstCard, secondCard);
                }
                else if (command[0] == "Shuffle")
                {
                    newDeck.Reverse();
                }

                command = Console.ReadLine()
                .Split();
            }

            Console.WriteLine(String.Join(" ", newDeck));
        }

        static List<string> SwapsThePositionsOfTwoCards(List<string> newDeck, string firstCard, string secondCard)
        {
            int indexOfTheFirstCard = newDeck.FindIndex(a => a.Contains(firstCard));
            int indexOfTheSecondCard = newDeck.FindIndex(a => a.Contains(secondCard));

            newDeck[indexOfTheFirstCard] = secondCard;
            newDeck[indexOfTheSecondCard] = firstCard;

            return newDeck;
        }
    }
}
