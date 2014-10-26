using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheSlum.Interfaces;

namespace TheSlum
{
    public class BonusItem : Item, ITimeoutable
    {
        private int timeout;
        private int countdown;
        private bool hasTimeOut = true;

        public int Timeout
        {
            get { return this.timeout; }
            set { this.timeout = value; }
        }

        public int Countdown
        {
            get { return this.countdown; }
            set { this.countdown = value; }
        }

        public bool HasTimedOut
        {
            get { return this.hasTimeOut; }
            set { this.hasTimeOut = value; }
        }

        public BonusItem(string id, int healthEffect, int defenseEffect,
            int attackEffect, int timeout) 
                : base(id, healthEffect, defenseEffect, attackEffect)
        {
            this.Timeout = timeout;
            this.Countdown = timeout;
        }
    }
}
