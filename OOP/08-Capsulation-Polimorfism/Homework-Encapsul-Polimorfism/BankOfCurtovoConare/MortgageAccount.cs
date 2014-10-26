using System;

namespace BankOfCurtovoConare
{
    class MortgageAccount : Account
    {
        public decimal Balance { get; private set; }
        public MortgageAccount(Costumer costumer, decimal interestRate, decimal balance = 0)
            : base (costumer, interestRate, balance)
        {
            this.Balance = balance;
        }

        public void Deposit(decimal deposit)
        {
            if (deposit > 0)
            {
                this.Balance += deposit;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Cant deposit negative sums.");
            }
        }
 
        public override decimal CalculateInterest(int months)
        {
            bool individual = (this.AccountCostumer.Equals(CostumerTypes.Individual));
            bool company = (this.AccountCostumer.Equals(CostumerTypes.Company));
            decimal interest = 0;

            if (individual && (months < 7))
            {
                return interest;
            }
            else if (company && (months < 13))
            {
                interest = Interest(months) / 2;
                return interest;
            }
            
            return Interest(months);
        }

        public override string ToString()
        {
            string accountDetails = " Costumer : " + this.AccountCostumer + "\n Balance : " + this.Balance +
                                   "\n Interest Rate : " + this.InterestRate;
            return accountDetails;
        }

        private decimal Interest(int months)
        {
            decimal interest = this.Balance * (1 + (this.InterestRate * months));
            return interest;
        }
    }
}
