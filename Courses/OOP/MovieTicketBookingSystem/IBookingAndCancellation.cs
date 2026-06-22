namespace MovieTicketBookingSystem;

/*
 2. Booking & Cancellation — Right now, tickets are created but there is no way to track whether a ticket is 
 actually booked or cancelled. The manager wants every ticket to support booking and cancellation operations. 
 A ticket can only be booked once (trying to book an already-booked ticket should fail), and can only be 
 cancelled if it is currently booked (trying to cancel a non-booked ticket should fail). The booking status 
 should appear when the ticket is printed.
 */
public interface IBookingAndCancellation
{
    public BookingStatus TicketStatus { get; set; }
}