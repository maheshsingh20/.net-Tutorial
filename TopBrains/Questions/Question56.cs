using System;
using NUnit.Framework;

namespace TopBrains.Questions
{
    public class BankAccount
    {
        public decimal Balance { get; private set; }
        
        public BankAccount(decimal initialBalance)
        {
            Balance = initialBalance;
        }
        
        public void Deposit(decimal amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException("Deposit amount cannot be negative");
            }
            Balance += amount;
        }
        
        public void Withdraw(decimal amount)
        {
            if (amount > Balance)
            {
                throw new InvalidOperationException("Insufficient funds");
            }
            Balance -= amount;
        }
    }
    
    [TestFixture]
    public class UnitTest
    {
        [Test]
        public void Test_Deposit_ValidAmount()
        {
            BankAccount account = new BankAccount(100);
            account.Deposit(50);
            Assert.AreEqual(150, account.Balance);
        }
        
        [Test]
        public void Test_Deposit_NegativeAmount()
        {
            BankAccount account = new BankAccount(100);
            Assert.Throws<ArgumentException>(() => account.Deposit(-10));
        }
        
        [Test]
        public void Test_Withdraw_ValidAmount()
        {
            BankAccount account = new BankAccount(100);
            account.Withdraw(30);
            Assert.AreEqual(70, account.Balance);
        }
        
        [Test]
        public void Test_Withdraw_InsufficientFunds()
        {
            BankAccount account = new BankAccount(100);
            Assert.Throws<InvalidOperationException>(() => account.Withdraw(150));
        }
    }
    public class Question56
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("NUnit Test Cases for Bank Account");
            Console.WriteLine("Run tests using: dotnet test");       
            // Demo usage
            BankAccount account = new BankAccount(1000);
            Console.WriteLine($"Initial Balance: {account.Balance}");
            account.Deposit(500);
            Console.WriteLine($"After Deposit 500: {account.Balance}");
            account.Withdraw(200);
            Console.WriteLine($"After Withdraw 200: {account.Balance}");
        }
    }
}