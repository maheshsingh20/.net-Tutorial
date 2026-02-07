namespace m1Assessment_Practise.Questions.Question16;

enum TransactionType { Credit, Debit }

class Transaction
{
    public string TenantId { get; set; } = "";
    public TransactionType Type { get; set; }
    public decimal Amount { get; set; }
    public DateTime Timestamp { get; set; }
}
