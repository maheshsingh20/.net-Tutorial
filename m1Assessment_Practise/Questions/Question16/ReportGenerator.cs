namespace m1Assessment_Practise.Questions.Question16;

class ReportGenerator
{
    public List<TenantReport> GenerateReports(List<Transaction> transactions)
    {
        return transactions
            .GroupBy(t => t.TenantId)
            .Select(tenantGroup => GenerateTenantReport(tenantGroup.Key, tenantGroup.ToList()))
            .ToList();
    }

    private TenantReport GenerateTenantReport(string tenantId, List<Transaction> transactions)
    {
        var report = new TenantReport { TenantId = tenantId };

        report.TotalCredits = transactions
            .Where(t => t.Type == TransactionType.Credit)
            .Sum(t => t.Amount);

        report.TotalDebits = transactions
            .Where(t => t.Type == TransactionType.Debit)
            .Sum(t => t.Amount);

        var hourGroups = transactions
            .GroupBy(t => t.Timestamp.Hour)
            .OrderByDescending(g => g.Count())
            .FirstOrDefault();

        report.PeakTransactionHour = hourGroups?.Key ?? 0;

        var debits = transactions
            .Where(t => t.Type == TransactionType.Debit)
            .OrderBy(t => t.Timestamp)
            .ToList();

        for (int i = 0; i < debits.Count; i++)
        {
            var windowDebits = debits
                .Skip(i)
                .TakeWhile(t => (t.Timestamp - debits[i].Timestamp).TotalMinutes <= 5)
                .Count();

            if (windowDebits > 3)
            {
                report.IsSuspicious = true;
                report.SuspiciousReason = $"More than 3 debits within 5 minutes detected";
                break;
            }
        }

        return report;
    }
}
