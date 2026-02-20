using System;

namespace BankingSystem
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Welcome to the Banking System!\n");

      Console.WriteLine("=== Savings Account Demo ===\n");
      
      SavingAccount savings = new SavingAccount("SA001", 5000m, 5.5);
      Console.WriteLine($"Created Savings Account: {savings.AccountNumber}");
      savings.DisplayBalance();
      
      Console.WriteLine("\nDepositing 2000...");
      savings.DepositAmount(2000m);
      
      Console.WriteLine("\nWithdrawing 1500...");
      savings.WithdrawAmount(1500m);
      
      Console.WriteLine("\nCalculating Interest (5.5%)...");
      savings.CalculateInterest();
      
      Console.WriteLine("\n\n=== Current Account Demo ===\n");
      
      CurrentAccount current = new CurrentAccount("CA001", 3000m, 1000m);
      Console.WriteLine($"Created Current Account: {current.AccountNumber}");
      Console.WriteLine($"Overdraft Limit: {current.OverdraftLimit:C}");
      current.DisplayBalance();
      
      Console.WriteLine("\nDepositing 1000...");
      current.DepositAmount(1000m);
      
      Console.WriteLine("\nWithdrawing 3500 (using overdraft)...");
      current.WithdrawAmount(3500m);
      
      Console.WriteLine("\nTrying to withdraw 2000 (exceeds limit)...");
      current.WithdrawAmount(2000m);
      
      Console.WriteLine("\nCalculating Interest...");
      current.CalculateInterest();
      
      Console.WriteLine("\n\n=== Testing Validation ===\n");
      
      Console.WriteLine("Attempting negative deposit:");
      savings.DepositAmount(-500m);
      
      Console.WriteLine("\nAttempting withdrawal exceeding balance:");
      savings.WithdrawAmount(10000m);
      
      Console.WriteLine("\n\nProgram completed successfully!");
    }
  }
}
