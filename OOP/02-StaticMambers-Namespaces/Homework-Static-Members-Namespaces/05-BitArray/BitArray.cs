using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_BitArray
{
    class BitArray
    {
        private int bitsCount = 0;
        private uint bitValues;
        public int BitsCount
        {
            get
            {
                return this.bitsCount;
            }
            set
            {
                if ((value < 1) || (value > 100000))
                {
                    throw new ArgumentOutOfRangeException("BitsCount");
                }
                else
                {
                    this.bitsCount = value;
                }
            }
        }

        // Indexer declaration
        public int this[int index]
        {
            get
            {
                if ((index >= 0) && (index-1 < bitsCount))
                {
                    // Check the bit at position index
                    if ((bitValues & (1 << index)) == 0)
                        return 0;
                    else
                        return 1;
                }
                else
                {
                    throw new IndexOutOfRangeException(String.Format(
                        "Index {0} is invalid!", index));
                }
            }

            set
            {
                if ((index < 0) || (index > bitsCount-1))
                {
                    throw new IndexOutOfRangeException(String.Format(
                        "Index {0} is invalid!", index));
                }
                if ((value < 0) || (value > 1))
                {
                    throw new ArgumentException(String.Format(
                        "Value {0} is invalid!", value));
                }

                // Clear the bit at position index
                bitValues &= ~((uint)(1 << index));

                // Set the bit at position index to value
                bitValues |= (uint)(value << index);
            }
        }
        public BitArray(int size)
        {
            this.bitsCount = size;
        }
        public override string ToString()
        {
            uint value = bitValues;
            string formatSpecifier = "D" + bitsCount;
            string result = String.Format("{0}", value);
            //value = 12345;
            //Console.WriteLine(value.ToString("D"));
            //// Displays 12345
            //Console.WriteLine(value.ToString(formatSpecifier));
            //// Displays 00012345 
            return result;
        }
    }
}
