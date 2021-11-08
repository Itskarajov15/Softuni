using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Circle : Shape
    {
        private int radius;

        public Circle(int radius)
        {
            this.radius = radius;
        }

        public int Radius
        {
            get => this.radius;
            private set
            {
                this.radius = value;
            }
        }

        public override double CalculateArea()
        {
            return Math.PI * Math.Sqrt(this.radius);
        }

        public override double CalculatePerimeter()
        {
            return 2 * Math.PI * this.radius;
        }

        public override string Draw()
        {
            return base.Draw() + "Circle";
        }
    }
}
