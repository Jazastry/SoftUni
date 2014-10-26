using System;
using System.Collections.Generic;

namespace Shapes
{
    class SolutionShapesProblem
    {
        static void Main()
        {
            Triangle myTriangle = new Triangle(4, 8);
            Rectangle myRectangle = new Rectangle(4, 8);
            Circle myCircle = new Circle(6);

            List<IShape> shapes = new List<IShape>()
            {
                myCircle, myRectangle, myTriangle
            };

            shapes.ForEach(shape => Console.WriteLine(shape
                .GetType().ToString() + " - Area = " +  shape.CalculateArea()));

            shapes.ForEach(shape => Console.WriteLine(shape
                .GetType().ToString() + " - Perimeter = " + shape.CalculatePerimeter()));

            double shapesAreasTogether = 0;
            shapes.ForEach(shape => shapesAreasTogether += shape.CalculateArea());
            Console.WriteLine("\nShapes Areas Together = {0}", shapesAreasTogether);

            double shapesPerimetersTogether = 0;
            shapes.ForEach(shape => shapesPerimetersTogether += shape.CalculatePerimeter());
            Console.WriteLine("\nShapes Perimeters Together = {0}", shapesPerimetersTogether);
        }
    }
}
