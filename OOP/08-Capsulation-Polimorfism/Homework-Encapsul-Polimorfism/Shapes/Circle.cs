using System;

namespace Shapes
{
    class Circle : IShape
    {
        private double radius;

        public double Radius
        {
            get { return this.radius; }
            set { this.radius = value; }
        }

        public Circle(double radius)
        {
            this.Radius = radius;
        }

        public double CalculateArea()
        {
            double rPow = Math.Pow(this.Radius, 2);
            double area = Math.PI * rPow;
            return area;
        }

        public double CalculatePerimeter()
        {
            double r = this.Radius;
            double perimeter = (r*r)*Math.PI;
            return perimeter;
        }
    }
}
