using System;

namespace BankingSystem
{
  public class CurrentAccount : Account
  {
    public decimal OverdraftLimit { get; private set; }
    
    public CurrentAccount(string accountNumber, decimal balance, decimal overdraftLimit) 
      : base(accountNumber, balance)
    {
      OverdraftLimit = overdraftLimit;
    }

    public new void WithdrawAmount(decimal amountToWithdraw)
    {
      if (amountToWithdraw <= 0)
      {
        Console.WriteLine("Amount should be Positive only!");
      }
      else if (amountToWithdraw > (Balance + OverdraftLimit))
      {
        Console.WriteLine($"Withdrawal exceeds overdraft limit! Available: {Balance + OverdraftLimit:C}");
      }
      else
      {
        Balance -= amountToWithdraw;
        Console.WriteLine($"Amount {amountToWithdraw:C} withdrawn successfully! Remaining balance: {Balance:C}");
      }
    }

    public override void CalculateInterest()
    {
      Console.WriteLine("Current accounts do not earn interest.");
    }
  }
}
