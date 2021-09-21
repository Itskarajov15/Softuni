using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03._SkiRental
{
    public class SkiRental
    {
        public SkiRental(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.Data = new List<Ski>();
        }

        public List<Ski> Data { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }

        public int Count
        {
            get { return this.Data.Count; }
        }

        public void Add(Ski ski)
        {
            if (Data.Count < this.Capacity)
            {
                Data.Add(ski);
            }
        }

        public bool Remove(string manufacturer, string model)
        {
            return Data.Remove(Data.Find(x => x.Manufacturer == manufacturer && x.Model == model));
        }

        public Ski GetNewestSki()
        {
            return Data.OrderByDescending(x => x.Year).FirstOrDefault();
        }

        public Ski GetSki(string manufacturer, string model)
        {
            return Data.Find(x => x.Manufacturer == manufacturer && x.Model == model);
        }

        public string GetStatistics()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"The skis stored in {this.Name}:");

            foreach (var pairOfSki in Data)
            {
                sb.AppendLine($"{pairOfSki}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
