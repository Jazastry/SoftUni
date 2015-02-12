namespace TravelAgency.Classes
{
    using System;
    using Utils;

    internal class AirTicket : Ticket
    {
        private readonly string type = "air";
        private string flightNumber;

        public override string Type
        {
            get { return this.type; }
        }

        public override string TicketInformation
        {
            get { return Type + ";;" + flightNumber; }
        }

        public string FlightNumber
        {
            get { return this.flightNumber; }
            set { this.flightNumber = value; }
        }

        public AirTicket(string flightNumber, string from, string to, string company, string date, string price)
            :base(from, to, company, date, price)
        {
            this.FlightNumber = flightNumber;
        }

        public AirTicket(string flightNumber)
        {
            this.FlightNumber = flightNumber;
        }
    }
}
