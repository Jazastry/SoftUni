using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationsPerformanceTestsB
{
    using System;
    using System.Diagnostics;

    public delegate T MethodProcess<T>(T inNumbA, T inNUmbB);

    class ComparePerformanceFloatingTypes
    {
        private Object[] processNumbs;
        private Object[] ProcessNumbs
        {
            get { return this.processNumbs; }

            set
            {
                dynamic test;
                for (int i = 0; i < value.Length; i++)
                {
                    decimal a = 0;
                    test = value[i];
                    if (test % 1 != 0)
                    {
                        throw new ArgumentException(String.Format("Cant process {0} only " +
                            "float and double are processed.", value[i]));
                    }
                }
                this.processNumbs = value;
            }
        }
        private int processLength { get; set; }

        private string[] methods = new[] {"Square Root", "Natural Logarithm", "Sinus"};

        private void ProcessNumb<T>(T processNumb)
        {
            Func<T, T>[] methodArray = new Func<T, T>[]
            {
                new Func<T, T>(SquareRoot),
                new Func<T, T>(Logarithm),
                new Func<T, T>(Sinus)
            };

            Stopwatch stopwatch = new Stopwatch();

            T curentProcessNumb;
            double average = 0;
            Console.WriteLine("Results for {0}", processNumb.GetType());
            for (int j = 0; j < methodArray.Length; j++)
            {
                stopwatch.Start();
                for (int i = 0; i < this.processLength; i++)
                {
                    curentProcessNumb = methodArray[j](processNumb);
                }
                stopwatch.Stop();

                Console.WriteLine("{0}: numb {1}, actions {2}, time {3} milsec.",
                    this.methods[j], processNumb, this.processLength, stopwatch.Elapsed.Milliseconds);
                average += stopwatch.Elapsed.Milliseconds;
                stopwatch.Reset();
            }
            average = average / methodArray.Length;
            Console.WriteLine("Average: {0}\n", average);
        }

        private T SquareRoot<T>(T value)
        {
            dynamic a = TransiteDecimal(value);
            var result = Math.Sqrt(a);

            return result;
        }

        private T Logarithm<T>(T value)
        {
            dynamic a = TransiteDecimal(value);
            var result = Math.Log(a);

            return result;
        }

        private T Sinus<T>(T value)
        {
            dynamic a = TransiteDecimal(value);
            var result = Math.Sin(a);

            return result;
        }
      
        public ComparePerformanceFloatingTypes(Object[] numbsArray, int processLength)
        {
            this.ProcessNumbs = numbsArray;
            this.processLength = processLength;
        }

        private static Object TransiteDecimal(Object transit)
        {
            if (transit is decimal)
            {
                return Convert.ToDouble(transit);
            }
            return transit;
        }

        public void Process()
        {
            Console.WriteLine("All decimal values are not realistic, using cat to double.");
            for (int i = 0; i < this.processNumbs.Length; i++)
            {
                ProcessNumb(processNumbs[i]);
            }
        }
    }
}
