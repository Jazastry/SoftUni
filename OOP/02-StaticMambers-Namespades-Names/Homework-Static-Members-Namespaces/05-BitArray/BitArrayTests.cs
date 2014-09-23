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
            // Create BitArray Object
            BitArray num = new BitArray(bitsArrayLength);
            // Assign values to some indexes
            num[7] = 1;
            num[3] = 1;
            num[4] = 1;
            num[3] = 0;
            // Print num Obj. by index access
            for (int i = bitsArrayLength - 1; i >= 0; i--)
            {
                Console.WriteLine("num[{0}] = {1}", i, num[i]);
            }

            // Print num binary by .PrintBinary method
            num.PrintBinary();
            // Print num Obj. decimal value 
            Console.WriteLine(num);
        }
    }
}
