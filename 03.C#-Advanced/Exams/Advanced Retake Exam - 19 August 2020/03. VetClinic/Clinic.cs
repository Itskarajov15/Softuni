using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VetClinic
{
    public class Clinic
    {
        private List<Pet> pets;

        public Clinic(int capacity)
        {
            this.Capacity = capacity;
            this.pets = new List<Pet>();
        }

        public int Count => this.pets.Count;

        public int Capacity { get; private set; }

        public void Add(Pet pet)
        {
            if (this.Count < this.Capacity)
            {
                pets.Add(pet);
            }
        }

        public bool Remove(string name)
        {
            return this.pets.Remove(this.pets.Find(p => p.Name == name));
        }

        public Pet GetPet(string name, string owner)
        {
            return this.pets.Find(p => p.Name == name && p.Owner == owner);
        }

        public Pet GetOldestPet()
        {
            return this.pets.OrderByDescending(p => p.Age).FirstOrDefault();
        }

        public string GetStatistics()
        {
            var sb = new StringBuilder();

            sb.AppendLine("The clinic has the following patients:");

            foreach (var pet in this.pets)
            {
                sb.AppendLine($"Pet {pet.Name} with owner: {pet.Owner}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
