using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassroomProject
{
    public class Classroom
    {
        private List<Student> students;

        public Classroom(int capacity)
        {
            this.Capacity = capacity;
            this.students = new List<Student>();
        }

        public int Capacity { get; private set; }
        public int Count => this.students.Count;

        public string RegisterStudent(Student student)
        {
            if (this.Capacity <= this.Count)
            {
                return "No seats in the classroom";
            }
            else
            {
                this.students.Add(student);
                return $"Added student {student.FirstName} {student.LastName}";
            }
        }

        public string DismissStudent(string firstName, string lastName)
        {
            if (this.students.Contains(this.students.Find(x => x.FirstName == firstName && x.LastName == lastName)))
            {
                this.students.Remove(this.students.Find(x => x.FirstName == firstName && x.LastName == lastName));

                return $"Dismissed student {firstName} {lastName}";
            }
            else
            {
                return "Student not found";
            }
        }

        public string GetSubjectInfo(string subject)
        {
            var sb = new StringBuilder();

            var sortedStudents = this.students
                .Where(x => x.Subject == subject)
                .ToList();

            if (sortedStudents.Count <= 0)
            {
                sb.AppendLine("No students enrolled for the subject");
            }
            else
            {
                sb.AppendLine($"Subject: {subject}");
                sb.AppendLine("Students:");

                foreach (var student in sortedStudents)
                {
                    sb.AppendLine($"{student.FirstName} {student.LastName}");
                }
            }

            return sb.ToString().TrimEnd();
        }

        public int GetStudentsCount()
        {
            return this.Count;
        }

        public Student GetStudent(string firstName, string lastName)
        {
            return this.students.Find(x => x.FirstName == firstName && x.LastName == lastName);
        }
    }
}
