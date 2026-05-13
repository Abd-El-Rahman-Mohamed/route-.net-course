namespace MovieTicketBookingSystem;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter Movie Name: ");
        string movieName = Console.ReadLine()!;
        if (string.IsNullOrWhiteSpace(movieName))
        {
            Console.WriteLine("Movie Name cannot be empty");
            return;
        }

        Console.Write("Enter Ticket Type (0 = Standard, 1 = VIP, 2 = IMAX ) : ");
        bool isTypeParsed = Enum.TryParse(Console.ReadLine(), out Type type);
        if (!isTypeParsed)
        {
            Console.WriteLine("Invalid Type!");
            return;
        }

        Console.Write("Enter Seat Row (A, B, C...): ");
        bool isRowParsed = char.TryParse(Console.ReadLine(), out char row);
        if (!isRowParsed)
        {
            Console.WriteLine("Invalid Seat Row!");
            return;
        }
        
        Console.Write("Enter Seat Number: ");
        bool isNumberParsed = int.TryParse(Console.ReadLine(), out int number);
        if (!isNumberParsed || number < 0)
        {
            Console.WriteLine("Invalid Seat Number!");
            return;
        }
        
        SeatLocation seat = new SeatLocation(row, number);
        
        Console.Write("Enter Price: ");
        bool isPriceParsed = decimal.TryParse(Console.ReadLine(), out decimal price);
        if (!isPriceParsed || price < 0 )
        {
            Console.WriteLine("Invalid Price!");
            return;
        }
        
        Console.Write("Enter Discount Amount: ");
        bool isDiscountAmountParsed = double.TryParse(Console.ReadLine(), out double discountAmount);
        if (!isDiscountAmountParsed || discountAmount < 0 )
        {
            Console.WriteLine("Invalid Discount Amount!");
            return;
        }
        
        // Ticket ticket = new Ticket(movieName, type, seat, price, discountAmount);
        Ticket ticket = new Ticket(movieName, type, seat, price, discountAmount);
        ticket.PrintTicket();
    }
}

/*
1. Each ticket has a type that can only be one of: Standard, VIP, or IMAX. How would you represent this?

    I would represent it using enum 
*/

/*
2. You need a type to represent a seat location (Row as a char like 'A', 'B', and Number as an int). 
Should this be a class or a struct? Create it.

This will be a struct, because it's a whole single thing represent by two fields.
*/