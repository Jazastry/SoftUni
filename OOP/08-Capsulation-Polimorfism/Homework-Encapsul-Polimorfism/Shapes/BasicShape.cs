using System;

namespace Shapes
{
    // Define an abstract class BasicShape implementing
    // IShape and holding width and height. Leave the methods
    // CalculateArea() and CalculatePerimeter() abstract.
    public abstract class BasicShape : IShape
    {
        private double width;
        private double height;

        public double Width { get; private set; }
        public double Height { get; private set; }

        public BasicShape(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        public BasicShape() { }
        public abstract double CalculateArea();

        public abstract double CalculatePerimeter();
    }
}
