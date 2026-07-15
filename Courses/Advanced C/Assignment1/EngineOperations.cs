namespace Assignment1;

// Q11: What is the base class constraint? Write an example.
public static class Engine<T> 
    where T : Car
{
    public static void StartEngine(T car)
        => Console.WriteLine($"Car Engine Started!");
    
    public static void StopEngine(T car)
        => Console.WriteLine($"Car Engine Started!");
}