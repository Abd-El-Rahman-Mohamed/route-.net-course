namespace MovieTicketBookingSystem;

/*
 2. Create three child classes that inherit from Ticket
 */

/*
 a. StandardTicket — adds SeatNumber (string).
 */
public class StandardTicket : Ticket
{
    /*
     a. adds SeatNumber (string).
     */
    public string SeatNumber { get; set; }
    
    /*
     Each child class should override ToString() to include its own extra info.
     */
    public override string ToString()
        => base.ToString() + $", SeatNumber: {SeatNumber}";

    public StandardTicket(string movieName, decimal price, string seatNumber)
        : base(movieName, price, 0)
    {
        SeatNumber = seatNumber;
    }
}