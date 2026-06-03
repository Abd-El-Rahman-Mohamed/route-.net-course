namespace MovieTicketBookingSystem;

/*
    1. Create a base class Ticket with:
*/
public class Ticket
{
    private string _movieName;
    private decimal _price;
    private double DiscountAmount;

    private static int ticketCounter = 0;

    /*
     a. TicketId (int, read-only, auto-incremented)
     */
    public int TicketId { get; }

    /*
     a. MovieName (string)
     */
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
    
    /*
     a. Price (decimal, must be > 0)
     */
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

    /*
     c. A computed property PriceAfterTax that returns the price with 14% tax.
     */
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

    /*
     b. A constructor that takes movieName and price.
     */
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

    public void ApplyDiscount(double discountAmount)
    {
        if (discountAmount > 0 && (decimal)discountAmount < Price)
        {
            Price -= (decimal)discountAmount;
            DiscountAmount = 0;
        }
    }

    public void PrintTicket()
    {
        Console.WriteLine();
        
        Console.WriteLine("===== Ticket Info =====");
        Console.WriteLine($"Movie     : {MovieName}");
        Console.WriteLine($"Price     : {Price}");
        Console.WriteLine($"Total (14% tax) : {PriceAfterTax}");

        if (DiscountAmount != 0)
        {
            Console.WriteLine();

            Console.WriteLine("===== After Discount =====");
            Console.WriteLine($"Discount Before : {DiscountAmount}");
            ApplyDiscount(DiscountAmount);
            Console.WriteLine($"Discount After  : {DiscountAmount}");
            Console.WriteLine($"Movie    : {MovieName}");
            Console.WriteLine($"Price    : {Price}");
            Console.WriteLine($"Total (14% tax) : {PriceAfterTax}");
        }
    }

    /*
     e. A static int GetTotalTickets() method that returns the total number of tickets created.
     */
    public static int GetTotalTickets() 
        => ticketCounter;

    /*
     d. Override ToString() to return the ticket info.
     */
    public override string ToString()
        => $"Movie Name: {MovieName}, Price: {Price}, TicketId: {TicketId}";
}