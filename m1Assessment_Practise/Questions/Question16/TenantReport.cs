namespace m1Assessment_Practise.Questions.Question16;

class TenantReport
{
    public string TenantId { get; set; } = "";
    public decimal TotalCredits { get; set; }
    public decimal TotalDebits { get; set; }
    public int PeakTransactionHour { get; set; }
    public bool IsSuspicious { get; set; }
    public string SuspiciousReason { get; set; } = "";
}
