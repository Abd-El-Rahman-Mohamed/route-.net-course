namespace MovieTicketBookingSystem;

/*
 2. Create three child classes that inherit from Ticket
 */

/*
 b. VIPTicket — adds LoungeAccess (bool) and ServiceFee (decimal) = 50.
 */
public class VIPTicket : Ticket
{
    /*
     b. adds LoungeAccess (bool)
     */
    public bool LoungeAccess { get; set; }
    /*
     b. ServiceFee (decimal) = 50.
     */
    public decimal ServiceFee { get; set; } = 50m;
    
    /*
     Each child class should override ToString() to include its own extra info.
     */
    public override string ToString()
        => base.ToString() + $", LoungeAccess: {LoungeAccess}, ServiceFee: {ServiceFee}";
    
    public VIPTicket(string movieName, decimal price, bool loungeAccess, decimal serviceFee)
        : base(movieName, price, 0)
    {
        LoungeAccess = loungeAccess;
        ServiceFee = serviceFee;
    }
}