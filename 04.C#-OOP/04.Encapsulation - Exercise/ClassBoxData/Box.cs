using System;
using System.Collections.Generic;
using System.Text;

namespace ClassBoxData
{
    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        public double Length
        {
            get
            {
                return this.length;
            }
            private set
            {
                ThrowIfInvalidSide(value, nameof(this.Length));

                this.length = value;
            }
        }
        public double Width
        {
            get
            {
                return this.width;
            }
            private set
            {
                ThrowIfInvalidSide(value, nameof(this.Width));

                this.width = value;
            }
        }
        public double Height
        {
            get
            {
                return this.height;
            }
            private set
            {
                ThrowIfInvalidSide(value, nameof(this.Height));

                this.height = value;
            }
        }

        public double SurfaceArea()
        {
            double result = 2 * (this.Width * this.Length) + 2 * (this.Length * this.Height) + 2 * (this.Width * this.Height);

            return result;
        }

        public double LateralSurfaceArea()
        {
            double result = 2 * (this.Length * this.Height) + 2 * (this.Width * this.Height);

            return result;
        }

        public double Volume()
        {
            double result = this.Length * this.Width * this.Height;

            return result;
        }

        private void ThrowIfInvalidSide(double value, string side)
        {
            if (value <= 0)
            {
                throw new ArgumentException($"{side} cannot be zero or negative.");
            }
        }
    }
}
