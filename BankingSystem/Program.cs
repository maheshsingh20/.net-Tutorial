using System;
using BankingSystem;

public class Program
{
  public static void Main(string[] args)
  {
    Console.WriteLine("Banking System Demo\n");
    SavingAccount account = new SavingAccount("SA001", 10000m, 5.5);
    Console.WriteLine($"Account Number: {account.accountNumber}");
    Console.WriteLine($"Initial Balance: ${account.Balance}");
    Console.WriteLine($"Interest Rate: {account.interestRate}%\n");
    account.depositAmount(2000);
    Console.WriteLine($"Balance after deposit: ${account.Balance}\n");
    account.WithDrawAmount(1500);
    Console.WriteLine($"Balance after withdrawal: ${account.Balance}\n");
    Console.WriteLine("Calculating interest...");
    account.CalculateInterest();
    Console.WriteLine($"Balance after interest: ${account.Balance}");
    
  }
}
