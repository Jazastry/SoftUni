using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Atm.Model;
using System.ComponentModel.DataAnnotations;

namespace Atm.Context
{
    public class AtmDbContext : DbContext
    {
        private ICollection<CardAccount> accounts;

        AtmDbContext()
            : base ("AtmDb")
        {
            this.accounts = new HashSet<CardAccount>();
        }
        [ConcurrencyCheck]
        public ICollection<CardAccount> CardAccounts
        {
            get { return this.accounts; }
            set { this.accounts = value; } 
        }
    }
}
