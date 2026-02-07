namespace m1Assessment_Practise.Questions.Question6;

class BankingSystem
{
    private readonly Dictionary<string, Account> _accounts = new();
    private readonly List<string> _auditLog = new();
    private readonly object _lock = new();

    public void AddAccount(Account account)
    {
        _accounts[account.AccountNo] = account;
    }

    public TransferResult Transfer(string fromAcc, string toAcc, decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Amount must be positive");

        if (fromAcc == toAcc)
            throw new ArgumentException("Cannot transfer to same account");

        lock (_lock)
        {
            if (!_accounts.ContainsKey(fromAcc))
                throw new AccountNotFoundException($"Account {fromAcc} not found");

            if (!_accounts.ContainsKey(toAcc))
                throw new AccountNotFoundException($"Account {toAcc} not found");

            var fromAccount = _accounts[fromAcc];
            var toAccount = _accounts[toAcc];

            if (fromAccount.Balance < amount)
                throw new InsufficientFundsException($"Insufficient funds in account {fromAcc}");

            decimal originalFromBalance = fromAccount.Balance;
            decimal originalToBalance = toAccount.Balance;

            try
            {
                fromAccount.Balance -= amount;
                toAccount.Balance += amount;

                string auditId = Guid.NewGuid().ToString().Substring(0, 8);
                string auditEntry = $"[{auditId}] SUCCESS: Transferred {amount:C} from {fromAcc} to {toAcc}";
                _auditLog.Add(auditEntry);

                return new TransferResult
                {
                    Success = true,
                    Message = "Transfer completed successfully",
                    AuditId = auditId
                };
            }
            catch (Exception ex)
            {
                fromAccount.Balance = originalFromBalance;
                toAccount.Balance = originalToBalance;

                string auditId = Guid.NewGuid().ToString().Substring(0, 8);
                string auditEntry = $"[{auditId}] FAILED: Transfer {amount:C} from {fromAcc} to {toAcc} - {ex.Message}";
                _auditLog.Add(auditEntry);

                return new TransferResult
                {
                    Success = false,
                    Message = $"Transfer failed: {ex.Message}",
                    AuditId = auditId
                };
            }
        }
    }

    public void DisplayAccounts()
    {
        Console.WriteLine("\n=== Account Balances ===");
        foreach (var acc in _accounts.Values)
        {
            Console.WriteLine($"{acc.AccountNo}: {acc.Balance:C}");
        }
    }

    public void DisplayAuditLog()
    {
        Console.WriteLine("\n=== Audit Log ===");
        foreach (var entry in _auditLog)
        {
            Console.WriteLine(entry);
        }
    }
}
