using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03._StreetRacing
{
    public class Race
    {
        public Race(string name, string type, int laps, int capacity,
            int maxHorsePower)
        {
            this.Name = name;
            this.Type = type;
            this.Laps = laps;
            this.Capacity = capacity;
            this.MaxHorsePower = maxHorsePower;
            this.Participants = new List<Car>();
        }

        public List<Car> Participants { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Laps { get; set; }
        public int Capacity { get; set; }
        public int MaxHorsePower { get; set; }
        public int Count
        {
            get { return Participants.Count; }
        }

        public void Add(Car car)
        {
            if (!Participants.Any(x => x.LicensePlate == car.LicensePlate)
                && this.Count < this.Capacity
                && this.MaxHorsePower >= car.HorsePower)
            {
                Participants.Add(car);
            }
        }

        public bool Remove(string licensePlate)
        {
            return Participants.Remove(Participants.Find(x => x.LicensePlate == licensePlate));
        }

        public Car FindParticipant(string licensePlate)
        {
            return Participants.Find(x => x.LicensePlate == licensePlate);
        }

        public Car GetMostPowerfulCar()
        {
            return Participants.OrderByDescending(x => x.HorsePower).FirstOrDefault();
        }

        public string Report()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Race: {this.Name} - Type: {this.Type} (Laps: {this.Laps})");

            foreach (var participant in this.Participants)
            {
                sb.AppendFormat($"{participant}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
