// Question 11: Deadlock-Free Bank Account Locks (Ordered Locking)
namespace m1Assessment_Practise.Questions.Question11;

class Problem
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Question 11: Deadlock-Free Bank Transfers ===\n");

        var acc1 = new BankAccount { AccountId = "ACC001", Balance = 1000 };
        var acc2 = new BankAccount { AccountId = "ACC002", Balance = 1000 };
        var banking = new DeadlockFreeBanking();

        var task1 = Task.Run(() =>
        {
            for (int i = 0; i < 5; i++)
            {
                banking.SafeTransfer(acc1, acc2, 50);
                Thread.Sleep(50);
            }
        });

        var task2 = Task.Run(() =>
        {
            for (int i = 0; i < 5; i++)
            {
                banking.SafeTransfer(acc2, acc1, 30);
                Thread.Sleep(50);
            }
        });

        Task.WaitAll(task1, task2);

        Console.WriteLine($"\nFinal Balances:");
        Console.WriteLine($"{acc1.AccountId}: {acc1.Balance:C}");
        Console.WriteLine($"{acc2.AccountId}: {acc2.Balance:C}");
    }
}
