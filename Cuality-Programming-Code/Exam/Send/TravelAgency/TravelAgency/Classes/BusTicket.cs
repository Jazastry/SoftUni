namespace TravelAgency.Classes
{
    using System;
    using Utils;

    internal class BusTicket : Ticket
    {
        private readonly string type = "bus";

        public override string Type
        {
            get { return this.type; }
        }

        public override string TicketInformation
        {
            get
            {
                return Type + ";;" + From + ";" + To + ";" +
                       Company + DateAndTime + ";";
            }
        }
        public BusTicket(string from, string to, string company, string date, string price)
            : base(from, to, company, date, price)
        {
        }

        public BusTicket(string from, string to, string company, string dt)
        {
            From = from;
            To = to;
            Company = company;
            DateTime dateAndTime = Utils.ParseDateTime(dt);
            DateAndTime = dateAndTime;
        }
    }
}
