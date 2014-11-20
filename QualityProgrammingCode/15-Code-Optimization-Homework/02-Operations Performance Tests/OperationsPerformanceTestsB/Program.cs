using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationsPerformanceTestsB
{
    class Program
    {
        static void Main(string[] args)
        {
            float floatNumb = 200f;
            double doubleNumb = 200d;
            decimal decNumb = 200m;

            Object[] array = new object[]
            {
                floatNumb, doubleNumb, decNumb
            };
            // Decimal results are not realistic used cast to double
            ComparePerformanceFloatingTypes compare = new ComparePerformanceFloatingTypes(numbsArray: array,                                processLength: 200);
            compare.Process();
        }
    }
}
