namespace Assignment1;

// Q7: What is the 'struct' constraint? Write an example.
public struct Point(int x, int y) : ICombine<Point>
{
    private int X { get; set; } = x;
    private int Y { get; set; } = y;

    public string Combine()
        => $"{X},{Y}";
}