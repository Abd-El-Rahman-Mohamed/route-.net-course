namespace MovieTicketBookingSystem;

/*
    All ticket types (Standard, VIP, IMAX) should follow this contract.
*/
public class StandardTicket : Ticket, IPrintable
{
    public string SeatNumber { get; set; }
    
    public override string ToString()
        => base.ToString() + $", SeatNumber: {SeatNumber}";

    public StandardTicket(string movieName, decimal price, string seatNumber)
        : base(movieName, price, 0)
    {
        SeatNumber = seatNumber;
    }

    /*
        All ticket types (Standard, VIP, IMAX) should follow this contract,
        and each one should print its own specific details.
    */
    public void Print()
        => Console.WriteLine($"{TicketDetails()} | Standard | Seat: {SeatNumber} | Price: {Price} | After Tax: {PriceAfterTax:0.0} | Booked: {(TicketStatus == BookingStatus.Booked ? "Yes" : "No")}");
}