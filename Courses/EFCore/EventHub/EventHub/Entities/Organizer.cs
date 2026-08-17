namespace EventHub.Entities;

// When a person or a company decides to host events through the platform, they
//  first register as an organizer by  
public class Organizer
{
    public int Id { get; set; }

    // providing their name
    public string Name { get; set; } = null!;

    // if applicable, the name of the company they represent.
    public string? CompanyName { get; set; }

    // The platform assigns each organizer a verified status after completing an internal review process.
    public bool IsVerified { get; set; }
    
    // This profile page is directly tied to the organizer’s account and cannot exist without it. 👇
    
    // Alongside their account, every organizer maintains a public-facing profile page where they can write a
    // short biography
    public string? Biography { get; set; }

    // biography, link to their personal or company website
    public string? WebsiteUrl { get; set; }
    
    // and upload a logo
    public string? LogoUrl { get; set; }
    
    // Once their account is set up, an organizer can publish events on the platform.
    public ICollection<Event> Events { get; set; }
}