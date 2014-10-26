namespace BankOfCurtovoConare
{
    public abstract class Account : IAccount
    {
        private Costumer accountCostumer;
        private decimal balance;
        private decimal interestRate;

        public Costumer AccountCostumer { get; private set; }
        public decimal Balance { get; private set; }

        public decimal InterestRate
        {
            get { return this.interestRate; }
            set { this.interestRate = value; }
        }

        public Account(Costumer costumer, decimal interestRate, decimal balance)
        {
            this.AccountCostumer = costumer;
            this.Balance = balance;
            this.InterestRate = interestRate;
        }

        public void Deposit(decimal deposit)
        {
            this.Balance += deposit;
        }

        public abstract decimal CalculateInterest(int months);

        public abstract string ToString();
    }
}
