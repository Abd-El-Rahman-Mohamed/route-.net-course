// Exercise 3: Phone Book
namespace PhoneBook;

class Program
{
    // Build a phone book application.
    static void Main(string[] args)
    {
        // 1. Create a Collection  with 4 contacts (name → phone number)
        SortedList<string, string> phoneBook = new()
        {
            ["Ahmed"] = "(212) 555-0143",
            ["Sara"] = "(212) 555-0143",
            ["Ali"] = "(212) 555-0143",
            ["Mona"] = "(212) 555-0143"
        };

        // 2. Add a new contact using [] syntax (add or update)
        // string addedKey = phoneBook.Keys[4] = "NotAhmed";
        phoneBook["Idris"] = "(312) 555-0111"; // Adding
        foreach (KeyValuePair<string, string> phoneContact in phoneBook)
            Console.WriteLine($"{{{phoneContact.Key}, {phoneContact.Value}}}");
        
        Console.WriteLine();
        
        phoneBook["Idris"] = "(123) 456-7890"; // Updating
        foreach (KeyValuePair<string, string> phoneContact in phoneBook)
            Console.WriteLine($"{{{phoneContact.Key}, {phoneContact.Value}}}");

        // 3. Try adding a duplicate using .Add() — catch the exception and print the error 
        try
        {
            phoneBook.Add("Ahmed", "(602) 555-0164");
        }
        catch (Exception ex)
        {
            Console.WriteLine();
            Console.WriteLine($"[ERROR]: {ex.Message}");
        }
        
        // 4. Try adding a duplicate using .TryAdd() — print whether it succeeded
        bool isContactAdded = phoneBook.TryAdd("Ahmed", "(602) 555-0164");
        if (isContactAdded)
            Console.WriteLine("Contact Added Successfully");
        else
            Console.WriteLine("Contact Adding Failed");
        
        // 5. Search for a contact that doesn’t exist
        Console.WriteLine();
        bool doesMostafaExist = phoneBook.ContainsKey("Mostafa");
        Console.WriteLine($"Does \"Mostafa\" exist? {(doesMostafaExist ? "No" : "Yes")}");
        
        // 6. Get a contact with a fallback of "Not Found"
        Console.WriteLine();
        string abdelrahmanOrNotFound = phoneBook.GetValueOrDefault("Abdelrahman", "Not Found");
        Console.WriteLine($"Is Abdelrahman found? {abdelrahmanOrNotFound}");
        
        // 7. Print all Keys on one line, then all Values on another line
        Console.WriteLine();
        Console.WriteLine("--- Keys and Values ---");
        foreach (var phoneContact in phoneBook)
            Console.Write(phoneContact.Key + "\t\t\t"); // Adding tabs to make the output more readable
        Console.WriteLine();
        foreach (var phoneContact in phoneBook)
            Console.Write(phoneContact.Value + "\t\t"); // Adding tabs to make the output more readable
    }
}