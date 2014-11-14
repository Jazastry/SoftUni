using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exceptions_Homework
{
    class Extensions
    {
        public static T[] Subsequence<T>(T[] arr, int startIndex, int count)
        {
            if ((arr.Length - 1 < startIndex) || (0 > startIndex))
            {
                throw new IndexOutOfRangeException(String.Format("Invalid Index {0}", startIndex));
            }
            else if (arr.Length - startIndex < count)
            {
                throw new ArgumentOutOfRangeException("count", "Count is Out of the string length !");
            }
            List<T> result = new List<T>();
            for (int i = startIndex; i < startIndex + count; i++)
            {
                result.Add(arr[i]);
            }
            return result.ToArray();
        }

        public static string ExtractEnding(string str, int count)
        {
            if (count > str.Length)
            {
                throw new ArgumentOutOfRangeException("count", "Count is out of string length!");
            }

            StringBuilder result = new StringBuilder();
            for (int i = str.Length - count; i < str.Length; i++)
            {
                result.Append(str[i]);
            }
            return result.ToString();
        }

        public static void CheckPrime(int number)
        {
            for (int divisor = 2; divisor <= Math.Sqrt(number); divisor++)
            {
                if (number%divisor == 0)
                {
                    Console.WriteLine("The number is not prime!");
                }
                else
                {
                    Console.WriteLine("The number is prime !");
                }
            }
        }
    }
}
