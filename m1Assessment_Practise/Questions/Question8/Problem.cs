// Question 8: Cache with TTL + LRU Eviction
namespace m1Assessment_Practise.Questions.Question8;

class Problem
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Question 8: Cache with TTL + LRU Eviction ===\n");

        var cache = new AdvancedCache<string, string>(capacity: 3);

        cache.Set("key1", "value1", ttlSeconds: 5);
        cache.Set("key2", "value2", ttlSeconds: 10);
        cache.Set("key3", "value3", ttlSeconds: 10);

        Console.WriteLine($"Cache size: {cache.Count}");

        var (found1, val1) = cache.Get("key1");
        Console.WriteLine($"Get key1: {(found1 ? val1 : "Not found")}");

        Console.WriteLine("\nAdding key4 (capacity full)...");
        cache.Set("key4", "value4", ttlSeconds: 10);

        var (found2, val2) = cache.Get("key2");
        Console.WriteLine($"Get key2: {(found2 ? val2 : "Not found (evicted)")}");

        Console.WriteLine("\nWaiting 6 seconds for key1 to expire...");
        Thread.Sleep(6000);

        var (found1After, val1After) = cache.Get("key1");
        Console.WriteLine($"Get key1 after expiry: {(found1After ? val1After : "Not found (expired)")}");

        Console.WriteLine($"\nFinal cache size: {cache.Count}");
    }
}
