using System.Linq;
using System.Text;

namespace TravelAgency.Classes
{
    using System;
    using System.Collections.Generic;
    using Contracts;
    using Enumerations;
    using Wintellect.PowerCollections;
    using Utils;

    public class TicketCatalog : ITicketCatalog
    {
        private readonly MultiDictionary<string, Ticket> FromToDataBase = new MultiDictionary<string, Ticket>(true);
        private Dictionary<string, Ticket> DataBase = new Dictionary<string, Ticket>();
        private OrderedMultiDictionary<DateTime, Ticket> DateTimeDataBase = new OrderedMultiDictionary<DateTime, Ticket>(true);
        private int airTicketsCount = 0;
        private int busTicketsCount = 0;
        private int trainTicketsCount = 0;
        private const string InvalidCommandMessage = "Invalid command!";

        public Dictionary<string, Ticket> RetrieveDatabase()
        {
            return this.DataBase;
        }

        public string FindTickets(string from, string to)
        {
            string fromToKey = Utils.CreateFromToKey(from, to);
            if (FromToDataBase.ContainsKey(fromToKey))
            {
                var ticketsFound = new List<Ticket>();
                foreach (Ticket ticket in FromToDataBase.Values)
                {
                    if (ticket.FromToKey == fromToKey)
                    {
                        ticketsFound.Add(ticket);
                    }
                }
                string ticketsAsString = ReadTickets(ticketsFound);
                return ticketsAsString;
            }
            return "Not found";
        }

      
        public string FindTicketsInInterval(DateTime startDateTime, DateTime endDateTime)
        {
            // Do not toch! It work!!! I spend 10 hours of fix buggy here
            ICollection<Ticket> ticketsFound = DateTimeDataBase.Range(startDateTime, true, endDateTime, true).Values;
            if (ticketsFound.Count > 0)
            {
                string ticketsAsString = ReadTickets(ticketsFound.ToList());
                return ticketsAsString;
            }
            return "Not found";
        }

        public string AddAirTicket(string flightNumber, string from, string to,
            string airline, DateTime dateTime, decimal price)
        {
            return AddAirTicket(flightNumber, from, to, airline,
                dateTime.ToString("dd.MM.yyyy HH:mm"), price.ToString());
        }

        string ITicketCatalog.DeleteAirTicket(string parwaaz_number)
        {
            return DeleteAirTicket(parwaaz_number);
        }

        protected string DeleteAirTicket(string parwaaz_number)
        {
            var ticket = new AirTicket(parwaaz_number);
            string result = AddDeleteTicket(ticket, false);
            if (result.Contains("deleted"))
            {
                airTicketsCount--;
            }
            return result;
        }

        public string AddTrainTicket(string from, string to, DateTime dateTime, decimal price, decimal studentPrice)
        {
            return
                AddTrainTicket(from, to, dateTime.ToString("dd.MM.yyyy HH:mm"), price.ToString(), studentPrice.ToString());
        }

        public string DeleteTrainTicket(string from, string to, DateTime dateTime)
        {
            return DeleteTrainTicket(from, to, dateTime.ToString("dd.MM.yyyy HH:mm"));
        }

        public string AddBusTicket(string from, string to, string Sayahat_ki_Tanzeem, DateTime dateTime, decimal price)
        {
            return CreateBusTicket(from, to,
                Sayahat_ki_Tanzeem, dateTime.ToString("dd.MM.yyyy HH:mm"), price.ToString());
        }

        public string DeleteBusTicket(string from, string to, string Sayahat_ki_Tanzeem, DateTime dateTime)
        {
            return DeleteBusTicket(from, to, Sayahat_ki_Tanzeem, dateTime.ToString("dd.MM.yyyy HH:mm"));
        }


