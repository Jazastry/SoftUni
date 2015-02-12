// TODO: document this interface
// Do not modify the interface members
// Moving the interface to separate namespace is allowed
// Adding XML documentation is allowed

namespace TravelAgency
{
    using System;
    using Classes;

    internal class Program
    {
        private static void Main()
        {
            var ticketCatalog = new TicketCatalog();
            while (true)
            {
                string line = Console.ReadLine();
                if (line == null)
                {
                    break;
                }
                line = line.Trim();
                string commandResult = ticketCatalog.ExecuteInputCommand(line);
                if (commandResult != null)
                {
                    Console.WriteLine(commandResult);
                }
            }
        }
    }
}