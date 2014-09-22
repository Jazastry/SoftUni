using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_BitArray
{
    class BitArrayTests
    {
        static void Main()
        {
            int bitsArrayLength = 8;

            BitArray num = new BitArray(bitsArrayLength);

            num[7] = 1;

            for (int i = bitsArrayLength - 1; i >= 0; i--)
            {
                Console.WriteLine("num[{0}] = {1}", i, num[i]);
            }

            Console.Write("bits = ");
            for (int i = bitsArrayLength - 1; i >= 0; i--)
            {
                Console.Write(num[i]);
            }
            Console.WriteLine();
            Console.WriteLine(num);


        }
    }
}