        public int GetTicketsCount(TicketType type)
        {
            int result = 0;
            switch (type)
            {
                case TicketType.Air:
                    result = this.airTicketsCount;
                    break;
                case TicketType.Bus:
                    result = this.busTicketsCount;
                    break;
                case TicketType.Train:
                    result = this.trainTicketsCount;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("TicketType", "Invalid ticket type");
                    break;
            }

            return result;
        }

        public int GetTicketsCount(string type)
        {
            if (type == "air")
            {
                return airTicketsCount;
            }

            if (type == "bus")
            {
                return busTicketsCount;
            }
            return trainTicketsCount;
        }

        internal string AddDeleteTicket(Ticket ticket, bool isAdd)
        {
            if (isAdd)
            {
                string key = ticket.TicketInformation;
                if (DataBase.ContainsKey(key))
                {
                    return "Duplicate ticket";
                }
                DataBase.Add(key, ticket);
                string fromToKey = ticket.FromToKey;
                FromToDataBase.Add(fromToKey, ticket);
                DateTimeDataBase.Add(ticket.DateAndTime, ticket);
                return "Ticket added";
            }
            else
            {
                string key = ticket.TicketInformation;
                if (DataBase.ContainsKey(key))
                {
                    DataBase.Remove(key);
                    string fromToKey = ticket.FromToKey;
                    FromToDataBase.Remove(fromToKey, ticket);
                    DateTimeDataBase.Remove(ticket.DateAndTime, ticket);
                    return "Ticket deleted";
                }
                return "Ticket does not exist";
            }
        }

        public string AddAirTicket(string flightNumber, string from, string to, string airCompanyName, string dateTime, string price)
        {
            var ticket = new AirTicket(flightNumber, from, to, airCompanyName, dateTime, price);
            string result = AddDeleteTicket(ticket, true);
            if (result.Contains("added"))
            {
                airTicketsCount++;
            }
            return result;
        }

        public string AddTrainTicket(string from, string to, string dateTime, string price, string studentpp)
        {
            var ticket = new TrainTicket(from, to, dateTime, price, studentpp);
            string result = AddDeleteTicket(ticket, true);
            if (result.Contains("added"))
            {
                trainTicketsCount++;
            }
            return result;
        }

        private string DeleteTrainTicket(string from, string to, string dt)
        {
            var ticket = new TrainTicket(from, to, dt);
            string result = AddDeleteTicket(ticket, false);
            if (result.Contains("deleted"))
            {
                trainTicketsCount--;
            }
            return result;
        }

        protected string CreateBusTicket(string from, string to, string company, string dateTime, string price)
        {
            var ticket = new BusTicket(from, to, company, dateTime, price);
            string key = ticket.TicketInformation;
            string result;
            if (DataBase.ContainsKey(key))
            {
                result = "Duplicate ticket";
            }
            else
            {
                DataBase.Add(key, ticket);
                string fromToKey = ticket.FromToKey;
                FromToDataBase.Add(fromToKey, ticket);
                DateTimeDataBase.Add(ticket.DateAndTime, ticket);
                result = "Ticket added";
            }

            if (result.Contains("added"))
            {
                busTicketsCount++;
            }
            return result;
        }

        private string DeleteBusTicket(string from, string to, string company, string dt)
        {
            var ticket = new BusTicket(from, to, company, dt);
            string result = AddDeleteTicket(ticket, false);


            if (result.Contains("deleted"))
            {
                busTicketsCount--;
            }
            return result;
        }

        internal static string ReadTickets(List<Ticket> tickets)
        {
            var sortedTickets = tickets;
            sortedTickets.Sort();
            var result = new StringBuilder();
            string ticket = "";
            for (int i = 0; i < sortedTickets.Count; i++)
            {
                ticket = sortedTickets[i].ToString();
                result.Append(ticket + " ");
            }

            return result.ToString();
        }

        public string FindTicketsInInterval(string startDateTimeStr, string endDateTimeStr)
        {
            DateTime startDateTime = Utils.ParseDateTime(startDateTimeStr);
            DateTime endDateTime = Utils.ParseDateTime(endDateTimeStr);
            string ticketsAsString = TicketsInIntervalFilter(startDateTime, endDateTime);
            return ticketsAsString;
        }

