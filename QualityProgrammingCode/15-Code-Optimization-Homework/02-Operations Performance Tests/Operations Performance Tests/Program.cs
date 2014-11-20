using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace OperationsPerformanceTestsA
{
    class Program
    {
        static void Main()
        {
            int intNumb = 200;
            long longNumb = 200;
            float floatNumb = 200f;
            double doubleNumb = 200d;
            decimal decimalNumb = 200m;

            Object[] array = new object[]
            {
                intNumb, longNumb, floatNumb, doubleNumb, decimalNumb
            };
            ComparePerformanceAllNumbTypes compare = new ComparePerformanceAllNumbTypes(numbsArray: array, processLength: 200);
            compare.Process();
        }
    }
}
