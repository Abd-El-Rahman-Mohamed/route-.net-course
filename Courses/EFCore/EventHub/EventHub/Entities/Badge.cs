namespace EventHub.Entities;

// Once an attendee has registered for at least one event, the platform issues them a badge
public class Badge
{
    public int Id { get; set; }

    // a credential uniquely numbered per attendee,
    public string SequentialNumber { get; set; } = null!;

    // stamped with the date it was issued,
    public DateTime IssuedAt { get; set; }
    
    // and assigned a tier based on their registration history: either Standard or VIP.
    public BadgeTier BadgeTier { get; set; }

    // A badge belongs to one attendee, and each attendee can have at most one badge.
    public int AttendeeId { get; set; }
    public Attendee Attendee { get; set; } = null!;
}