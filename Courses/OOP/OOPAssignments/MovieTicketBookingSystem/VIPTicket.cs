namespace MovieTicketBookingSystem;

public class VIPTicket : Ticket
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
 
    // 2. In each child class, provide its own version of PrintTicket():
    // b. VIPTicket — prints the base ticket info, LoungeAccess, and ServiceFee.
    public override void PrintTicket()
        => Console.WriteLine($"{TicketDetails()} | Lounge: {(LoungeAccess ? "Yes" : "No")} | Service Fee: {ServiceFee} EGP");
}