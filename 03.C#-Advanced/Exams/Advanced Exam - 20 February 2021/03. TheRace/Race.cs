using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheRace
{
    public class Race
    {
        public Race(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.Racers = new List<Racer>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public List<Racer> Racers { get; set; }
        public int Count
        {
            get => this.Racers.Count;
        }

        public void Add(Racer racer)
        {
            if (this.Racers.Count < this.Capacity)
            {
                this.Racers.Add(racer);
            }
        }

        public bool Remove(string name)
        {
            return this.Racers.Remove(this.Racers.Find(x => x.Name == name));
        }

        public Racer GetOldestRacer()
        {
            return this.Racers.OrderByDescending(x => x.Age).FirstOrDefault();
        }

        public Racer GetRacer(string name)
        {
            return this.Racers.Find(x => x.Name == name);
        }

        public Racer GetFastestRacer()
        {
            return this.Racers.OrderByDescending(x => x.Car.Speed).FirstOrDefault();
        }

        public string Report()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Racers participating at {this.Name}:");

            foreach (var racer in this.Racers)
            {
                sb.AppendLine($"{racer}");
            }

            return sb.ToString().TrimEnd();
        }
    }   
}
