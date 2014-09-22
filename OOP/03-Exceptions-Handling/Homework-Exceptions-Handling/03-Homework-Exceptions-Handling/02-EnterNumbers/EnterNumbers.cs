using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_EnterNumbers
{
    class EnterNumbers
    {
        public void ReadNumber(int start, int end)
        {
            int input = 0;
            bool isInt = int.TryParse(Console.ReadLine(), out input);
            if ((!isInt) || input <= start || input >= end)
            {
                throw new System.ArgumentException();
            }
        }
        static void Main(string[] args)
        {
        }
    }
}
