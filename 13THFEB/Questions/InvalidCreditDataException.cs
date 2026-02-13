using System;

namespace SmartBank
{
    public class InvalidCreditDataException : Exception
    {
        public InvalidCreditDataException(string message) : base(message)
        {
        }
    }
}
