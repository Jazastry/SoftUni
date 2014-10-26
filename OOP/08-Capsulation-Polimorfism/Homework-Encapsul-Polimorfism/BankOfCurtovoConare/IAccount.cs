namespace BankOfCurtovoConare
{
    interface IAccount
    {
        void Deposit(decimal amount);

        decimal CalculateInterest(int months);

        string ToString();
    }
}
