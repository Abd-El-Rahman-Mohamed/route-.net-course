namespace Assignment1.Entities;

public class Book
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string ISBN { get; set; } = null!;

    public decimal Price { get; set; }

    public int NumberOfPages { get; set; }

    public int PublicationYear { get; set; }

    public bool IsInStock { get; set; }
}