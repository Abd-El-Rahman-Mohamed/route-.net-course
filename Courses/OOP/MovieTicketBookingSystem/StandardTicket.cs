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
        : base(movieName, price, 0, Type.Standard)
    {
        SeatNumber = seatNumber;
    }
    
    public override decimal GetPrice()
        => Price;
    
    public override void SetPrice(decimal price)
    {
        if (price < 0)
        {
            Console.WriteLine("Price cannot be smaller than 0!");
            return;
        }
        else
            Price = price;
    }
    
    public override void SetPrice(decimal decimalBase, decimal multiplier)
        => Price = decimalBase * multiplier;
    
    public void Print()
        => Console.WriteLine($"{TicketDetails()} | Standard | Seat: {SeatNumber} | Price: {Price} | Final: {PriceAfterTax:0.0} | Booked: {(TicketStatus == BookingStatus.Booked ? "Yes" : "No")}");
}