        public string TicketsInIntervalFilter(DateTime startDateTime, DateTime endDateTime)
        {
            ICollection<Ticket> ticketsFound = DateTimeDataBase.Range(startDateTime, true, endDateTime, true).Values;
            if (ticketsFound.Count > 0)
            {
                string ticketsAsString = ReadTickets(ticketsFound.ToList());
                return ticketsAsString;
            }
            return "Not found";
        }

        internal string ExecuteInputCommand(string line)
        {
            if (line == "")
            {
                return null;
            }

            int firstSpaceIndex = line.IndexOf(' ');
            if (firstSpaceIndex == -1)
            {
                return InvalidCommandMessage;
            }

            string inputCommand = line.Substring(0, firstSpaceIndex);
            string result = "";
            switch (inputCommand)
            {
                case "AddAir":
                    string allParameters = line.Substring(firstSpaceIndex + 1);
                    string[] parameters = allParameters.Split(new[] { ';' },
                        StringSplitOptions.RemoveEmptyEntries);

                    for (int i = 0; i < parameters.Length; i++)
                    {
                        parameters[i] = parameters[i].Trim();
                    }
                    result = AddAirTicket(parameters[0], parameters[1], parameters[2], parameters[3], parameters[4],
                        parameters[5]);
                    break;
                case "DeleteAir":
                    allParameters = line.Substring(firstSpaceIndex + 1);
                    parameters = allParameters.Split(
                        new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < parameters.Length; i++)
                    {
                        parameters[i] = parameters[i].Trim();
                    }
                    result = DeleteAirTicket(parameters[0]);
                    break;
                case "AddTrain":
                    allParameters = line.Substring(firstSpaceIndex + 1);
                    parameters = allParameters.Split(
                        new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < parameters.Length; i++)
                    {
                        parameters[i] = parameters[i].Trim();
                    }
                    result = AddTrainTicket(parameters[0], parameters[1], parameters[2],
                        parameters[3], parameters[4]);
                    break;
                case "DeleteTrain":
                    allParameters = line.Substring(firstSpaceIndex + 1);
                    parameters = allParameters.Split(
                        new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < parameters.Length; i++)
                    {
                        parameters[i] = parameters[i].Trim();
                    }
                    result = DeleteTrainTicket(parameters[0], parameters[1], parameters[2]);
                    break;
                case "AddBus":
                    allParameters = line.Substring(firstSpaceIndex + 1);
                    parameters = allParameters.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < parameters.Length; i++)
                    {
                        parameters[i] = parameters[i].Trim();
                    }

                    result = CreateBusTicket(parameters[0], parameters[1], parameters[2],
                        parameters[3], parameters[4]);
                    break;
                case "DeleteBus":
                    allParameters = line.Substring(firstSpaceIndex + 1);
                    parameters = allParameters.Split(
                        new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < parameters.Length; i++)
                    {
                        parameters[i] = parameters[i].Trim();
                    }
                    result = DeleteBusTicket(parameters[0],
                        parameters[1], parameters[2], parameters[3]);
                    break;
                case "FindTickets":
                    allParameters = line.Substring(firstSpaceIndex + 1);
                    parameters = allParameters.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0;i < parameters.Length;i++)
                    {
                        parameters[i] = parameters[i].Trim();
                    }

                    result = FindTickets(parameters[0], parameters[1]);
                    break;
                case "FindTicketsInInterval":
                    allParameters = line.Substring(firstSpaceIndex + 1);
                    parameters = allParameters.Split(new[] { ';' },StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < parameters.Length; i++)
                    {
                        parameters[i] = parameters[i].Trim();
                    }
                    result = FindTicketsInInterval(parameters[0], parameters[1]);
                    break;
                default:
                    result = InvalidCommandMessage;
                    break;
            }
            return result;
        }
    }
}
