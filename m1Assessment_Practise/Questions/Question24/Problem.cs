// Question 24: Thread-Safe Singleton with Lazy Initialization
namespace m1Assessment_Practise.Questions.Question24;

class Problem
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Question 24: Thread-Safe Singleton ===\n");

        var tasks = new List<Task>();

        for (int i = 0; i < 5; i++)
        {
            int threadId = i;
            tasks.Add(Task.Run(() =>
            {
                var config = ConfigManager.Instance;
                Console.WriteLine($"Thread {threadId}: Instance HashCode = {config.GetHashCode()}");
                Console.WriteLine($"Thread {threadId}: AppName = {config.GetSetting("AppName")}");
            }));
        }

        Task.WaitAll(tasks.ToArray());

        Console.WriteLine("\nAll threads accessed the same instance (same HashCode)");
    }
}
