using System.ComponentModel.DataAnnotations.Schema;

namespace EventHub.Entities;

// People who wish to attend can register for any event as attendees.
public class Attendee
{
    public int Id { get; set; }
    
    // Each attendee provides their full name,
    public string FullName { get; set; } = null!;

    // an email address
    public string EmailAddress { get; set; } = null!;

    // and a home address that includes a street
    public string Street { get; set; } = null!;

    // city
    public string City { get; set; } = null!;

    // country
    public string Country { get; set; } = null!;

    // and postal code 
    public string PostalCode { get; set; } = null!;
    
    // used for correspondence purposes.
    [NotMapped]
    public string HomeAddress => $"Street: {Street}, City: {City}, Country: {Country}, Postal Code: {PostalCode}";
    
    // each attendee can have at most one badge.
    public int? BadgeId { get; set; }
    public Badge? Badge { get; set; }
}