namespace m1Assessment_Practise.Questions.Question25;

class InsufficientStockException : Exception
{
    public InsufficientStockException(string message) : base(message) { }
}

class InvalidCouponException : Exception
{
    public InvalidCouponException(string message) : base(message) { }
}
