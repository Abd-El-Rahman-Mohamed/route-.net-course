namespace EventHub.Entities;

// An attendee can register for multiple events, and any given event will naturally
//  have many attendees signed up for it.
public class Registrations
{
    public int Id { get; set; }
    
    // When registering, an attendee may optionally leave a short note to the organizer
    public string? Note { get; set; }

    public int AttendeeId { get; set; }
    public Attendee Attendee { get; set; } = null!;
    
    public int EventId { get; set; }
    public Event Event { get; set; } = null!;

    // and the platform automatically records the exact date and time the registration was completed.
    public DateTime RegistrationCompletionDateTime { get; set; } = DateTime.UtcNow;
}