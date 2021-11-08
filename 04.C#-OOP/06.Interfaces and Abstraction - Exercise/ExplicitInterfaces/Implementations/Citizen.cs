using ExplicitInterfaces.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExplicitInterfaces.Implementations
{
    public class Citizen : IPerson, IResident
    {
        public Citizen(string name, string country, int age)
        {
            Name = name;
            Country = country;
            Age = age;
        }

        public string Name { get; set; }
        public string Country { get; set; }
        public int Age { get; set; }

        string IResident.GetName(string name)
        {
            return $"Mr/Ms/Mrs {name}";
        }

        string IPerson.GetName(string name)
        {
            return name;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            string iResidentName = (this as IResident).GetName(Name);
            string iPersonName = (this as IPerson).GetName(Name);

            sb.AppendLine($"{iPersonName}");
            sb.AppendLine($"{iResidentName}");

            return sb.ToString().TrimEnd();
        }
    }
}
