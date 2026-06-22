using System.Reflection;

namespace Assignment1;

public class Book
{
    public string Title;
    public string ISBN;
    public string Author;
    private string SecretOfTheStory;

    public Book(string title, string isbn, string author)
    {
        Title = title;
        ISBN = isbn;
        Author = author;
        
    }
    
    public Book(string title, string isbn)
        : this(title, isbn, "Anonymous")
    {
    }
    
    public Book(string title)
        : this(title, "N/A", "Anonymous")
    {
    }
    
    public string GetBookDetails()
        => $"Book Title: {Title}, Book ISBN: {ISBN}, Book Author: {Author}";
}