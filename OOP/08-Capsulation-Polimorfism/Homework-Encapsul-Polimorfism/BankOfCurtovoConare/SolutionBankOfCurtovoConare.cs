using System;
using BankOfCurtovoConare;


class SolutionBankOfCurtovoConare
{
    private static void Main()
    {
        // Individual account test
        Costumer ivan = new Costumer("Ivan Ivanov", CostumerTypes.Individual);

        DepositAccount ivanDepositAccount = new DepositAccount(ivan, 1, 1000);

        int months = 5;

        decimal ivanInterest = ivanDepositAccount.CalculateInterest(months);

        Console.WriteLine(ivanDepositAccount.ToString() + "\n Interest for {0} months : {1}", months, ivanInterest + "\n");

        ivanDepositAccount.Withdraw(500);

        Console.WriteLine("After withdraw 500  \n" + ivanDepositAccount.ToString() + "\n");

        // Company Account test
        Costumer kokoOod = new Costumer("KOKO OOD", CostumerTypes.Company);

        LoanAccount kokoLoanAccount = new LoanAccount(kokoOod, 2, 50000);

        months = 12;

        decimal kokoInterest = kokoLoanAccount.CalculateInterest(months);
        Console.WriteLine(kokoLoanAccount.ToString() +
            "\n Interest for {0} months : {1}", months, kokoInterest + "\n");

        months = 13;
        kokoInterest = kokoLoanAccount.CalculateInterest(months);
        Console.WriteLine(kokoLoanAccount.ToString() +
            "\n Interest for {0} months : {1}", months, kokoInterest + "\n");
    }
}

