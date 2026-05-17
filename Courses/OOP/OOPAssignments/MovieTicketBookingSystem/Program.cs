namespace MovieTicketBookingSystem;

class Program
{
    static void Main(string[] args)
    {
        
        Cinema myTickets = new Cinema();
        Console.WriteLine("========== Ticket Booking ==========");
        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine();
            Console.WriteLine($"Enter data for Ticket {i+1}");
        
            Console.Write("Movie Name: ");
            string movieName = Console.ReadLine();
        
            Console.Write("Ticket Type (0=Standard, 1=VIP, 2=IMAX): ");
            bool isTypeParsed = Enum.TryParse(Console.ReadLine(), out Type type);
            if (!isTypeParsed)
            {
                Console.WriteLine("Invalid Type!");
                return;
            }
        
            Console.Write("Seat Row (A-Z): ");
            bool isRowParsed = char.TryParse(Console.ReadLine(), out char row);
            if (!isRowParsed)
            {
                Console.WriteLine("Invalid Seat Row!");
                return;
            }
        
            Console.Write("Seat Number: ");
            bool isNumberParsed = int.TryParse(Console.ReadLine(), out int number);
            if (!isNumberParsed || number < 0)
            {
                Console.WriteLine("Invalid Seat Number!");
                return;
            }
        
            Console.Write("Price: ");
            bool isPriceParsed = decimal.TryParse(Console.ReadLine(), out decimal price);
            if (!isPriceParsed || price < 0 )
            {
                Console.WriteLine("Invalid Price!");
                return;
            }
            
            Ticket t = new Ticket(movieName, type, new SeatLocation(row,number), price, 0);
            // myTickets[i] = t;
            myTickets.AddTicket(t);
        }
        
        
        
        Console.WriteLine("========== All Tickets ==========");
        Console.WriteLine();
        for (int i = 0; i < 3; i++)
        {
            int ticketId = myTickets[i].TicketId;
            string movieName = myTickets[i].MovieName;
            Type type = myTickets[i].Type;
            char seatRow = myTickets[i].Seat.Row;
            int seatNumber = myTickets[i].Seat.Number;
            decimal price = myTickets[i].Price;
            decimal afterTax = myTickets[i].PriceAfterTax;
            
            Console.WriteLine($"Ticket #{ticketId} | {movieName} | {type} | Seat: {seatRow}-{seatNumber} | Price: {price} EGP | After Tax: {afterTax} EGP");
        }
        
        Console.WriteLine();
        Console.WriteLine("========== Search by Movie ==========");
        Console.Write("Enter movie name to search: ");
        string movieNameToSearch = Console.ReadLine();
        
        if (myTickets[movieNameToSearch] != null)
        {
            int searchTicketId = myTickets[movieNameToSearch].TicketId;
            string searchTicketMovieName = myTickets[movieNameToSearch].MovieName;
            Type searchTicketType = myTickets[movieNameToSearch].Type;
            char searchTicketSeatRow = myTickets[movieNameToSearch].Seat.Row;
            int searchTicketSeatNumber = myTickets[movieNameToSearch].Seat.Number;
            decimal searchTicketPrice = myTickets[movieNameToSearch].Price;
            decimal searchTicketAfterTax = myTickets[movieNameToSearch].PriceAfterTax;
            Console.WriteLine($"Found: Ticket #{searchTicketId} | {searchTicketMovieName} | {searchTicketType} | Seat: {searchTicketSeatRow}-{searchTicketSeatNumber} | Price: {searchTicketPrice} EGP");
        }
        else 
            Console.WriteLine("Ticket Not Found!");
        
        Console.WriteLine();
        Console.WriteLine("========== Statistics ==========");
        Console.WriteLine($"Total Ticket Sold: {myTickets.Count}");
        
        Console.WriteLine();
        Console.WriteLine($"Booking Reference 1: {BookingHelper.GenerateBookingReference()}");
        Console.WriteLine($"Booking Reference 2: {BookingHelper.GenerateBookingReference()}");

        Console.WriteLine();
        Console.WriteLine($"Group Discount (5 tickets x 80 EGP): {BookingHelper.CalcGroupDiscount(5, 80) } EGP (10% off applied)");
    }
}