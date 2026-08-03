namespace Session01;

public class ProductLengthComparer : IComparer<string>
{
    public int Compare(string? x, string? y)
    {
        return x?.Length.CompareTo(y?.Length) ?? 9;
    }
}