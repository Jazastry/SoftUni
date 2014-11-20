using System.ComponentModel;
using System.Reflection;

namespace OperationsPerformanceTestsA
{
    using System;
    using System.Diagnostics;

    public delegate T MethodProcess<T>(T inNumbA, T inNUmbB);

    // Write a program to compare the performance of add, subtract,
    // increment, multiply, divide for int, long, float, double and decimal values.
    class ComparePerformanceAllNumbTypes
    {
        private Object[] processNumbs { get; set; }
        private int processLength { get; set; }

        private string[] methods = new[] {"Addition", "Substraction", "Multiply", "Devision"};

        private  void ProcessNumb<T>(T processNumb)
        {
            Func<T, T>[] methodArray = new Func<T, T>[]
            {
                new Func<T, T>(Addition), 
                new Func<T, T>(Substract),
                new Func<T, T>(Multyply),
                new Func<T, T>(Devide),
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
            average = average/methodArray.Length;
            Console.WriteLine("Average: {0}\n", average);
        }


        private  T Addition<T>(T value)
        {
            dynamic a = value;
            var result = a + a;

            return result;
        }

        private T Substract<T>(T value)
        {
            dynamic a = value;
            var result = a - a;

            return result;
        }

        private T Multyply<T>(T value)
        {
            dynamic a = value;
            var result = a * a;

            return result;
        }

        private T Devide<T>(T value)
        {
            dynamic a = value;
            var result = a / a;

            return result;
        }

        public ComparePerformanceAllNumbTypes(Object[] numbsArray, int processLength)
        {
            this.processNumbs = numbsArray;
            this.processLength = processLength;
        }

        public  void Process()
        {
            for (int i = 0; i < this.processNumbs.Length; i++)
            {
                ProcessNumb(processNumbs[i]);
            }
        }
    }
}
