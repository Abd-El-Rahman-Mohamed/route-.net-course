namespace MovieTicketBookingSystem;

public class Ticket
{
    private string _movieName;
    public Type Type;
    public SeatLocation Seat;
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
    
    public Ticket(string movieName, Type type, SeatLocation seat, decimal price, double discountAmount)
    {
        if (price < 0)
        {
            Console.WriteLine("Price cannot be smaller than 0!");
            return;
        }

        MovieName = movieName;
        Type = type;
        Seat = seat;
        Price = price;
        DiscountAmount = discountAmount;
        
        ticketCounter++;
        TicketId = ticketCounter;
    }
    
    public Ticket(string movieName)
        : this(movieName, Type.Standard, new SeatLocation('A',1), 50m, 0)
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
        Console.WriteLine($"Type      : {Type}");
        Console.WriteLine($"Seat      : {Seat.Row}{Seat.Number}");
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
            Console.WriteLine($"Type     : {Type}");
            Console.WriteLine($"Seat     : {Seat.Row}{Seat.Number}");
            Console.WriteLine($"Price    : {Price}");
            Console.WriteLine($"Total (14% tax) : {PriceAfterTax}");
        }
    }

    public static int GetTotalTicketsSold() 
        => ticketCounter;
}