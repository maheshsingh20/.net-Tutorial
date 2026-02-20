using System;
using System.Collections.Generic;

namespace BankingSystem
{
  public class SavingAccount : Account
  {
    public double InterestRate { get; private set; }
    
    public SavingAccount(string accountNumber, decimal balance, double rate) : base(accountNumber, balance)
    {
      InterestRate = rate;
    }

    public override void CalculateInterest()
    {
      decimal interest = Balance * (decimal)InterestRate / 100;
      Balance += interest;
      Console.WriteLine($"Interest calculated: {interest:C}. New balance: {Balance:C}");
    }
  }
}
