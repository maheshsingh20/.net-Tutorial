using System;
using System.Collections.Generic;
using BankingSystem;
namespace BankingSystem
{
  public class SavingAccount : Account
  {
    public double interestRate { get; private set; }
    public SavingAccount(string accountNumber, decimal Balance, double rate) : base(accountNumber, Balance)
    {
      interestRate = rate;
    }

    public override void CalculateInterest()
    {
      double interest = (double)Balance * interestRate / 100;
      Balance += (decimal)interest;
    }
  }
}