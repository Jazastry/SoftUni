namespace Atm.Context.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Atm.Context;
    using Atm.Model;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<AtmDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
            ContextKey = "NewsDb.Context.NewsDbContext";
        }

        protected override void Seed(AtmDbContext context)
        {

            List<CardAccount> cardAccounts = new List<CardAccount>()
            {
                new CardAccount { CardCash = 2000, CardNumber = "001", CardPIN = "1111"},
                new CardAccount { CardCash = 300, CardNumber = "002", CardPIN = "2222"},
                new CardAccount { CardCash = 100, CardNumber = "003", CardPIN = "3333"},
                new CardAccount { CardCash = 50000, CardNumber = "004", CardPIN = "4444"},
                new CardAccount { CardCash = 10, CardNumber = "005", CardPIN = "5555"}
            };

            cardAccounts.ForEach(delegate(CardAccount n)
            {
                if (!context.CardAccounts
                    .Any(ne => (ne.CardNumber == n.CardNumber) &&
                               (ne.CardPIN == n.CardPIN)))
                {
                    context.CardAccounts.Add(n);
                }
            });

            //news.ForEach(n => context.News.Add(n));

            context.SaveChanges();
        }
    }
}
