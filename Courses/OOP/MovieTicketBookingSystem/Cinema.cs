namespace MovieTicketBookingSystem;

/*
 2. Organized Cinema Code — The Cinema class is growing too large with ticket management, reporting, and 
 projector control all in one file. The development team wants to split it into multiple files for better 
 organization, without creating separate classes. One file should handle ticket operations (adding tickets, 
 booking), and another should handle reporting (printing all tickets, showing statistics). Both files should 
 contribute to a single Cinema class. 
 */
// and another should handle reporting (printing all tickets, showing statistics)
public partial class Cinema
{
    public string CinemaName { get; set; }
    
    private Projector CinemaProjector = new Projector();

    public void PrintAllTickets()
    {
        Console.WriteLine("--- All Tickets ---");
        for (int i = 0; i < _count; i++)
        {
            ProcessTicket(_tickets[i]);
        }

        Console.WriteLine();
    }

    public void OpenCinema()
    {
        CinemaProjector.StarProjector();
        Console.WriteLine("=== Cinema Opened ===");
    }
    
    public void CloseCinema()
    {
        CinemaProjector.StopProjector();
        Console.WriteLine("");
        Console.WriteLine("=== Cinema Closed ===");
    }
}