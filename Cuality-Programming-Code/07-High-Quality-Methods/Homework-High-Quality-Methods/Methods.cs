using System;

namespace Methods
{
    class Methods
    {
        static double CalcTriangleArea(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
            {
                throw new ArgumentException("Sides should be positive.");
            }
            double s = (a + b + c) / 2;
            double area = Math.Sqrt(s * (s - a) * (s - b) * (s - c));
            return area;
        }

        static string NumbersZeroToNineWord(int number)
        {
            switch (number)
            {
                case 0: return "zero";
                case 1: return "one";
                case 2: return "two";
                case 3: return "three";
                case 4: return "four";
                case 5: return "five";
                case 6: return "six";
                case 7: return "seven";
                case 8: return "eight";
                case 9: return "nine";
            }

            throw new NotSupportedException("Numbers over nine not supported !");
        }

        static int FindMax(params int[] elements)
        {
            if (elements == null || elements.Length == 0)
            {
                throw new ArgumentNullException("Parameters array length can not be zero or null!");
            }

            int maxNumber = 0;
            for (int i = 1; i < elements.Length; i++)
            {
                if (elements[i] > maxNumber)
                {
                    maxNumber = elements[i];
                }
            }

            return maxNumber;
        }

        static void PrintAsFloat(double number)
        {
            Console.WriteLine("{0:f2}", number);
        }

        static void PrintAsPercentage(double number)
        {
            Console.WriteLine("{0:p0}", number);
        }

        static void PrintWithSpacesBefore(double number)
        {
            Console.WriteLine("{0,8}", number);
        }

        static double CalcDistance(double x1, double y1, double x2, double y2)
        {
            double distance = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
            return distance;
        }

        static bool IsVertical(double y1, double y2)
        {
            bool isVertical = (y1 == y2);
            return isVertical;
        }

        static bool IsHorizaontal(double x1, double x2)
        {
            bool isHorizontal = (x1 == x2);
            return isHorizontal;
        }

        static void Main()
        {
            Console.WriteLine(CalcTriangleArea(3, 4, 5));

            Console.WriteLine(NumbersZeroToNineWord(5));

            Console.WriteLine(FindMax(5, -1, 3, 2, 14, 2, 3));

            PrintAsFloat(1.3);
            PrintAsPercentage(0.75);
            PrintWithSpacesBefore(2.30);

            Console.WriteLine(CalcDistance(3, -1, 3, 2.5));
            Console.WriteLine("Horizontal? " + IsHorizaontal(3,3));
            Console.WriteLine("Vertical? " + IsVertical(-1,2.5));

            Student peter = new Student("Peter", "Ivanov",
                new DateTime(1992, 03, 03), "From Sofia");

            Student stella = new Student("Stella", "Markova",
                new DateTime(1993, 11, 03), "From Vidin, gamer, high results");

            Console.WriteLine("{0} older than {1} -> {2}",
                peter.FirstName, stella.FirstName, peter.IsOlderThan(stella));
        }
    }
}
