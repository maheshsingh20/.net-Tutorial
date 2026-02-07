// Question 5: Large File Log Analyzer (Streaming + Memory Safe)
namespace m1Assessment_Practise.Questions.Question5;

class Problem
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Question 5: Large File Log Analyzer ===\n");

        string logPath = "sample_log.txt";
        CreateSampleLogFile(logPath);

        var analyzer = new LogAnalyzer();
        var topErrors = analyzer.GetTopErrors(logPath, topN: 5);

        Console.WriteLine("Top 5 Errors:");
        foreach (var error in topErrors)
        {
            Console.WriteLine($"{error.ErrorCode}: {error.Count} occurrences");
        }

        File.Delete(logPath);
    }

    static void CreateSampleLogFile(string path)
    {
        var random = new Random();
        var errorCodes = new[] { "ERR123", "ERR456", "ERR789", "ERR101", "ERR202" };

        using (var writer = new StreamWriter(path))
        {
            for (int i = 0; i < 1000; i++)
            {
                string errorCode = errorCodes[random.Next(errorCodes.Length)];
                writer.WriteLine($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {errorCode} - Error occurred");
            }
        }
        Console.WriteLine($"Sample log file created\n");
    }
}
