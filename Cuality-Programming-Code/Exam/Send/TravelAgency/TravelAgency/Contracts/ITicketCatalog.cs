namespace TravelAgency.Contracts
{
    using System;
    using Enumerations;

    public interface ITicketCatalog
    {
        /// <summary>
        /// Adds new air ticket to the data base.
        /// </summary>
        /// <param name="flightNumber">Represents the unic flight number.</param> 
        /// <param name="from">Represents departure place name.</param>
        /// <param name="to">Represents arrival place name.</param>
        /// <param name="airline">Represents air company name.</param>
        /// <param name="datetime">Represents time and date of the flight.</param>
        /// <param name="price">Represents price in decimal value.</param>
        /// <returns>
        /// If exists ticket with same key returns "Duplicate ticket"
        /// If does not exist ticket with same key returns "Ticket added"   
        /// </returns>
        /// <remarks></remarks>
        /// <exception cref=""></exception>
        string AddAirTicket(string flightNumber, string from, string to, string airline, DateTime dateTime, decimal price);

        string DeleteAirTicket(string flightNumber);

        string AddTrainTicket(string from, string to, DateTime dateTime, decimal price, decimal studentPrice);

        string DeleteTrainTicket(string from, string to, DateTime dateTime);

        string AddBusTicket(string from, string to, string travelCompany, DateTime dateTime, decimal price);

        /// <summary>
        /// Adds new air ticket to the data base.
        /// </summary>
        /// <param name="from">Represents departure place name.</param>
        /// <param name="to">Represents arrival place name.</param>
        /// <param name="travelCompany">Represents travel company name.</param>
        /// <param name="datetime">Represents time and date of the flight.</param>
        /// <param name="price">Represents price in decimal value.</param>
        /// <returns>
        /// If exists ticket with same key returns "Duplicate ticket"
        /// If does not exist ticket with same key returns "Ticket added"   
        /// </returns>
        /// <remarks></remarks>
        /// <exception cref=""></exception>
        string DeleteBusTicket(string from, string to, string travelCompany, DateTime dateTime);

        /// <summary>
        /// Adds new air ticket to the data base.
        /// </summary>
        /// <param name="from">Represents departure place name.</param>
        /// <param name="to">Represents arrival place name.</param>
        /// <returns>
        /// If exists ticket with same key returns "Duplicate ticket"
        /// If does not exist ticket with same key returns "Ticket added"   
        /// </returns>
        /// <remarks></remarks>
        /// <exception cref=""></exception>
        string FindTickets(string from, string to);

        /// <summary>
        /// Adds new air ticket to the data base.
        /// </summary>
        /// <param name="startDateTime">Represents departure time and date.</param>
        /// <param name="endDateTime">Represents arrival time and date.</param>
        /// <returns>
        /// If exists ticket with same key returns "Duplicate ticket"
        /// If does not exist ticket with same key returns "Ticket added"   
        /// </returns>
        /// <remarks></remarks>
        /// <exception cref=""></exception>
        string FindTicketsInInterval(DateTime startDateTime, DateTime endDateTime);

        int GetTicketsCount(TicketType type);
    }
}
