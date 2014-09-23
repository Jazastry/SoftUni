using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Geometry3DA;

public class Tests3DA
{
    static void Main()
    {
        // Use Point3D
        Point3D start = new Point3D(-7, -4, 3);
        Point3D middle = new Point3D(17, 6, 2.5);
        Point3D middle2 = new Point3D(19, 8, 3.7);
        Point3D end = new Point3D(25, 8, 3.7);

        // Create List of 3D Points
        List<Point3D> inList = new List<Point3D>();
        inList.Add(start);
        inList.Add(middle);
        inList.Add(middle2);
        inList.Add(end);

        // Use static StartingPoint{0,0,0}
        Console.WriteLine("// Use static StartingPoint{0,0,0}" + "\n" + Point3D.StartingPoint() + "\n");

        // Use Point3D ToString
        Console.WriteLine("// Use Point3D.ToString");
        Console.WriteLine("start : " + start);
        Console.WriteLine("middle : " + middle);
        Console.WriteLine("middle2 : " + middle2);
        Console.WriteLine("end : " + end + "\n");

        // Use DistanceCalculator
        Console.WriteLine("// Use DistanceCalculator.CalculateTheDistanceTwoPoints()");
        Console.WriteLine("DistanceCalculator.CalculateTheDistanceTwoPoints(start, middle) : \n" + DistanceCalculator.CalculateTheDistanceTwoPoints(start, middle));
        Console.WriteLine("DistanceCalculator.CalculateTheDistanceTwoPoints(middle, middle2) : \n" + DistanceCalculator.CalculateTheDistanceTwoPoints(middle, middle2));
        Console.WriteLine("DistanceCalculator.CalculateTheDistanceTwoPoints(middle2, end) : \n" + DistanceCalculator.CalculateTheDistanceTwoPoints(middle2, end) + "\n");

        // Use Path3D
        Path3D newPath = new Path3D(inList);
        Console.WriteLine("// Assign values to Path3D object\n");
        foreach (var item in newPath.PointsList3D)
        {
            // Take values     
            Console.WriteLine("{0}, {1}, {2}", item.PointX, item.PointY, item.PointZ);
            // Take Object
            Console.WriteLine(item);
        }
        Console.WriteLine();

        // Use Storage to create .txt file from Path3D object
        Console.WriteLine("// Use Storage to create .txt file from Path3D object \n(.txt file path -> ..\\02-Homework-Static-Mambers\\01-Point3-D\\bin\\Debug\\path.txt)\n");
        string txtFilePath = "path.txt";
        Storage.SavePathToTxt(txtFilePath, newPath);

        // Use Storage to extract Path3D object from .txt file
        Console.WriteLine("// Use Storage to extract Path3D object from .txt file -> same path as previous\n");
        Path3D extractPathFromTxt = new Path3D(Storage.ExtractPointListFromTxt(txtFilePath));
        Console.WriteLine("// Show extracted Path3D from .txt file");
        foreach (var item in extractPathFromTxt.PointsList3D)
        {
            // Show extracted Path3D from .txt file
            Console.WriteLine(item);
        }
        Console.WriteLine();

        // Use DistanceCalculator calculate path from Path3D object 
        Console.WriteLine("// Use DistanceCalculator calculate path from Path3D object");
        double distance = DistanceCalculator.CalculateTheDistanceFromPath(extractPathFromTxt);
        Console.WriteLine(distance);
       
    }
}

