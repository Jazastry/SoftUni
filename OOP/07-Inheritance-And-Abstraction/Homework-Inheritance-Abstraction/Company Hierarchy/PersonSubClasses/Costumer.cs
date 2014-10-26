using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompanyHierarchy
{
    public class Costumer : Person, ICostumer
    {
        private decimal netPurchaseAmount;

        public decimal NetPurchaseAmount
        {
            get { return this.netPurchaseAmount; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("NetPurchaseAmount value is null or empty.");
                }
                else
                {
                    this.netPurchaseAmount = value;
                }
            }
        }

        public Costumer(int id, string firstName, string lastName, decimal netPurchaseAmount)
            : base(id, firstName, lastName)
        {
            this.NetPurchaseAmount = netPurchaseAmount;
        }
        public override string ToString()
        {
            string result = String.Format(" {0} {1} : {2}\n tot. Amount of Purchase : {3}",
                this.FirstName, this.LastName, this.Id, this.NetPurchaseAmount);
            return result;
        }
    }
}
