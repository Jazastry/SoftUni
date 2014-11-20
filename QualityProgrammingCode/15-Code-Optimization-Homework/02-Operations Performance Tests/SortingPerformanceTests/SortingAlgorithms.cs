using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace SortingPerformanceTests
{
    class SortingAlgorithms<T> where T : IComparable
    {
        private T[] testArray;

        private string[] methodsName = new string[] { "Selection Sort", "Insertion Sort", "Quick Sort - recursive"};

        private T[] SelectionSort(T[] array)
        {
            int maxIndex;
            T temp;
            for (int i = array.Length - 1; i > 0; i--)
            {
                maxIndex = 0; // maxIndex keeps track of index of next maximum element in the array
                // this for loop is for finding next maximum element index
                for (int j = 1; j <= i; j++)
                {
                    // if current element if greater than element at maxIndex, then update maxIndex
                    if (array[j].CompareTo(array[maxIndex]) > 0)
                        maxIndex = j;
                }
                // Now put the next maximum element in its correct position
                temp = array[maxIndex];
                array[maxIndex] = array[i];
                array[i] = temp;
            }

            return array;
        }        

        private T[] InsertionSort(T[] array) 
        {
            T temp;
            int j;
            for (int i = 1; i < array.Length; i++)
            {
                temp = array[i];
                j = i - 1;
                while (j >= 0 && (array[j].CompareTo(temp) > 0))
                {
                    array[j + 1] = array[j];
                    j--;
                }                

                array[j + 1] = temp;
            }

            return array;
        }

        public static void QuickSort(T[] elements, int left, int right)
        {
            int i = left, j = right;
            T pivot = elements[(left + right) / 2];

            while (i <= j)
            {
                while (elements[i].CompareTo(pivot) < 0)
                {
                    i++;
                }

                while (elements[j].CompareTo(pivot) > 0)
                {
                    j--;
                }

                if (i <= j)
                {
                    // Swap
                    T tmp = elements[i];
                    elements[i] = elements[j];
                    elements[j] = tmp;

                    i++;
                    j--;
                }
            }

            // Recursive calls
            if (left < j)
            {
                QuickSort(elements, left, j);
            }

            if (i < right)
            {
                QuickSort(elements, i, right);
            }
        }

        private T[] UseQiockSort(T[] inputArray) 
        {
            T[] innerArray = inputArray;
            QuickSort(innerArray, 0, inputArray.Length - 1);

            return innerArray;
        }
            
        public SortingAlgorithms(T[] inputArray)
        {
            this.TestArray = inputArray;
        }

        public T[] TestArray
        {
            get { return this.testArray; }
            set 
            {
                string elementType = value.GetType().GetElementType().ToString();
                if (value.Length < 2)
                {
                    throw new ArgumentException(String.Format("Array provided shoud have atleast 2 elements length"));
                }
                else if ((elementType != "System.Int32") &&
                        (elementType != "System.Double") &&
                        (elementType != "System.String"))
                {
                    throw new ArgumentException(String.Format("Array elements have to be" +
                        " of type int, double or string"));
                }
                this.testArray = value;
            }
        }

        public void Process()
        {
            Func<T[], T[]>[] sortingMethods = new Func<T[], T[]>[]
            {
                new Func<T[], T[]>(SelectionSort),
                new Func<T[], T[]>(InsertionSort),
                new Func<T[], T[]>(UseQiockSort)
            };

            Stopwatch stopwatch = new Stopwatch();

            T[] curentSort;
            double average = 0;
            Console.WriteLine("Results for array with {0} elements", testArray.GetType().GetElementType());

            for (int i = 0; i < sortingMethods.Length; i++)
            {
                stopwatch.Start();

                curentSort = sortingMethods[i](this.TestArray);
            
                stopwatch.Stop();

                Console.WriteLine("{0} : {1} milsec.", this.methodsName[i], stopwatch.Elapsed.TotalMilliseconds);
                average += stopwatch.Elapsed.TotalMilliseconds;
                stopwatch.Reset();
            }
            average = average / sortingMethods.Length;
            Console.WriteLine("Average: {0}\n", average);        
        }
    }
}
