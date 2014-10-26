namespace Shapes
{
    public class Rectangle : BasicShape, IShape
    {
        public Rectangle(double width, double height)
            : base (width, height) { }
        public override double CalculateArea()
        {
            double a = this.Width;
            double b = this.Height;

            double result = a*b;
            return result;
        }

        public override double CalculatePerimeter()
        {
            double a = this.Width;
            double b = this.Height;
            double result = (a*2) + (b*2);
            return result;
        }
    }
}
