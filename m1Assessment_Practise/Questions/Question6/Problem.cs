// Question 6: Transactional Money Transfer (Atomic + Rollback)
namespace m1Assessment_Practise.Questions.Question6;

class Problem
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Question 6: Transactional Money Transfer ===\n");

        var bank = new BankingSystem();
        bank.AddAccount(new Account { AccountNo = "ACC001", Balance = 1000 });
        bank.AddAccount(new Account { AccountNo = "ACC002", Balance = 500 });

        Console.WriteLine("Initial State:");
        bank.DisplayAccounts();

        var result1 = bank.Transfer("ACC001", "ACC002", 200);
        Console.WriteLine($"\nTransfer 1: {result1.Message}");

        try
        {
            var result2 = bank.Transfer("ACC002", "ACC001", 1000);
        }
        catch (InsufficientFundsException ex)
        {
            Console.WriteLine($"\nTransfer 2 Failed: {ex.Message}");
        }

        bank.DisplayAccounts();
        bank.DisplayAuditLog();
    }
}
