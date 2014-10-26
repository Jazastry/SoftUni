using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheSlum
{
    public class Utils
    {
        public static double CalculateDistance(int x1, int y1, int x2, int y2)
        {
            double result = Math.Sqrt(Math.Pow((x2 - x1), 2) + (Math.Pow((y2 - y1), 2)));
            return result;
        }
    }
}
