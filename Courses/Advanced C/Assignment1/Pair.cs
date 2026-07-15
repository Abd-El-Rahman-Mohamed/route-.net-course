namespace Assignment1;

// Q3:What are multiple type parameters-? Write Pair<TKey, TValue>
public struct Pair<TKey, TValue>(TKey key, TValue value)
{
    public TKey Key { get; init; } = key;
    public TValue Value { get; init; } = value;
}