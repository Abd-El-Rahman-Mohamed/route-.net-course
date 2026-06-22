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
        : base(movieName, price, 0, Type.IMAX)
    {
        Is3D = is3D;

        if (Is3D)
        {
            price += 30m;
        }
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

    /*
     All ticket types (Standard, VIP, IMAX) should follow this contract, 
     and each one should print its own specific details.
     */ 
    public void Print()
        => Console.WriteLine($"{TicketDetails()} | IMAX | 3D: {(Is3D ? "Yes" : "No")} | Price: {Price} | Final: {PriceAfterTax:0.0} | Booked: {(TicketStatus == BookingStatus.Booked ? "Yes" : "No")}");
}