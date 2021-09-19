using System;
using System.Collections.Generic;
using System.Text;

namespace CarSalesman
{
    public class Engine
    {
        // Model: a string property.
        // Power: an int property.
        // Displacement: an int property, it is optional.
        // Efficiency: a string property, it is optional.

        public Engine(string model, int power)
        {
            this.Model = model;
            this.Power = power;
        }

        public string Model { get; set; }
        public int Power { get; set; }
        public int Displacement { get; set; }
        public string Efficiency { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"  {this.Model}:");
            sb.AppendLine($"    Power: {this.Power}");
            sb.AppendLine(Displacement == 0 ? "    Displacement: n/a" : $"    Displacement: {Displacement}");
            sb.AppendLine(String.IsNullOrEmpty(Efficiency) ? "    Efficiency: n/a" : $"    Efficiency: {Efficiency}");

            return sb.ToString().TrimEnd();
        }
    }
}
