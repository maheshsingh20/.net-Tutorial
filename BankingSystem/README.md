# Banking System - OOP Demonstration

A comprehensive C# banking system demonstrating Object-Oriented Programming principles including abstraction, inheritance, polymorphism, and encapsulation.

## 📋 Project Overview

This project implements a simple banking system with multiple account types, showcasing how abstract classes and inheritance work in real-world scenarios.

## 🏗️ Architecture

### Class Hierarchy

```
Account (Abstract Base Class)
    ├── SavingAccount (Concrete Implementation)
    └── CurrentAccount (Concrete Implementation)
```

## 📁 Project Structure

```
BankingSystem/
├── Questions/
│   ├── Account.cs           # Abstract base class
│   ├── SavingAccount.cs     # Savings account with interest
│   └── CurrentAccount.cs    # Current account with overdraft
├── Program.cs               # Demo application
├── BankingSystem.csproj     # Project file
└── README.md               # This file
```

## 🎯 Key Features

### 1. Abstract Base Class (Account)
- Defines common properties and methods for all account types
- Enforces implementation of `CalculateInterest()` in derived classes
- Provides shared functionality for deposits and withdrawals

### 2. Savings Account
- Earns interest based on balance
- Interest rate configurable per account
- Inherits all base account functionality

### 3. Current Account
- Supports overdraft facility
- No interest earned
- Custom withdrawal logic with overdraft limit

## 🔑 OOP Concepts Demonstrated

### Abstraction
```csharp
public abstract class Account
{
    public abstract void CalculateInterest();
}
```
- Forces derived classes to implement interest calculation
- Prevents direct instantiation of Account class

### Inheritance
```csharp
public class SavingAccount : Account
{
    // Inherits all properties and methods from Account
}
```
- Code reusability
- Shared functionality in base class
- Specialized behavior in derived classes

### Polymorphism
```csharp
Account savings = new SavingAccount("SA001", 5000m, 5.5);
Account current = new CurrentAccount("CA001", 3000m, 1000m);

savings.CalculateInterest();  // Calls SavingAccount implementation
current.CalculateInterest();  // Calls CurrentAccount implementation
```
- Same method name, different implementations
- Runtime polymorphism through method overriding

### Encapsulation
```csharp
public decimal Balance { get; protected set; }
```
- Balance can be read publicly but modified only within the class hierarchy
- Data protection and controlled access

## 📊 Class Details

### Account (Abstract Base Class)

**Properties:**
- `AccountNumber` (string) - Unique account identifier
- `Balance` (decimal) - Current account balance (protected set)

**Methods:**
- `DepositAmount(decimal)` - Add money to account
- `WithdrawAmount(decimal)` - Remove money from account
- `DisplayBalance()` - Show current balance
- `CalculateInterest()` - Abstract method for interest calculation

**Validation:**
- Deposits must be positive
- Withdrawals cannot exceed balance
- All amounts validated before processing

---

### SavingAccount : Account

**Additional Properties:**
- `InterestRate` (double) - Annual interest rate percentage

**Constructor:**
```csharp
SavingAccount(string accountNumber, decimal balance, double rate)
```

**Interest Calculation:**
```
Interest = Balance × InterestRate / 100
New Balance = Balance + Interest
```

**Example:**
```csharp
SavingAccount savings = new SavingAccount("SA001", 5000m, 5.5);
savings.CalculateInterest();
// Interest: ₹275.00, New Balance: ₹5,275.00
```

---

### CurrentAccount : Account

**Additional Properties:**
- `OverdraftLimit` (decimal) - Maximum negative balance allowed

**Constructor:**
```csharp
CurrentAccount(string accountNumber, decimal balance, decimal overdraftLimit)
```

**Overdraft Feature:**
- Can withdraw beyond available balance
- Limited by overdraft amount
- No interest earned

**Example:**
```csharp
CurrentAccount current = new CurrentAccount("CA001", 3000m, 1000m);
current.WithdrawAmount(3500m);  // Allowed (uses ₹500 overdraft)
current.WithdrawAmount(2000m);  // Denied (exceeds limit)
```

## 🚀 Running the Project

### Build
```bash
cd BankingSystem
dotnet build
```

### Run
```bash
dotnet run
```

### Expected Output
```
Welcome to the Banking System!

=== Savings Account Demo ===

Created Savings Account: SA001
Account: SA001, Balance: ₹5,000.00

Depositing 2000...
Amount ₹2,000.00 deposited successfully! New balance: ₹7,000.00

Withdrawing 1500...
Amount ₹1,500.00 withdrawn successfully! Remaining balance: ₹5,500.00

Calculating Interest (5.5%)...
Interest calculated: ₹302.50. New balance: ₹5,802.50


=== Current Account Demo ===

Created Current Account: CA001
Overdraft Limit: ₹1,000.00
Account: CA001, Balance: ₹3,000.00

Depositing 1000...
Amount ₹1,000.00 deposited successfully! New balance: ₹4,000.00

Withdrawing 3500 (using overdraft)...
Amount ₹3,500.00 withdrawn successfully! Remaining balance: ₹500.00

Trying to withdraw 2000 (exceeds limit)...
Withdrawal exceeds overdraft limit! Available: ₹1,500.00

Calculating Interest...
Current accounts do not earn interest.


=== Testing Validation ===

Attempting negative deposit:
Enter Positive Amount Only

Attempting withdrawal exceeding balance:
Insufficient balance in your account!


Program completed successfully!
```

