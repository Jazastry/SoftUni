using System;

namespace BankOfCurtovoConare
{
    class LoanAccount : Account, IAccount
    {
        public decimal Balance { get; private set; }
        public LoanAccount(Costumer costumer, decimal interestRate, decimal balance = 0)
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

        // Loan accounts have no interest for the first 
        // 3 months if held by individuals and for the first 2 months if held by a company.

        // A = money * (1 + interest rate * months) 
        public override decimal CalculateInterest(int months)
        {
            bool haveInterest = HaveInterest(months);
            decimal interest = 0;

            if (haveInterest)
            {
                interest = this.Balance*(1 + (this.InterestRate*months));
            }

            return interest;
        }

        public override string ToString()
        {
            string accountDetails = " Costumer : " + this.AccountCostumer + "\n Balance : " + this.Balance +
                                   "\n Interest Rate : " + this.InterestRate;
            return accountDetails;
        }

        private bool HaveInterest(int months)
        {
            bool individual = this.AccountCostumer.CostumerType.Equals(CostumerTypes.Individual);
            bool company = this.AccountCostumer.CostumerType.Equals(CostumerTypes.Company);
            bool haveInterestIndividuals = ((months > 3) && individual);
            bool haveInterestCompanies = ((months > 2) && company);
            bool haveInterest = (haveInterestCompanies || haveInterestIndividuals);

            return haveInterest;
        }
    }
}
