using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_BitArray
{
    class BitArray
    {
        private int arraySize = 0;
        private int bitValues;
        private int ArraySize
        {
            get
            {
                return this.arraySize;
            }
            set
            {
                if ((value < 1) || (value > 100000))
                {
                    throw new IndexOutOfRangeException("This Array Size is not supported.");
                }
                else
                {
                    this.arraySize = value;
                }
            }
        }
        public int this[int index]
        {
            get
            {
                if ((index >= 0) && (index <= arraySize - 1))
                {
                    return ((bitValues >> index) & 1);
                }
                else
                {
                    throw new IndexOutOfRangeException(String.Format("Index {0} is out of range.", index));
                }
            }
            set
            {
                if ((index >= 0) && (index <= arraySize - 1))
	            {
		            if ((value < 0) || (value > 1))                  
                    {
                        throw new ArgumentOutOfRangeException("Bit Value can be only 1 or 0.");
                    }
                    else
                    {
                        if (value == 0)
                        {
                            this.bitValues = ~(~bitValues | (1 << index));
                        }
                        else
                        {
                            this.bitValues = bitValues | (value << index); 
                        }                      
                    }
	            }
                else
                {
                    throw new IndexOutOfRangeException(String.Format("Index {0} is out of range.", index));
                }
            }
        }
        public BitArray(int size)
        {
            this.ArraySize = size; 
        }
        public void PrintBinary()
        {
            int numDec = int.Parse(bitValues.ToString());
            string numBinary = Convert.ToString(numDec, 2);
            Console.WriteLine(numBinary); 
        }
        public override string ToString()
        {
            return String.Format("{0}", bitValues); 
        }
    }
}
