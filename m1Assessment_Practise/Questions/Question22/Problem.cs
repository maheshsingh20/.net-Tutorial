// Question 22: Detect Fraud Pattern in Transactions
namespace m1Assessment_Practise.Questions.Question22;

class Problem
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Question 22: Fraud Detection ===\n");

        var baseTime = DateTime.Now;
        var transactions = new List<FraudTransaction>
        {
            new() { TransactionId = "T001", CardNumber = "1234", Amount = 60000, Timestamp = baseTime, City = "NYC" },
            new() { TransactionId = "T002", CardNumber = "1234", Amount = 55000, Timestamp = baseTime.AddMinutes(1), City = "NYC" },
            new() { TransactionId = "T003", CardNumber = "1234", Amount = 52000, Timestamp = baseTime.AddMinutes(1.5), City = "NYC" },
            new() { TransactionId = "T004", CardNumber = "5678", Amount = 1000, Timestamp = baseTime, City = "LA" },
            new() { TransactionId = "T005", CardNumber = "5678", Amount = 2000, Timestamp = baseTime.AddMinutes(5), City = "Chicago" }
        };

        var detector = new FraudDetector();
        var alerts = detector.DetectFraud(transactions);

        Console.WriteLine($"Detected {alerts.Count} fraud alerts:\n");
        foreach (var alert in alerts)
        {
            Console.WriteLine($"Card: {alert.CardNumber}");
            Console.WriteLine($"Rule: {alert.Rule}");
            Console.WriteLine($"Transactions: {string.Join(", ", alert.TransactionIds)}\n");
        }
    }
}
