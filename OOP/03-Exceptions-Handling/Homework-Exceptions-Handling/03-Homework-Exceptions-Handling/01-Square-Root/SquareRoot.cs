using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Square_Root
{
    class SquareRoot
    {
        static void Main()
        {
            try
            {
                Console.WriteLine("Enter integer :");
                string input = Console.ReadLine();
                int inputNumb = 0;
                double result = 0;
                bool isItInt = int.TryParse(input, out inputNumb);
                if ((isItInt) && (inputNumb > -1))
                {
                    result = Math.Sqrt(inputNumb);
                }
                else if (!isItInt)
                {
                    throw new ArgumentException("input","Number isn't an integer try again !");
                }
                else if ((inputNumb < 0))
                {
                    throw new ArgumentOutOfRangeException("input","Negative integer sqrt not supported !");
                }
                Console.WriteLine(result);
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid Number !");
            }
            finally
            {
                Console.WriteLine("Good Bye !");
            }
        }
    }
}
