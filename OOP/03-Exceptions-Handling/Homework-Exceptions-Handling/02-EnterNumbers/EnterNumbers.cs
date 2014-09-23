using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_EnterNumbers
{
    class EnterNumbers
    {
        public static int ReadNumber(int start, int end)
        {
            int input = 0;
            bool isInt = int.TryParse(Console.ReadLine(), out input);
            if ((!isInt) || input <= start || input >= end)
            {
                throw new System.ArgumentException();
            }
            else
            {
                return input;
            }
        }

        static void Main(string[] args)
        {
            int start = 1;
            int end = 100;
            int counter = 10;
            string numbs = "";            
            while (counter > 0)
            {
                Console.WriteLine("Enter Number - n so that: n > {0} and n < 100.\nLeft {1} numbs to pass.", start, counter);              
                try
                {                    
                    start = ReadNumber(start, end);
                    Console.Clear();
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid Input. Try Again.\n");
                    continue;
                }

                if (counter > 1)
                {
                    numbs += start + ", ";
                }
                else
                {
                    numbs += start;
                }              
 
                counter--;
                if ((start == 99) && counter > 0)
                {
                    break;
                }
            }
            if (counter > 0)
            {                
                Console.WriteLine("No attempts left !");
            }
            else
            {
                Console.WriteLine("Great you did it !");
            }
        }
    }
}
