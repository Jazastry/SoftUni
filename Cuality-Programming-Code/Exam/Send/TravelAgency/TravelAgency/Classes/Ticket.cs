namespace TravelAgency.Classes
{
    using System;
    using Utils;

    public abstract class Ticket : IComparable<Ticket>
    {
        private string type;
        private string from;
        private string to;
        private string company;
        private DateTime dateAndTime;
        private decimal price;
        private decimal specialPrice;

        public virtual string Type
        {
            get { return this.type; }
        }
        public virtual string From
        {
            get { return this.from; }
            set { this.from = value; }
        }
        public virtual string To
        {
            get { return this.to; }
            set { this.to = value; }
        }
        public virtual string Company
        {
            get { return this.company; }
            set { this.company = value; }
        }
        public virtual DateTime DateAndTime
        {
            get { return this.dateAndTime; }
            set { this.dateAndTime = value; }
        }
        public virtual decimal Price
        {
            get { return this.price; }
            set { this.price = value; }
        }
        public virtual decimal SpecialPrice
        {
            get { return this.specialPrice; }
            set { this.specialPrice = value; }
        }
        public abstract string TicketInformation { get; }

        public Ticket(string from, string to, string company, string dateTime, string price)
        {
            this.From = from;
            this.To = to;
            this.Company = company;
            this.DateAndTime = Utils.ParseDateTime(dateTime);
            this.Price = decimal.Parse(price);
        }

        public Ticket()
        {
        }

        public string FromToKey
        {
            get { return Utils.CreateFromToKey(From, To); }
        }

        public int CompareTo(Ticket otherTicket)
        {
            int result = DateAndTime.CompareTo(otherTicket.DateAndTime);
            if (result == 0)
            {
                result = Type.CompareTo(otherTicket.Type);
            }
            if (result == 0)
            {
                result = Price.CompareTo(otherTicket.Price);
            }
            return result;
        }

        public override string ToString()
        {
            string dateTime = DateAndTime.ToString("dd.MM.yyyy HH:mm");
            string price = String.Format("{0:f2}", Price);
            string result = String.Format("[{0}; {1}; {2}]", dateTime, this.Type, price);
            return result;
        }
    }
}
