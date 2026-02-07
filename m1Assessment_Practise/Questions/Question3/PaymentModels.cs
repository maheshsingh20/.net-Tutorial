namespace m1Assessment_Practise.Questions.Question3;

class PaymentRequest
{
    public string TransactionId { get; set; } = "";
    public decimal Amount { get; set; }
}

class PaymentResult
{
    public bool Success { get; set; }
    public string Message { get; set; } = "";
}

enum CircuitState { Closed, Open, HalfOpen }
