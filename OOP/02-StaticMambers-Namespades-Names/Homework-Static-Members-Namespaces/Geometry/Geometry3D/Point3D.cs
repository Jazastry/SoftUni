using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry3DA
{
    public class Point3D
    {
        private double pointX;
        public double PointX
        {
            get
            {
                return this.pointX;
            }
            set
            {
                this.pointX = value;
            }
        }
        private double pointY;
        public double PointY
        {
            get
            {
                return pointY;
            }
            set
            {
                this.pointY = value;
            }
        }
        private double pointZ;
        public double PointZ
        {
            get
            {
                return pointZ;
            }
            set
            {
                this.pointZ = value;
            }
        }
        public Point3D()
        {

        }
        static readonly Point3D startingPoint = new Point3D(0, 0, 0);
        public static Point3D StartingPoint()
        {
            return Point3D.startingPoint;
        }
        public Point3D(double pointx, double pointy, double pointz)
        {
            this.pointX = pointx;
            this.PointY = pointy;
            this.pointZ = pointz;

        }
        public override string ToString()
        {
            return String.Format("Point3D(X={0}, Y={1}, Z={2})", this.PointX, this.PointY, this.PointZ);
        }
    }
}
