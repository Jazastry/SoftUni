using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry3DA
{
    public class Path3D : List<Point3D>
    {
        private List<Point3D> points3D = new List<Point3D>();
        public Path3D()
        {
        }
        public List<Point3D> PointsList3D
        {
            get
            {
                return points3D;
            }
        }
        public Point3D PointsIn3D
        {
            set
            {
                points3D.Add(value);
            }
        }
        public Path3D(List<Point3D> inPointList)
        {
            this.points3D = inPointList;
        }
    }
}
