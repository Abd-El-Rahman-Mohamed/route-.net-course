using System.Diagnostics;

namespace MovieTicketBookingSystem;

class Program
{
    static void Main(string[] args)
    {
        Cinema cinema = new Cinema();
        cinema.OpenCinema();

        StandardTicket standardTicket = new StandardTicket("Inception", 80m, "A5");
        VIPTicket vipTicket = new VIPTicket("Avengers", 200m, true, 50m);
        IMAXTicket imaxTicket = new IMAXTicket("Dune", 130m, true);

        standardTicket.TicketStatus = BookingStatus.Booked;
        vipTicket.TicketStatus = BookingStatus.Booked;
        imaxTicket.TicketStatus = BookingStatus.Booked;

        cinema.AddTicket(standardTicket);
        cinema.AddTicket(vipTicket);
        cinema.AddTicket(imaxTicket);

        
        cinema.PrintAllTickets();

        VIPTicket vipTicket2 = (VIPTicket)vipTicket.Clone();
        vipTicket2.MovieName = "Interstellar";
        Console.WriteLine("--- Clone Test ---");
        Console.Write("Original : ");
        vipTicket.Print();
        Console.Write("Clone    : ");
        vipTicket2.Print();

        Console.WriteLine();
        standardTicket.TicketStatus = BookingStatus.Cancelled;
        Console.WriteLine("--- After Cancellation ---");
        standardTicket.Print();

        Console.WriteLine();
        
        // Preparing the array for BookingHelper class
        IPrintable[] printables = [standardTicket, vipTicket, imaxTicket];
        
        Console.WriteLine("--- BookingHelper.PrintAll ---");
        BookingHelper.PrintAll(printables);
        
        Console.WriteLine();
        
        cinema.CloseCinema();
    }
}