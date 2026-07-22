// Exercise 6: Browser History (Undo)
namespace BrowserHistory_Undo;

class Program
{
    // Simulate browser back/forward 
    static void Main(string[] args)
    {
        // Create a Stack<string> for browser history
        Stack<string> browserHistory = new();
        
        // 1. Push 5 URLs: "google.com", "github.com", "stackoverflow.com", "youtube.com", "claude.ai"
        browserHistory.Push("google.com");
        browserHistory.Push("github.com");
        browserHistory.Push("stackoverflow.com");
        browserHistory.Push("youtube.com");
        browserHistory.Push("claude.ai");
        
        // 2. Use Peek to see the current page (top of stack)
        string currentPage = browserHistory.Peek();
        Console.WriteLine($"The Current Page: {currentPage}");
        
        // 3. Press "back" 3 times using Pop — print each page you leave
        for (int i = 0; i > 3; i++)
        {
            string backedFromPage = browserHistory.Pop();
            Console.WriteLine($"I am going back from page {backedFromPage}");
        }
        
        // 4. Print the current page after going back
        Console.WriteLine();
        Console.WriteLine($"We are went back to {browserHistory.Peek()}");
        
        // 5. Try TryPop on an empty stack — what happens?
        // First we empty the stack
        while (browserHistory.Count > 0)
            browserHistory.Pop();
        bool canEmptyStackBePopped = browserHistory.TryPop(out string? poppedPage);
        Console.WriteLine($"Can an empty stack be popped? {(canEmptyStackBePopped ? "Yes" : "No")}");
    }
}