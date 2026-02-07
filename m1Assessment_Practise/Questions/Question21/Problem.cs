// Question 21: Bulk Email Sender with Throttling + Retry Queue
namespace m1Assessment_Practise.Questions.Question21;

class Problem
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("=== Question 21: Bulk Email Sender ===\n");

        var emails = Enumerable.Range(1, 25)
            .Select(i => new Email
            {
                To = $"user{i}@example.com",
                Subject = "Test Email",
                Body = "This is a test"
            })
            .ToList();

        var sender = new EmailSender(maxEmailsPerSecond: 10);
        var report = await sender.SendBulkAsync(emails);

        Console.WriteLine($"\n=== Bulk Send Report ===");
        Console.WriteLine($"Total: {report.TotalEmails}");
        Console.WriteLine($"Success: {report.SuccessCount}");
        Console.WriteLine($"Failed: {report.FailureCount}");
        
        if (report.FailedRecipients.Count > 0)
        {
            Console.WriteLine($"Failed recipients: {string.Join(", ", report.FailedRecipients)}");
        }
    }
}
