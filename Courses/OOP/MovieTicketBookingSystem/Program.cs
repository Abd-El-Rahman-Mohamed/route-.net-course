using System.Diagnostics;

namespace MovieTicketBookingSystem;

class Program
{
    static void Main(string[] args)
    {
        Cinema cinema = new Cinema();
        cinema.OpenCinema();

        // a. Try to create a plain Ticket object and show (in a comment) that the compiler prevents it.
        // Ticket t = new Ticket("Test", 100m); // ERROR: Cannot create instance of abstract type 'Ticket'
        Console.WriteLine("// Ticket t = new Ticket(\"Test\", 100); // ERROR: Cannot create instance of abstract type 'Ticket'");

        Console.WriteLine();

        // b. Create one of each ticket type with hardcoded data. Book all three.

        StandardTicket standardTicket = new StandardTicket("Inception", 80m, "A5");
        VIPTicket vipTicket = new VIPTicket("Avengers", 200m, true, 50m);
        IMAXTicket imaxTicket = new IMAXTicket("Dune", 130m, true);

        standardTicket.TicketStatus = BookingStatus.Booked;
        vipTicket.TicketStatus = BookingStatus.Booked;
        imaxTicket.TicketStatus = BookingStatus.Booked;

        // c. Add all three tickets to a Cinema and print them all (the print should go through the Cinema's
        // reporting partial file).
        cinema.AddTicket(standardTicket);
        cinema.AddTicket(vipTicket);
        cinema.AddTicket(imaxTicket);
        
        cinema.PrintAllTickets();

        Console.WriteLine("--- Polymorphism: Final Price per Ticket ---");
        for (int i = 0; i < cinema.Count; i++)
        {
            cinema[i].SetPrice(cinema[i].PriceAfterTax);
        }
        
        // d. Use polymorphism: loop through a Ticket[] array and call the abstract method on each to show each
        // type calculates differently.
        for (int i = 0; i < cinema.Count; i++)
        {
            string ticketType;
            if (cinema[i] is StandardTicket)
                ticketType = "StandardTicket";
            else if (cinema[i] is VIPTicket)
                ticketType = "VIPTicket";
            else
                ticketType = "IMAXType";

            Console.WriteLine($"{ticketType} => Final Price : {cinema[i].Price}");
        }

        Console.WriteLine();
        
        // e. Call an extension method on a ticket to generate a receipt string and print it.
        vipTicket.SetPrice(200m);
        Console.WriteLine("--- Extension Method: Receipt ---");
        Console.WriteLine(vipTicket.GenerateReceipt());

        // We cannot access the Cinema's Tickets array, so we'll create a new one
        // f. Call an extension method on the ticket array to calculate and print the total revenue.
        Ticket[] ticketArray = new Ticket[cinema.Count];
        for (int i = 0; i < cinema.Count; i++)
            ticketArray[i] = cinema[i];
        
        Console.WriteLine("--- Extension Method: Total Revenue ---");
        Console.WriteLine($"Total Revenue: {standardTicket.CalculateTotalValue(ticketArray)}");
        
        // g. Close the Cinema.
        cinema.CloseCinema();
    }
}