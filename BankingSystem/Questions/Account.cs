using System;
using System.Collections.Generic;
namespace BankingSystem
{
  public abstract class Account
  {
    public string accountNumber { get; set; }
    public decimal Balance { get; protected set; }

    public Account(string accountNumber, decimal initialBalance)
    {
      this.accountNumber = accountNumber;
      this.Balance = initialBalance;
    }

    /* Amount deposit method */
    public void depositAmount(int amountToDeposit)
    {
      if (amountToDeposit < 0)
      {
        Console.WriteLine("Enter Positive Amount Only");
      }
      else
      {
        Balance += amountToDeposit;
        Console.WriteLine("Amount is deposited correctly!!");
      }
    }
    /*Withdraw Amount Method*/
    public void WithDrawAmount(int amountToWithDraw)
    {
      if (amountToWithDraw < 0)
      {
        Console.WriteLine("Amount should be Positive only!!");
      }
      else if (amountToWithDraw > Balance)
      {
        Console.WriteLine("Amount is not Enough in your account!!");
      }
      else
      {
        Balance -= amountToWithDraw;
      }
    }
    public abstract void CalculateInterest();

  }
}