namespace MovieTicketBookingSystem;

public class Cinema
{
    public string CinemaName { get; set; }
    
    private Projector CinemaProjector = new Projector();

    private Ticket[] _tickets = new Ticket[20];
    private int _count;

    public int Count => _count;

    public Ticket this[int index]
    {
        get
        {
            if (index < 0 || index >= _tickets.Length)
                return null;

            return _tickets[index];
        }
        set
        {
            if (index < 0 || index >= _tickets.Length)
            {
                Console.WriteLine("Invalid Index!");
                return;
            }
            
            _tickets[index] = value;
        }
    }
    
    public Ticket this[string movieName]
    {
        get
        {
            foreach (var existingTicket in _tickets)
            {
                if (existingTicket.MovieName.Equals(movieName, StringComparison.OrdinalIgnoreCase))
                    return existingTicket;
            }

            return null;
        }
    }
    
    public bool AddTicket(Ticket t)
    {
        if (_count == _tickets.Length)
            return false;

        _tickets[_count] = t;

        _count++;

        return true;
    }

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
        Console.WriteLine();
    }
    
    public void CloseCinema()
    {
        CinemaProjector.StopProjector();
        Console.WriteLine("=== Cinema Closed ===");
    }
    
    // The Cinema should also be able to print all its tickets using this contract.
    public static void ProcessTicket(IPrintable printable)
    {
        if (printable is not null)
            printable.Print();
    }
}

public class Projector
{
    private bool _isCurrentlyWorking { get; set; }

    public Projector()
    {
    }

    public void StarProjector()
    {
        _isCurrentlyWorking = true;
    }
    
    public void StopProjector()
    {
        _isCurrentlyWorking = false;
    }
}