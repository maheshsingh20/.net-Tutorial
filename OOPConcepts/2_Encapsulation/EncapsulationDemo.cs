using System;

namespace OOPConcepts.Encapsulation
{
    // ENCAPSULATION: Bundling data and methods together
    // Hiding internal details and providing controlled access
    // Achieved through access modifiers and properties
    
    public class BankAccount
    {
        // PRIVATE: Accessible only within this class
        private string accountNumber;
        private double balance;
        private string pin;
        
        // PUBLIC: Accessible from anywhere
        public string AccountHolder { get; set; }
        
        // PROTECTED: Accessible in this class and derived classes
        protected DateTime createdDate;
        
        // INTERNAL: Accessible within same assembly
        internal string BankName { get; set; }
        
        public BankAccount(string accountNumber, string accountHolder, string pin)
        {
            this.accountNumber = accountNumber;
            this.AccountHolder = accountHolder;
            this.pin = pin;
            this.balance = 0;
            this.createdDate = DateTime.Now;
            this.BankName = "MyBank";
        }
        
        // Public method to access private balance (controlled access)
        public double GetBalance(string enteredPin)
        {
            if (ValidatePin(enteredPin))
            {
                return balance;
            }
            Console.WriteLine("Invalid PIN!");
            return 0;
        }
        
        // Deposit method with validation
        public void Deposit(double amount)
        {
            if (amount > 0)
            {
                balance += amount;
                Console.WriteLine($"Deposited: ${amount}. New balance: ${balance}");
            }
            else
            {
                Console.WriteLine("Invalid deposit amount!");
            }
        }
        
        // Withdraw with validation and PIN check
        public bool Withdraw(double amount, string enteredPin)
        {
            if (!ValidatePin(enteredPin))
            {
                Console.WriteLine("Invalid PIN!");
                return false;
            }
            
            if (amount > 0 && amount <= balance)
            {
                balance -= amount;
                Console.WriteLine($"Withdrawn: ${amount}. Remaining: ${balance}");
                return true;
            }
            Console.WriteLine("Insufficient funds or invalid amount!");
            return false;
        }
        
        // Private helper method (internal implementation)
        private bool ValidatePin(string enteredPin)
        {
            return pin == enteredPin;
        }
        
        public void DisplayAccountInfo()
        {
            Console.WriteLine($"Account: {accountNumber}");
            Console.WriteLine($"Holder: {AccountHolder}");
            Console.WriteLine($"Bank: {BankName}");
        }
    }
    
    public class EncapsulationDemo
    {
        public static void Run()
        {
            Console.WriteLine("\n=== ENCAPSULATION ===");
            Console.WriteLine("Hiding internal data and providing controlled access");
            Console.WriteLine("Benefits: Data protection, flexibility, maintainability\n");
            
            BankAccount account = new BankAccount("ACC001", "John Doe", "1234");
            
            account.DisplayAccountInfo();
            
            // Cannot access private fields directly
            // account.balance = 1000000;  // ERROR!
            // account.pin = "0000";       // ERROR!
            
            // Must use public methods (controlled access)
            account.Deposit(1000);
            account.Deposit(500);
            
            account.Withdraw(200, "1234");
            account.Withdraw(100, "9999"); // Wrong PIN
            
            double balance = account.GetBalance("1234");
            Console.WriteLine($"Current Balance: ${balance}");
        }
    }
}
