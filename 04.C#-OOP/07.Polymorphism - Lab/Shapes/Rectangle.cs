using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Rectangle : Shape
    {
        private int height;
        private int width;

        public Rectangle(int height, int width)
        {
            this.height = height;
            this.width = width;
        }

        public int Height
        {
            get => this.height;
            private set
            {
                this.height = value;
            }
        }

        public int Width
        {
            get => this.width;
            private set
            {
                this.width = value;
            }
        }

        public override double CalculateArea()
        {
            return this.height * this.width;
        }

        public override double CalculatePerimeter()
        {
            return 2 * (this.width + this.height);
        }

        public override string Draw()
        {
            return base.ToString() + "Rectangle";
        }
    }
}
