using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingPerformanceTests
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] ints = new int[] { 3, 5, 8, 10, 12, 55, 88, 76, 33, 44, 55, 88, 358, 67};
            double[] doubles = new double[] { 33.55, 3.2, 12.578, 1241234.4456, 1.8, 55.6, 77.99565, 1.776, 333, 88};
            string[] strings = new string[] { "asd", "dfg", "wersvs", "ertgvsdv456", "adf435", "dfsghti", "poiuyHJK"};

            SortingAlgorithms<int> intTest = new SortingAlgorithms<int>(ints);
            intTest.Process();

            SortingAlgorithms<double> doubleTest = new SortingAlgorithms<double>(doubles);
            doubleTest.Process();

            SortingAlgorithms<string> stringTest = new SortingAlgorithms<string>(strings);
            stringTest.Process();
        }            
    }
}
