namespace MovieTicketBookingSystem;

public class Cinema
{
    private Ticket[] _tickets = new Ticket[20];
    private int _count;

    public int Count => _count;

    public Ticket this[int index]
    {
        get
        {
            if (index < 0 || index > _tickets.Length)
                return null;

            return _tickets[index];
        }
        set
        {
            if (index < 0 || index > _tickets.Length)
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
}