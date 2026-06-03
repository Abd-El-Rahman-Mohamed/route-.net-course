namespace MovieTicketBookingSystem;

/*
 3. Create a Cinema class that has a CinemaName, a Projector object (created inside Cinema), and holds up to 20 tickets.
 */
public class Cinema
{
    /*
     3. CinemaName
     */
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
    
    /*
     a. AddTicket(Ticket t) — adds a ticket to the first available slot.
     */
    public bool AddTicket(Ticket t)
    {
        if (_count == _tickets.Length)
            return false;

        _tickets[_count] = t;

        _count++;

        return true;
    }

    /*
     b. PrintAllTickets() — prints all tickets.
     */
    public void PrintAllTickets()
    {
        Console.WriteLine("========== All Tickets ==========");
        for (int i = 0; i < _count; i++)
        {
            int ticketId = _tickets[i].TicketId;
            string movieName = _tickets[i].MovieName;
            decimal price = _tickets[i].Price;
            decimal afterTax = _tickets[i].PriceAfterTax;
            
            string details = $"Ticket #{ticketId} | {movieName} | Price: {price} EGP | After Tax: {afterTax} EGP";

            if (_tickets[i] is StandardTicket standardTicket)
            {
                details += $" | Seat: {standardTicket.SeatNumber}";
            }
            else if (_tickets[i] is VIPTicket vipTicket)
            {
                details += $" | Lounge: {(vipTicket.LoungeAccess ? "Yes" : "No")} | Service Fee: {vipTicket.ServiceFee} EGP";
            }
            else if (_tickets[i] is IMAXTicket imaxTicket)
            {
                details += $" | IMAX 3D: {(imaxTicket.Is3D ? "Yes" : "No")}";
            }
            
            Console.WriteLine(details);
        }

        Console.WriteLine();
    }

    /*
     c. OpenCinema() and CloseCinema() — start/stop the projector.
     */
    public void OpenCinema()
    {
        /*
         3. a Projector object (created inside Cinema)
         */
        CinemaProjector.StarProjector();
        Console.WriteLine("========== Cinema Opened ==========");
        Console.WriteLine("Projector started.");
        Console.WriteLine();
    }
    
    public void CloseCinema()
    {
        /*
         3. a Projector object (created inside Cinema)
        */
        CinemaProjector.StopProjector();
        Console.WriteLine("========== Cinema Closed ==========");
        Console.WriteLine("Projector stopped.");
        Console.WriteLine();
    }
}

/*
 3. a Projector object (created inside Cinema)
 */
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