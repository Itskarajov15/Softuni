using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftUniCoursePlanning
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> plan = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string[] command = Console.ReadLine()
                .Split(':');

            while (command[0] != "course")
            {
                string lessonTitle = command[1];

                if (command[0] == "Add")
                {
                    if (plan.Contains(lessonTitle))
                    {
                        command = Console.ReadLine()
                        .Split(':');
                        continue;
                    }
                    else
                    {
                        plan.Add(lessonTitle);
                    }
                }
                else if (command[0] == "Insert")
                {
                    int index = int.Parse(command[2]);

                    if (plan.Contains(lessonTitle))
                    {
                        command = Console.ReadLine()
                        .Split(':');
                        continue;
                    }
                    else
                    {
                        plan.Insert(index, lessonTitle);
                    }
                }
                else if (command[0] == "Remove")
                {
                    if (plan.Contains(lessonTitle))
                    {
                        plan.Remove(lessonTitle);
                    }
                    else
                    {
                        command = Console.ReadLine()
                        .Split(':');
                        continue;
                    }
                }
                else if (command[0] == "Swap")
                {
                    int indexOfTheFirstLesson = 0;
                    int indexOfTheSecondLesson = 0;

                    for (int i = 0; i < plan.Count; i++)
                    {
                        if (plan[i] == command[1])
                        {
                            indexOfTheFirstLesson = i;
                        }
                        else if (plan[i] == command[2])
                        {
                            indexOfTheSecondLesson = i;
                        }
                    }

                    int temp = indexOfTheFirstLesson;
                    plan[indexOfTheFirstLesson] = plan[indexOfTheSecondLesson];
                    plan[indexOfTheSecondLesson] = plan[temp];
                }
                else if (command[0] == "Exercise")
                {

                }

                command = Console.ReadLine()
                .Split();
            }
        }
    }
}
