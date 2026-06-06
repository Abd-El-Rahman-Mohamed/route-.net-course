namespace MovieTicketBookingSystem;


public class IMAXTicket : Ticket
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
    
    // 2. In each child class, provide its own version of PrintTicket():
    // c. IMAXTicket — prints the base ticket info and whether it is 3D.
    public override void PrintTicket()
        => Console.WriteLine($"{TicketDetails()} | IMAX 3D: {(Is3D ? "Yes" : "No")}");
}