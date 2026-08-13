namespace Assignment1.Entities;

public class Author
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? EmailAddress { get; set; }

    public string? Biography { get; set; }

    public DateTime DateOfBirth { get; set; }
}