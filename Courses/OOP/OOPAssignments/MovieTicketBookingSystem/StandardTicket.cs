namespace MovieTicketBookingSystem;

public class StandardTicket : Ticket
{
    public string SeatNumber { get; set; }
    
    public override string ToString()
        => base.ToString() + $", SeatNumber: {SeatNumber}";

    public StandardTicket(string movieName, decimal price, string seatNumber)
        : base(movieName, price, 0)
    {
        SeatNumber = seatNumber;
    }

    // 2. In each child class, provide its own version of PrintTicket():
    // a. StandardTicket — prints the base ticket info and the SeatNumber.
    public override void PrintTicket()
        => Console.WriteLine($"{TicketDetails()} | Seat: {SeatNumber}");
}