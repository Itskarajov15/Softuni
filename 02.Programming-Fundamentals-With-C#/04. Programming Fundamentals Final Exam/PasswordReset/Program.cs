using System;
using System.Text;

namespace PasswordReset
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string newPassword = input;

            string[] command = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            while (command[0] != "Done")
            {
                if (command[0] == "TakeOdd")
                {
                    StringBuilder sb = new StringBuilder();

                    for (int i = 0; i < newPassword.Length; i++)
                    {
                        if (i % 2 != 0)
                        {
                            sb.Append(newPassword[i]);
                        }
                    }

                    newPassword = sb.ToString();

                    Console.WriteLine(newPassword);
                }
                else if (command[0] == "Cut")
                {
                    int index = int.Parse(command[1]);
                    int lenght = int.Parse(command[2]);

                    newPassword = newPassword.Remove(index, lenght);

                    Console.WriteLine(newPassword);
                }
                else if (command[0] == "Substitute")
                {
                    string substring = command[1];
                    string substitute = command[2];

                    if (!newPassword.Contains(substring))
                    {
                        Console.WriteLine("Nothing to replace!");
                    }
                    else
                    {
                        newPassword = newPassword.Replace(substring, substitute);

                        Console.WriteLine(newPassword);
                    }
                }

                command = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }

            Console.WriteLine($"Your password is: {newPassword}");
        }
    }
}
