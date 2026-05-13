namespace MovieTicketBookingSystem;

public class Ticket
{
    public string MovieName;
    public Type Type;
    public SeatLocation Seat;
    private decimal Price;
    private double DiscountAmount;
    
    public Ticket(string movieName, Type type, SeatLocation seat, decimal price, double discountAmount)
    {
        MovieName = movieName;
        Type = type;
        Seat = seat;
        Price = price;
        DiscountAmount = discountAmount;
    }
    
    public Ticket(string movieName)
        : this(movieName, Type.Standard, new SeatLocation('A',1), 50m, 0)
    {
    }

    public Ticket()
    {
    }

    public decimal CalcTotal(double taxPercent)
        => (Price + (Price * (decimal)taxPercent));

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
        Console.WriteLine($"Total (14% tax) : {CalcTotal(0.14)}");

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
            Console.WriteLine($"Total (14% tax) : {CalcTotal(0.14)}");
        }
    }
}