namespace Assignment1;

// Q14: Write a SafeList<T> that returns default when the index is invalid
public class SafeList<T>
{
    private readonly List<T> _list = [];

    public void Add(T item)
        => _list.Add(item);

    public T? GetAt(int index)
    {
        if (index >= 0 && index < _list.Count)
            return _list[index];

        return default;
    }
}