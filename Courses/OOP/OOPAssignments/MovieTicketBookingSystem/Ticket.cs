namespace MovieTicketBookingSystem;

// 1. Refactor the base Ticket class:
public class Ticket
{
    private string _movieName;
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
    
    // b. Add two versions of a SetPrice method — one that takes a decimal (sets price directly) and one that
    // takes a decimal base price and a decimal multiplier (sets price = base × multiplier).
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
        => $" Ticket #{TicketId} | {MovieName} | Price: {Price:0.00} EGP | After Tax: {PriceAfterTax:0.00} EGP";

    // a. Add a PrintTicket() method that prints: TicketId, MovieName, Price, PriceAfterTax. Child classes
    // should be able to provide their own version of this method.
    public virtual void PrintTicket()
        => Console.WriteLine(TicketDetails());

    public static int GetTotalTickets() 
        => ticketCounter;

    public override string ToString()
        => $"Movie Name: {MovieName}, Price: {Price}, TicketId: {TicketId}";
}