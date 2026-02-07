namespace m1Assessment_Practise.Questions.Question22;

class FraudTransaction
{
    public string TransactionId { get; set; } = "";
    public string CardNumber { get; set; } = "";
    public decimal Amount { get; set; }
    public DateTime Timestamp { get; set; }
    public string City { get; set; } = "";
}

class FraudAlert
{
    public string CardNumber { get; set; } = "";
    public string Rule { get; set; } = "";
    public List<string> TransactionIds { get; set; } = new();
}
