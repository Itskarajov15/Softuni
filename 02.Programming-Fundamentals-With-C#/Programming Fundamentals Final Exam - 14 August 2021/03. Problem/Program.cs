using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Problem
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> sentMessages = new Dictionary<string, int>();
            Dictionary<string, int> receivedMessages = new Dictionary<string, int>();

            int capacity = int.Parse(Console.ReadLine());

            string[] commands = Console.ReadLine()
                .Split("=", StringSplitOptions.RemoveEmptyEntries);

            while (commands[0] != "Statistics")
            {
                if (commands[0] == "Add")
                {
                    string username = commands[1];
                    int sent = int.Parse(commands[2]);
                    int received = int.Parse(commands[3]);

                    if (!sentMessages.ContainsKey(username))
                    {
                        sentMessages.Add(username, sent);
                        receivedMessages.Add(username, received);
                    }
                }
                else if (commands[0] == "Message")
                {
                    string sender = commands[1];
                    string receiver = commands[2];

                    if (sentMessages.ContainsKey(sender) && sentMessages.ContainsKey(receiver))
                    {
                        sentMessages[sender]++;
                        receivedMessages[receiver]++;

                        int messagesOfSender = sentMessages[sender] + receivedMessages[sender];
                        int messagesOfReceiver = sentMessages[receiver] + receivedMessages[receiver];

                        if (messagesOfSender >= capacity)
                        {
                            Console.WriteLine($"{sender} reached the capacity!");

                            sentMessages.Remove(sender);
                            receivedMessages.Remove(sender);
                        }

                        if (messagesOfReceiver >= capacity)
                        {
                            Console.WriteLine($"{receiver} reached the capacity!");

                            sentMessages.Remove(receiver);
                            receivedMessages.Remove(receiver);
                        }
                    }
                }
                else if (commands[0] == "Empty")
                {
                    string username = commands[1];

                    if (username == "All")
                    {
                        sentMessages.Clear();
                        receivedMessages.Clear();

                        commands = Console.ReadLine()
                            .Split("=", StringSplitOptions.RemoveEmptyEntries);
                        continue;
                    }

                    if (sentMessages.ContainsKey(username))
                    {
                        sentMessages.Remove(username);
                        receivedMessages.Remove(username);
                    }
                }

                commands = Console.ReadLine()
                .Split("=", StringSplitOptions.RemoveEmptyEntries);
            }

            receivedMessages = receivedMessages
                .OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            Console.WriteLine($"Users count: {sentMessages.Count}");

            foreach (var username in receivedMessages)
            {
                int numberOfAllMessages = sentMessages[username.Key] + receivedMessages[username.Key];

                Console.WriteLine($"{username.Key} - {numberOfAllMessages}");
            }
        }
    }
}
