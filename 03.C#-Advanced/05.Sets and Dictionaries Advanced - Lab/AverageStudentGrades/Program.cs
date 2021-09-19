using System;
using System.Collections.Generic;
using System.Linq;

namespace AverageStudentGrades
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<decimal>> grades = new Dictionary<string, List<decimal>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] nameAndGrade = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string student = nameAndGrade[0];
                decimal grade = 0M;

                if (!grades.ContainsKey(student))
                {
                    grades.Add(student, new List<decimal>());
                }

                if (decimal.TryParse(nameAndGrade[1], out grade))
                {
                    grades[student].Add(grade);
                }
            }

            foreach (var grade in grades)
            {
                Console.WriteLine($"{grade.Key} -> {String.Join(" ", grade.Value.Select(v => v.ToString("F2")))} (avg: {grade.Value.Average():f2})");
            }
        }
    }
}
