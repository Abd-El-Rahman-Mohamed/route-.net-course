namespace MovieTicketBookingSystem;

/*
 2. Create three child classes that inherit from Ticket
 */

/*
 c. IMAXTicket — adds Is3D (bool). If true, the price increases by 30 EGP.
 */
public class IMAXTicket : Ticket
{
    /*
     c. adds Is3D (bool).
     */
    public bool Is3D { get; set; }
    
    /*
     Each child class should override ToString() to include its own extra info.
     */
    public override string ToString()
        => base.ToString() + $", Is3D: {Is3D}";
    
    public IMAXTicket(string movieName, decimal price, bool is3D)
        : base(movieName, price, 0)
    {
        Is3D = is3D;

        /*
          c. If true, the price increases by 30 EGP.
         */
        if (Is3D)
        {
            price += 30m;
        }
    }
}