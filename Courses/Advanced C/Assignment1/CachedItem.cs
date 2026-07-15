namespace Assignment1;

public struct CacheItem<TKey, TValue>(TKey key, TValue value, uint durationInSeconds)
{
    public TKey Key { get; private set; } = key;
    public TValue Value { get; private set; } = value;
    public DateTime Expiration { get; private set; } = DateTime.UtcNow.AddSeconds(durationInSeconds);
    
    public bool IsExpired => DateTime.UtcNow > Expiration;
}