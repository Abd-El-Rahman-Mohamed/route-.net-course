using System.Diagnostics;

namespace MovieTicketBookingSystem;

class Program
{
    // 5. In Main:
    static void Main(string[] args)
    {
        // a. Create a Cinema and open it.
        Cinema cinema = new Cinema();
        cinema.OpenCinema();

        // b. Create one StandardTicket, one VIPTicket, and one IMAXTicket.
        StandardTicket standardTicket = new StandardTicket("Inception", 120m, "A-5");
        VIPTicket vipTicket = new VIPTicket("Avengers", 200m, true, 50m);
        IMAXTicket imaxTicket = new IMAXTicket("Dune", 180m, false);

        // c. Test both versions of SetPrice on one ticket.
        Console.WriteLine("========= SetPrice Test ==========");
        Console.WriteLine("Setting price directly: 150");
        standardTicket.SetPrice(150m);
        Console.WriteLine("Setting price with multiplier: 100 x 1.5 = 150");
        standardTicket.SetPrice(100.00m, 1.5m);

        cinema.AddTicket(standardTicket);
        cinema.AddTicket(vipTicket);
        cinema.AddTicket(imaxTicket);

        Console.WriteLine();
        
        // d. Add all tickets to the Cinema and call PrintAllTickets().
        cinema.PrintAllTickets();

        // e. Call ProcessTicket() with one of the tickets.
        Console.WriteLine("========= Process Single Ticket =========");
        Cinema.ProcessTicket(vipTicket);

        Console.WriteLine();
        
        // f. Close the Cinema.
        cinema.CloseCinema();
    }
}