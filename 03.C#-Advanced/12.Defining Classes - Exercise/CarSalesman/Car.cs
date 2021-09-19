using System;
using System.Collections.Generic;
using System.Text;

namespace CarSalesman
{
    public class Car
    {
        // Model: a string property.
        // Engine: a property holding the engine object.
        // Weight: an int property, it is optional.
        // Color: a string property, it is optional.

        public Car(string model, Engine engine)
        {
            this.Model = model;
            this.Engine = engine;
        }

        public string Model { get; set; }
        public Engine Engine { get; set; }
        public int Weight { get; set; }
        public string Color { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"{Model}:");
            sb.AppendLine(Engine.ToString());
            sb.AppendLine(Weight == 0 ? $"  Weight: n/a" : $"  Weight: {Weight}");
            sb.AppendLine(String.IsNullOrEmpty(Color) ? "  Color: n/a" : $"  Color: {Color}");

            return sb.ToString().TrimEnd();
        }
    }
}
