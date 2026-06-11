namespace MovieTicketBookingSystem;

/*
 All ticket types (Standard, VIP, IMAX) should follow this contract
*/

/*
 3. Ticket Cloning — Sometimes a customer wants to buy a second ticket with the exact same details as an 
 existing one but for a different movie. The system should be able to create a full independent copy of any 
 ticket (especially VIP tickets). Changing anything on the copy must NOT affect the original ticket.
*/
public class VIPTicket : Ticket, IPrintable, ICloneable
{
    public bool LoungeAccess { get; set; }
    public decimal ServiceFee { get; set; } = 50m;
    
    public override string ToString()
        => base.ToString() + $", LoungeAccess: {LoungeAccess}, ServiceFee: {ServiceFee}";
    
    public VIPTicket(string movieName, decimal price, bool loungeAccess, decimal serviceFee)
        : base(movieName, price, 0)
    {
        LoungeAccess = loungeAccess;
        ServiceFee = serviceFee;
    }
    
    /*
     All ticket types (Standard, VIP, IMAX) should follow this contract,
     and each one should print its own specific details.
    */
    public void Print()
        => Console.WriteLine($"{TicketDetails()} | VIP | Lounge: {(LoungeAccess ? "Yes" : "No")} | Fee: {ServiceFee} | Price: {Price} | After Tax: {PriceAfterTax:0.0} | Booked: {(TicketStatus == BookingStatus.Booked ? "Yes" : "No")}");

    /*
      The system should be able to create a full independent copy of any ticket (especially VIP tickets). Changing 
      anything on the copy must NOT affect the original ticket.
     */
    public object Clone()
        => new VIPTicket(new String(MovieName), Price, LoungeAccess, ServiceFee);
}