namespace m1Assessment_Practise.Questions.Question8;

class AdvancedCache<TKey, TValue> where TKey : notnull
{
    private readonly int _capacity;
    private readonly Dictionary<TKey, CacheItem<TValue>> _cache = new();
    private readonly object _lock = new();

    public AdvancedCache(int capacity)
    {
        if (capacity <= 0)
            throw new ArgumentException("Capacity must be positive");
        _capacity = capacity;
    }

    public void Set(TKey key, TValue value, int ttlSeconds)
    {
        if (ttlSeconds <= 0)
            throw new ArgumentException("TTL must be positive");

        lock (_lock)
        {
            var expiryTime = DateTime.Now.AddSeconds(ttlSeconds);
            
            if (_cache.ContainsKey(key))
            {
                _cache[key] = new CacheItem<TValue>(value, expiryTime);
            }
            else
            {
                if (_cache.Count >= _capacity)
                {
                    EvictLRU();
                }
                
                _cache[key] = new CacheItem<TValue>(value, expiryTime);
            }
        }
    }

    public (bool found, TValue? value) Get(TKey key)
    {
        lock (_lock)
        {
            if (!_cache.ContainsKey(key))
                return (false, default);

            var item = _cache[key];

            if (DateTime.Now > item.ExpiryTime)
            {
                _cache.Remove(key);
                return (false, default);
            }

            item.LastAccessed = DateTime.Now;
            return (true, item.Value);
        }
    }

    private void EvictLRU()
    {
        var expiredKeys = _cache
            .Where(kvp => DateTime.Now > kvp.Value.ExpiryTime)
            .Select(kvp => kvp.Key)
            .ToList();

        foreach (var key in expiredKeys)
        {
            _cache.Remove(key);
        }

        if (_cache.Count >= _capacity)
        {
            var lruKey = _cache
                .OrderBy(kvp => kvp.Value.LastAccessed)
                .First()
                .Key;
            
            _cache.Remove(lruKey);
            Console.WriteLine($"Evicted LRU key: {lruKey}");
        }
    }

    public int Count
    {
        get
        {
            lock (_lock)
            {
                return _cache.Count;
            }
        }
    }
}
