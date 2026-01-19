using System;

namespace OOPConcepts.AccessModifiers
{
    // ACCESS MODIFIERS: Control visibility and accessibility
    // public: Accessible everywhere
    // private: Only within the class
    // protected: Within class and derived classes
    // internal: Within same assembly
    // protected internal: Within assembly or derived classes
    
    public class BankAccount
    {
        // PRIVATE: Only accessible within this class
        private string accountNumber;
        private string pin;
        
        // PUBLIC: Accessible from anywhere
        public string AccountHolder { get; set; }
        
        // PROTECTED: Accessible in this class and derived classes
        protected double balance;
        
        // INTERNAL: Accessible within same assembly/project
        internal string BranchCode { get; set; }
        
        // PROTECTED INTERNAL: Accessible within assembly OR derived classes
        protected internal DateTime OpenedDate { get; set; }
        
        public BankAccount(string accNum, string holder, string pin)
        {
            accountNumber = accNum;
            AccountHolder = holder;
            this.pin = pin;
            balance = 0;
            BranchCode = "BR001";
            OpenedDate = DateTime.Now;
        }
        
        // Public method accessing private members
        public void Deposit(double amount)
        {
            if (amount > 0)
            {
                balance += amount;
                Console.WriteLine($"Deposited ${amount}. Balance: ${balance}");
            }
        }
        
        // Protected method: Can be used by derived classes
        protected bool ValidatePin(string enteredPin)
        {
            return pin == enteredPin;
        }
        
        // Private method: Only for internal use
        private void LogTransaction(string type, double amount)
        {
            Console.WriteLine($"[LOG] {type}: ${amount} at {DateTime.Now}");
        }
        
        public void Withdraw(double amount, string enteredPin)
        {
            if (ValidatePin(enteredPin) && amount <= balance)
            {
                balance -= amount;
                LogTransaction("Withdrawal", amount);
                Console.WriteLine($"Withdrawn ${amount}. Balance: ${balance}");
            }
        }
    }
    
    // Derived class demonstrating protected access
    public class SavingsAccount : BankAccount
    {
        public double InterestRate { get; set; }
        
        public SavingsAccount(string accNum, string holder, string pin, double rate) 
            : base(accNum, holder, pin)
        {
            InterestRate = rate;
        }
        
        public void AddInterest()
        {
            // Can access protected member 'balance'
            double interest = balance * InterestRate / 100;
            balance += interest;
            Console.WriteLine($"Interest added: ${interest:F2}. New balance: ${balance:F2}");
        }
        
        public void DisplayBalance(string pin)
        {
            // Can access protected method 'ValidatePin'
            if (ValidatePin(pin))
            {
                Console.WriteLine($"Current Balance: ${balance:F2}");
            }
            else
            {
                Console.WriteLine("Invalid PIN!");
            }
        }
    }
    
    public class AccessModifiersDemo
    {
        public static void Run()
        {
            Console.WriteLine("\n=== ACCESS MODIFIERS ===");
            Console.WriteLine("Control visibility and accessibility of members\n");
            
            BankAccount account = new BankAccount("ACC001", "John", "1234");
            
            // PUBLIC: Accessible
            Console.WriteLine($"Account Holder: {account.AccountHolder}");
            
            // INTERNAL: Accessible within same assembly
            Console.WriteLine($"Branch: {account.BranchCode}");
            
            // PRIVATE: Not accessible
            // Console.WriteLine(account.accountNumber); // ERROR!
            // Console.WriteLine(account.pin);            // ERROR!
            
            account.Deposit(1000);
            account.Withdraw(200, "1234");
            
            Console.WriteLine("\n--- Savings Account (Derived Class) ---");
            SavingsAccount savings = new SavingsAccount("SAV001", "Alice", "5678", 5.0);
            savings.Deposit(5000);
            savings.AddInterest();  // Uses protected 'balance'
            savings.DisplayBalance("5678");  // Uses protected 'ValidatePin'
        }
    }
}
