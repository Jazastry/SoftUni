using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry3DA
{
    public class DistanceCalculator
    {
        public static double CalculateTheDistanceTwoPoints(Point3D a, Point3D b)
        {
            double result = 0;
            double processX = Math.Pow((a.PointX - b.PointX), 2);
            double processY = Math.Pow((a.PointY - b.PointY), 2);
            double processZ = Math.Pow((a.PointZ - b.PointZ), 2);
            result = Math.Sqrt(processX + processY + processZ);
            return result;
        }
        public static double CalculateTheDistanceFromPath(Path3D inPath)
        {
            double result = 0;
            int counter = 0;
            Point3D first = new Point3D();
            Point3D second = new Point3D();
            foreach (var item in inPath.PointsList3D)
            {
                if (counter == 0)
                {
                    first = item;
                    counter++;
                    continue;
                }
                second = item;
                result += DistanceCalculator.CalculateTheDistanceTwoPoints(first, second);
                first = second;
            }

            return result;
        }
    }
}
