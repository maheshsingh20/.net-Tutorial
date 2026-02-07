namespace m1Assessment_Practise.Questions.Question6;

class InsufficientFundsException : Exception
{
    public InsufficientFundsException(string message) : base(message) { }
}

class AccountNotFoundException : Exception
{
    public AccountNotFoundException(string message) : base(message) { }
}
