using System.ComponentModel;

namespace Assignment1;

// Q2: Write a generic class Container<T> with Add and Get methods.
// Q9: What is the 'new()' constraint? Write an example
public class Container<T> : ICreate<Container>
{
    private static readonly List<T> _items = [];
    private static int _count = 0;

    public void Add(T item)
    {
        _items.Add(item);
        _count++;
    }

    public T Get(int index)
    {
        if (index < 0 || index > _count)
            throw new IndexOutOfRangeException($"index must be greater than 0 and less than {_count}");

        return _items[index];
    }

    public Container Create()
        => new Container();
}