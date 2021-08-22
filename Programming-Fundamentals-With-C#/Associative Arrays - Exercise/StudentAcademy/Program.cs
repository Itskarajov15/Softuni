using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentAcademy
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<double>> gradesByStudent = new Dictionary<string, List<double>>();

            int input = int.Parse(Console.ReadLine());

            for (int i = 0; i < input; i++)
            {
                string name = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());

                if (!gradesByStudent.ContainsKey(name))
                {
                    gradesByStudent.Add(name, new List<double>());
                }

                gradesByStudent[name].Add(grade);
            }

            Dictionary<string, double> averageGrades = gradesByStudent
                .Select(x => new KeyValuePair<string, double>(x.Key, x.Value.Average()))
                .Where(x => x.Value >= 4.50)
                .OrderByDescending(x => x.Value)
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var student in averageGrades)
            {
                Console.WriteLine($"{student.Key} -> {student.Value:f2}");
            }
        }
    }
}
