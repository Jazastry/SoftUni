using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransatcionalAtmWithdraw
{
    class WithdrawMethods
    {
        public static void TransactWithdraw(string cardNumber, string pin, decimal withdrawAmount)
        {
            var context = new AtmDbContext();
            using (var dbContextTransaction = context.Database.BeginTransaction(System.Data.IsolationLevel.RepeatableRead))
            {
                try
                {
                    var card = context.CardAccounts
                        .Where(a => (a.CardPIN == pin) && (a.CardNumber == cardNumber)).FirstOrDefault();

                    // Step 1. Check if the given CardPIN and CardNumber are valid. Throw an exception if not.
                    if (card == null)
                    {
                        throw new ArgumentException("TransactWithdraw methid :  invalid card number or pin.");
                    }

                    // Step 2. Check if the amount on the account (CardCash) is bigger than the requested sum
                    // (in our example $200). Throw an exception if not.
                    if (card.CardCash < withdrawAmount)
                    {
                        throw new ArgumentOutOfRangeException("TransactWithdraw method : withdraw amount bigger than card cash availability.");
                    }

                    // Step 3. The ATM machine pays the required sum (e.g. $200) and stores in the
                    // table CardAccounts the new amount (CardCash = CardCash - 200).
                    card.CardCash = card.CardCash - withdrawAmount;

                    // Problem 6. ATM Transactions History
                    TransactionHistory newHistory = new TransactionHistory()
                    {
                        CardNumber = card.CardNumber,
                        TransactionDate = DateTime.Now,
                        Amount = withdrawAmount
                    };

                    context.TransactionHistories.Add(newHistory);

                    context.SaveChanges();
                    dbContextTransaction.Commit();
                }
                catch (ArgumentOutOfRangeException aorex)
                {
                    Console.WriteLine(aorex);
                    dbContextTransaction.Rollback();
                }
                catch (ArgumentException argex)
                {
                    Console.WriteLine(argex);
                    dbContextTransaction.Rollback();
                }
            }
        }
    }
}
