using System;

namespace Shapes
{
    // Define two new BasicShape subclasses: Triangle and 
    // Rectangle that implement the abstract methods CalculateArea()
    // and CalculatePerimeter().
    public class Triangle : BasicShape, IShape
    {
        public Triangle(double width, double height)
            : base (width, height) { }
        public override double CalculateArea()
        {
            double a = this.Width;
            double b = this.Height;

            double result = (a*b)/2;
            return result;
        }

        public override double CalculatePerimeter()
        {
            double a = Math.Pow(this.Width, 2);
            double b = Math.Pow(this.Height, 2);
            double result = Math.Sqrt(a + b);
            return result;
        }
    }
}
