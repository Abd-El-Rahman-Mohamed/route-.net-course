namespace MovieTicketBookingSystem;

public class BookingHelper
{
    private static int _counter = 0;
    public static double CalcGroupDiscount(int numberOfTickets, double pricePerTicket)
    {
        if (numberOfTickets >= 5)
            return (pricePerTicket - (pricePerTicket * 0.1)) * 5;

        return (pricePerTicket * numberOfTickets);
    }

    public static string GenerateBookingReference()
    {
        _counter++;

        return $"BK-{_counter}";
    }

    /*
      There should also be a utility method in BookingHelper that can accept an array of any printable objects and 
      print them all — without knowing their actual types
     */
    public static void PrintAll(IPrintable[] printables)
    {
        foreach (var printable in printables)
        {
            printable.Print();
        }
    }
}