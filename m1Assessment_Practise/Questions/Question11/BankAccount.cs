namespace m1Assessment_Practise.Questions.Question11;

class BankAccount
{
    public string AccountId { get; set; } = "";
    public decimal Balance { get; set; }
    private readonly object _lock = new();

    public object Lock => _lock;
}
