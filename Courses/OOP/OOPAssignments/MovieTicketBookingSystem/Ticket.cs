namespace MovieTicketBookingSystem;

public class Ticket : IBookingAndCancellation, IPrintable
{
    private string _movieName;
    private BookingStatus _ticketStatus;
    private decimal _price;
    private double DiscountAmount;

    private static int ticketCounter = 0;

    public int TicketId { get; }

    public string MovieName
    {
        get 
        {
            return _movieName;
        }
        set
        {
            if (String.IsNullOrWhiteSpace(value))
            {
                Console.WriteLine("Movie Name cannot be neither Null nor Empty!");
                return;
            }

            _movieName = value;
        }
    }
    
    public decimal Price
    {
        get 
        {
            return _price;
        }
        set
        {
            if (value < 0)
            {
                Console.WriteLine("Price cannot be smaller than 0!");
                return;
            }

            _price = value;
        }
    }

    public decimal PriceAfterTax => (_price + (_price * 0.14m));
    
    public BookingStatus TicketStatus
    {
        get 
        {
            return _ticketStatus;
        }
        set
        {
            /*
             A ticket can only be booked once (trying to book an already-booked ticket should fail)
             */
            if (value == BookingStatus.Booked && _ticketStatus == BookingStatus.Booked)
            {
                Console.WriteLine("A ticket can only be booked once");
                return;
            }

            /*
             and can only be cancelled if it is currently booked (trying to cancel a non-booked ticket should 
             fail)
             */
            if (value == BookingStatus.Cancelled && _ticketStatus != BookingStatus.Booked)
            {
                Console.WriteLine("A ticket can only be cancelled if it is currently booked");
                return;
            }
            
            _ticketStatus = value;
        }
    }
    
    public Ticket(string movieName, decimal price, double discountAmount)
    {
        if (price < 0)
        {
            Console.WriteLine("Price cannot be smaller than 0!");
            return;
        }

        MovieName = movieName;
        Price = price;
        DiscountAmount = discountAmount;
        
        ticketCounter++;
        TicketId = ticketCounter;
    }

    public Ticket(string movieName, decimal price)
        : this(movieName, price, 0)
    {
    }
    
    public Ticket(string movieName)
        : this(movieName, 50m, 0)
    {
    }

    public Ticket()
    {
    }
    
    public decimal GetPrice()
        => _price;
    
    public void SetPrice(decimal price)
        => _price = price;
    
    public void SetPrice(decimal decimalBase, decimal multiplier)
        => _price = decimalBase * multiplier;

    public void ApplyDiscount(double discountAmount)
    {
        if (discountAmount > 0 && (decimal)discountAmount < Price)
        {
            Price -= (decimal)discountAmount;
            DiscountAmount = 0;
        }
    }

    protected string TicketDetails()
        // The booking status should appear when the ticket is printed.
        => $"[Ticket #{TicketId}] {MovieName}";

    public void Print()
        => Console.WriteLine(TicketDetails());

    public static int GetTotalTickets() 
        => ticketCounter;

    public override string ToString()
        => $"Movie Name: {MovieName}, Price: {Price}, TicketId: {TicketId}";
}