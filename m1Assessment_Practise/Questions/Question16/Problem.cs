// Question 16: Multi-Tenant Report Generator
namespace m1Assessment_Practise.Questions.Question16;

class Problem
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Question 16: Multi-Tenant Report Generator ===\n");

        var transactions = GenerateSampleTransactions();
        var generator = new ReportGenerator();
        var reports = generator.GenerateReports(transactions);

        foreach (var report in reports)
        {
            Console.WriteLine($"\n=== Tenant: {report.TenantId} ===");
            Console.WriteLine($"Total Credits: {report.TotalCredits:C}");
            Console.WriteLine($"Total Debits: {report.TotalDebits:C}");
            Console.WriteLine($"Peak Hour: {report.PeakTransactionHour}:00");
            Console.WriteLine($"Suspicious: {(report.IsSuspicious ? $"YES - {report.SuspiciousReason}" : "NO")}");
        }
    }

    static List<Transaction> GenerateSampleTransactions()
    {
        var baseTime = DateTime.Now;
        return new List<Transaction>
        {
            new() { TenantId = "T001", Type = TransactionType.Credit, Amount = 1000, Timestamp = baseTime },
            new() { TenantId = "T001", Type = TransactionType.Debit, Amount = 200, Timestamp = baseTime.AddMinutes(1) },
            new() { TenantId = "T001", Type = TransactionType.Debit, Amount = 150, Timestamp = baseTime.AddMinutes(2) },
            new() { TenantId = "T001", Type = TransactionType.Debit, Amount = 100, Timestamp = baseTime.AddMinutes(3) },
            new() { TenantId = "T001", Type = TransactionType.Debit, Amount = 50, Timestamp = baseTime.AddMinutes(4) },
            new() { TenantId = "T002", Type = TransactionType.Credit, Amount = 5000, Timestamp = baseTime },
            new() { TenantId = "T002", Type = TransactionType.Debit, Amount = 500, Timestamp = baseTime.AddHours(1) }
        };
    }
}
