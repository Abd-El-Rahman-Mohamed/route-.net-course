namespace MovieTicketBookingSystem;


/*
 1. No Plain Tickets — The manager noticed that in theory, someone could create a plain Ticket object that 
 doesn't belong to any category. This should never happen — every ticket must be either Standard, VIP, or 
 IMAX. The system should enforce this at the design level so the compiler itself prevents creating a plain 
 Ticket. At the same time, there are some calculations that every ticket type must provide its own version of 
 (like how the final price is calculated), while other behaviors (like booking and cancellation) should stay 
 shared across all types.
 */
public abstract class Ticket : IBookingAndCancellation, IPrintable
{
    private string _movieName;
    private BookingStatus _ticketStatus;
    private decimal _price;
    private double DiscountAmount;
    public Type Type { get; init; }

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
        protected set
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
            if (value == BookingStatus.Booked && _ticketStatus == BookingStatus.Booked)
            {
                Console.WriteLine("A ticket can only be booked once");
                return;
            }

            if (value == BookingStatus.Cancelled && _ticketStatus != BookingStatus.Booked)
            {
                Console.WriteLine("A ticket can only be cancelled if it is currently booked");
                return;
            }
            
            _ticketStatus = value;
        }
    }
    
    // This should never happen — every ticket must be either Standard, VIP, or IMAX.
    // This is done by preventing instantiating the Ticket object.
    protected Ticket(string movieName, decimal price, double discountAmount, Type type)
    {
        if (price < 0)
        {
            Console.WriteLine("Price cannot be smaller than 0!");
            return;
        }

        MovieName = movieName;
        Price = price;
        DiscountAmount = discountAmount;
        Type = type;
        
        ticketCounter++;
        TicketId = ticketCounter;
    }

    protected Ticket()
    {
    }
    
    // At the same time, there are some calculations that every ticket type must provide its own version of 
    // (like how the final price is calculated)
    // So I made setting the property of Price is `private` and adding the keyword `abstract` to obligate
    // child classes to have their own implemented version of the method.
    public abstract decimal GetPrice();

    public abstract void SetPrice(decimal price);

    public abstract void SetPrice(decimal decimalBase, decimal multiplier);

    public void ApplyDiscount(double discountAmount)
    {
        if (discountAmount > 0 && (decimal)discountAmount < Price)
        {
            Price -= (decimal)discountAmount;
            DiscountAmount = 0;
        }
    }

    protected string TicketDetails()
        => $"[Ticket #{TicketId}] {MovieName}";

    public virtual void Print()
        => Console.WriteLine(TicketDetails());

    public static int GetTotalTickets() 
        => ticketCounter;

    public override string ToString()
        => $"Movie Name: {MovieName}, Price: {Price}, TicketId: {TicketId}";
}