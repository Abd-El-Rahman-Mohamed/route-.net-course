namespace MovieTicketBookingSystem;

/*
 All ticket types (Standard, VIP, IMAX) should follow this contract
 */
public class IMAXTicket : Ticket, IPrintable
{

    public bool Is3D { get; set; }
    
    public override string ToString()
        => base.ToString() + $", Is3D: {Is3D}";
    
    public IMAXTicket(string movieName, decimal price, bool is3D)
        : base(movieName, price, 0)
    {
        Is3D = is3D;

        if (Is3D)
        {
            price += 30m;
        }
    }
 
    /*
     All ticket types (Standard, VIP, IMAX) should follow this contract, 
     and each one should print its own specific details.
     */ 
    public void Print()
        => Console.WriteLine($"{TicketDetails()} | IMAX | 3D: {(Is3D ? "Yes" : "No")} | Price: {Price} | After Tax: {PriceAfterTax:0.0} | Booked: {(TicketStatus == BookingStatus.Booked ? "Yes" : "No")}");
}