using System.Reflection;

namespace TravelAgency.Classes
{
    using System;
    using Utils;

    internal class TrainTicket : Ticket
    {
        private readonly string type = "train";
        public override string Type
        {
            get { return this.type; }
        }

        public override string TicketInformation
        {
            get { return Type + ";;" + From + ";" + To + ";" + DateAndTime + ";"; }
        }

        public TrainTicket(string from, string to, string dateTime, string regularPrice, string specialPrice)
        {
            this.From = from;
            this.To = to;
            DateTime dateAndTime = Utils.ParseDateTime(dateTime);
            this.DateAndTime = dateAndTime;
            decimal price = decimal.Parse(regularPrice);
            this.Price = price;
            this.SpecialPrice = decimal.Parse(specialPrice);
        }

        public TrainTicket(string from, string to, string dateTime)
        {
            this.From = from;
            this.To = to;
            DateTime dateAndTime = Utils.ParseDateTime(dateTime);
            this.DateAndTime = dateAndTime;
        }
    }
}
