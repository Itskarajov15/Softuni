using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BakeryOpenning
{
    public class Bakery
    {
        public Bakery(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.Employees = new List<Employee>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public List<Employee> Employees { get; set; }

        public int Count
        {
            get => this.Employees.Count;
        }

        public void Add(Employee employee)
        {
            if (this.Employees.Count < this.Capacity)
            {
                this.Employees.Add(employee);
            }
        }

        public bool Remove(string name)
        {
            return this.Employees.Remove(this.Employees.Find(x => x.Name == name));
        }

        public Employee GetOldestEmployee()
        {
            return this.Employees.OrderByDescending(x => x.Age).FirstOrDefault();
        }

        public Employee GetEmployee(string name)
        {
            return this.Employees.Find(x => x.Name == name);
        }

        public string Report()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Employees working at Bakery {this.Name}:");

            foreach (var employee in this.Employees)
            {
                sb.AppendLine($"{employee}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
