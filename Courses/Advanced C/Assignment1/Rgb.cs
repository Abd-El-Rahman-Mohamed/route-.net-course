namespace Assignment1;

// Q7: What is the 'struct' constraint? Write an example.
public struct Rgb(double r, double g, double b) : ICombine<Rgb>
{
    public double R { get; private set; }
    public double G { get; private set; }
    public double B { get; private set; }
    
    public string Combine()
        => $"{R},{G},{B}";
}