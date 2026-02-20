using System;

namespace BankingSystem
{
  public abstract class Account
  {
    public string AccountNumber { get; set; }
    public decimal Balance { get; protected set; }

    public Account(string accountNumber, decimal initialBalance)
    {
      this.AccountNumber = accountNumber;
      this.Balance = initialBalance;
    }

    public void DepositAmount(decimal amountToDeposit)
    {
      if (amountToDeposit <= 0)
      {
        Console.WriteLine("Enter Positive Amount Only");
      }
      else
      {
        Balance += amountToDeposit;
        Console.WriteLine($"Amount {amountToDeposit:C} deposited successfully! New balance: {Balance:C}");
      }
    }

    public void WithdrawAmount(decimal amountToWithdraw)
    {
      if (amountToWithdraw <= 0)
      {
        Console.WriteLine("Amount should be Positive only!");
      }
      else if (amountToWithdraw > Balance)
      {
        Console.WriteLine("Insufficient balance in your account!");
      }
      else
      {
        Balance -= amountToWithdraw;
        Console.WriteLine($"Amount {amountToWithdraw:C} withdrawn successfully! Remaining balance: {Balance:C}");
      }
    }

    public void DisplayBalance()
    {
      Console.WriteLine($"Account: {AccountNumber}, Balance: {Balance:C}");
    }

    public abstract void CalculateInterest();
  }
}
