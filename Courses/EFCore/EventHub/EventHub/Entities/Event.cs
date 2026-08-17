namespace EventHub.Entities;

// Once their account is set up, an organizer can publish events on the platform.
public class Event
{
    public int Id { get; set; }

    // Every event carries a title
    public string Title { get; set; } = null!;

    // a detailed description
    public string Description { get; set; } = null!;

    // a start date
    public DateTime StartDate { get; set; }

    // an optional end date
    public DateTime? EndDate { get; set; }

    // and a maximum number of attendees allowed
    public int MaximumNumberOfAttendees { get; set; }

    // Once their account is set up, an organizer can publish events on the platform.
    public int OrganizerId { get; set; }
    public Organizer Organizer { get; set; } = null!;

    // Sessions can only belong to one parent event, and a parent event can have any number of sessions.
    public int? ParentEventId { get; set; }
    public Event ParentEvent { get; set; } = null!;

    // Large-scale events such as annual conferences may also contain smaller, more
    //  focused sessions within them.
    // For example, a technology conference might host
    //  several breakout workshops on the same day, with each workshop treated as a
    //  distinct event that is nested under the main conference event.
    public ICollection<Event> Sessions { get; set; } = [];
}