namespace Assignment1;

public class Cache<TKey, TValue>
{
    private static List<CacheItem<TKey, TValue>> _cached = new();

    public void Add(TKey key, TValue value, uint durationInSeconds)
    {
        Remove(key);
        _cached.Add(new CacheItem<TKey, TValue>(key, value, durationInSeconds));
    }

    public bool Contains(TKey key)
    {
        for (int i = 0; i < _cached.Count; i++)
        {
            if (_cached[i].Key.Equals(key))
            {
                if (_cached[i].IsExpired)
                {
                    _cached.RemoveAt(i);
                    return false;
                }
                return true;
            }
        }
        return false;
    }

    public TValue Get(TKey key)
    {
        for (int i = 0; i < _cached.Count; i++)
        {
            if (_cached[i].Key.Equals(key))
            {
                if (_cached[i].IsExpired)
                {
                    _cached.RemoveAt(i);
                    break;
                }

                return _cached[i].Value;
            }
        }

        throw new KeyNotFoundException("Key is missing or expired.");
    }

    public bool Remove(TKey key)
    {
        for (int i = _cached.Count - 1; i >= 0; i--)
        {
            if (_cached[i].Key.Equals(key))
            {
                _cached.RemoveAt(i);
                return true;
            }
        }

        return false;
    }
}