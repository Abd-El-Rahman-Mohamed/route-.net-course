using System.Diagnostics;

namespace MovieTicketBookingSystem;

class Program
{
    /*
     4. In Main, do the following:
     */
    static void Main(string[] args)
    {
        // a. Create a Cinema and open it.
        Cinema cinema = new Cinema();
        cinema.OpenCinema();

        // b. Create one of each ticket type (hardcoded data) and add them to the Cinema.
        StandardTicket standardTicket = new StandardTicket("Inception", 120m, "A-5");
        VIPTicket vipTicket = new VIPTicket("Avengers", 200m, true, 50m);
        IMAXTicket imaxTicket = new IMAXTicket("Dune", 180m, false);

        cinema.AddTicket(standardTicket);
        cinema.AddTicket(vipTicket);
        cinema.AddTicket(imaxTicket);

        // c. Print all tickets.
        cinema.PrintAllTickets();

        Console.WriteLine("========== Statistics ==========");
        Console.WriteLine($"Total Tickets Created: {cinema.Count}");

        Console.WriteLine();
        
        Console.WriteLine($"Booking Ref 1: {BookingHelper.GenerateBookingReference()}");
        Console.WriteLine($"Booking Ref 2: {BookingHelper.GenerateBookingReference()}");

        Console.WriteLine();

        Console.WriteLine($"Group Discount (5 x 100 EGP): {BookingHelper.CalcGroupDiscount(5, 100)} (10% off)");

        // d. Close the Cinema.
        cinema.CloseCinema();
        
    }
}