namespace m1Assessment_Practise.Questions.Question11;

class DeadlockFreeBanking
{
    public void SafeTransfer(BankAccount from, BankAccount to, decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Amount must be positive");

        if (from.AccountId == to.AccountId)
            throw new ArgumentException("Cannot transfer to same account");

        var (first, second) = string.Compare(from.AccountId, to.AccountId, StringComparison.Ordinal) < 0
            ? (from, to)
            : (to, from);

        lock (first.Lock)
        {
            lock (second.Lock)
            {
                if (from.Balance < amount)
                    throw new InvalidOperationException("Insufficient funds");

                from.Balance -= amount;
                Thread.Sleep(10);
                to.Balance += amount;

                Console.WriteLine($"Transferred {amount:C} from {from.AccountId} to {to.AccountId}");
            }
        }
    }
}