## 🧪 Test Scenarios

### Scenario 1: Savings Account Operations
1. Create account with ₹5,000
2. Deposit ₹2,000 → Balance: ₹7,000
3. Withdraw ₹1,500 → Balance: ₹5,500
4. Calculate interest (5.5%) → Interest: ₹302.50, Balance: ₹5,802.50

### Scenario 2: Current Account with Overdraft
1. Create account with ₹3,000 and ₹1,000 overdraft
2. Deposit ₹1,000 → Balance: ₹4,000
3. Withdraw ₹3,500 → Balance: ₹500 (uses ₹500 overdraft)
4. Try withdraw ₹2,000 → Denied (exceeds ₹1,500 available)

### Scenario 3: Validation Testing
1. Negative deposit → Rejected
2. Withdrawal exceeding balance → Rejected
3. Zero amount operations → Rejected

## 💡 Key Learning Points

### 1. Abstract Classes
- Cannot be instantiated directly
- Can contain both abstract and concrete methods
- Used when classes share common functionality but need specific implementations

### 2. Method Overriding
- `override` keyword used in derived classes
- Provides specific implementation for abstract methods
- Enables runtime polymorphism

### 3. Access Modifiers
- `public` - Accessible everywhere
- `protected` - Accessible in class and derived classes
- `private` - Accessible only within the class

### 4. Property Accessors
```csharp
public decimal Balance { get; protected set; }
```
- Public getter: Anyone can read
- Protected setter: Only class and derived classes can modify

## 🔧 Extending the System

### Add New Account Type
```csharp
public class FixedDepositAccount : Account
{
    public int TenureMonths { get; private set; }
    public double InterestRate { get; private set; }
    
    public FixedDepositAccount(string accountNumber, decimal balance, 
                               int tenure, double rate) 
        : base(accountNumber, balance)
    {
        TenureMonths = tenure;
        InterestRate = rate;
    }
    
    public override void CalculateInterest()
    {
        // Compound interest calculation
        decimal interest = Balance * (decimal)Math.Pow(
            (1 + InterestRate / 100), TenureMonths / 12.0) - Balance;
        Balance += interest;
        Console.WriteLine($"FD matured! Interest: {interest:C}, New balance: {Balance:C}");
    }
}
```

### Add Transaction History
```csharp
public class Transaction
{
    public DateTime Date { get; set; }
    public string Type { get; set; }
    public decimal Amount { get; set; }
    public decimal BalanceAfter { get; set; }
}

// In Account class:
protected List<Transaction> Transactions = new List<Transaction>();

public void ShowTransactionHistory()
{
    foreach (var txn in Transactions)
    {
        Console.WriteLine($"{txn.Date:yyyy-MM-dd} | {txn.Type} | {txn.Amount:C} | Balance: {txn.BalanceAfter:C}");
    }
}
```

## 📚 Related Concepts

- **Interfaces** - Alternative to abstract classes for contracts
- **Sealed Classes** - Prevent inheritance
- **Virtual Methods** - Allow optional overriding
- **Static Members** - Shared across all instances

## 🎓 Best Practices Demonstrated

1. **Naming Conventions**
   - PascalCase for classes, methods, properties
   - Descriptive names (DepositAmount, not DA)

2. **Validation**
   - Check inputs before processing
   - Provide clear error messages

3. **Encapsulation**
   - Protected setters for sensitive data
   - Public getters for transparency

4. **Code Reusability**
   - Common logic in base class
   - Specialized logic in derived classes

5. **Single Responsibility**
   - Each class has one clear purpose
   - Methods do one thing well

## 🐛 Common Errors Fixed

1. **Inconsistent Accessibility**
   - Base class must be at least as accessible as derived class
   - Fixed: Made Account `public abstract`

2. **Type Mismatches**
   - Constructor parameter types must match base class
   - Fixed: Changed `int` to `string` for account number

3. **Static vs Instance**
   - Cannot access instance members as static
   - Fixed: Changed `Account.Balance` to `Balance`

4. **Property Accessor Restrictions**
   - Setter cannot be less restrictive than property
   - Fixed: Made property public with private setter

## 📄 License

This project is for educational purposes.

## 👤 Author

Created as part of C# OOP learning journey.

---

**Last Updated**: February 19, 2026  
**.NET Version**: 10.0  
**C# Version**: 10.0
