using System;

namespace BankOfCurtovoConare
{
    public class DepositAccount : Account, IAccount
    {
        public decimal Balance { get; private set; }

        public DepositAccount(Costumer costumer, decimal interestRate, decimal balance = 0)
            : base(costumer, interestRate, balance)
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

        public void Withdraw(decimal withdraw)
        {
            if (this.Balance >= withdraw)
            {
                this.Balance -= withdraw;
            }
            else
            {
                throw new ArgumentException(
                    String.Format("Account Balance Insufficent for withdraw {0}\n" +
                                            "Current Balance = {1}", withdraw, this.Balance));
            }
        }

        // A = money * (1 + interest rate * months) 
        public override decimal CalculateInterest(int months)
        {
            decimal interest = 0;
            if (HaveInterest())
            {
                interest = this.Balance*(1 + (this.InterestRate*months));
            }
            return interest/100;
        }

        private bool HaveInterest()
        {
            bool haveInterest = (this.Balance > 999) && (this.Balance > 0);

            return haveInterest;
        }

        public override string ToString()
        {
            string accountDetails = " Costumer : " + this.AccountCostumer + "\n Balance : " + this.Balance +
                                   "\n Interest Rate : " + this.InterestRate;
            return accountDetails;
        }
    }
}
