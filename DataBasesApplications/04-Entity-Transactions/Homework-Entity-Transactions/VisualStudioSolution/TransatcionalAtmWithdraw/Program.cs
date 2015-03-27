using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using TransatcionalAtmWithdraw;

namespace TransatcionalAtmWithdraw
{
    public class Program
    {
        public static void Main()
        {
            // CardAccount Cash in the account is 5000
            WithdrawMethods.TransactWithdraw("1234", "1111", 5000);
            // Throws Exception
            WithdrawMethods.TransactWithdraw("1234", "1111", 5000);
        }       
    }
}
