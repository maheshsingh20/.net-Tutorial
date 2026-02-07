// Question 2: Rate Limiter (Sliding Window)
namespace m1Assessment_Practise.Questions.Question2;

class Problem
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Question 2: Rate Limiter (Sliding Window) ===\n");

        var rateLimiter = new RateLimiter(maxRequests: 5, timeWindow: TimeSpan.FromSeconds(10));
        var startTime = DateTime.Now;

        for (int i = 1; i <= 8; i++)
        {
            var now = startTime.AddSeconds(i * 0.5);
            bool allowed = rateLimiter.AllowRequest("Client1", now);
            Console.WriteLine($"Request {i} at {(now - startTime).TotalSeconds:F1}s: {(allowed ? "ALLOWED" : "BLOCKED")}");
        }

        Console.WriteLine("\n--- After 10 seconds ---");
        var laterTime = startTime.AddSeconds(11);
        bool allowedLater = rateLimiter.AllowRequest("Client1", laterTime);
        Console.WriteLine($"Request at 11s: {(allowedLater ? "ALLOWED" : "BLOCKED")}");
    }
}
