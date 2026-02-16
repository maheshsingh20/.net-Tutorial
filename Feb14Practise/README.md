# SortedDictionary Practice - 10 Real-World Problems

## Overview

This project contains 10 comprehensive real-world problems demonstrating the use of `SortedDictionary<TKey, TValue>` in C#. Each problem showcases OOP principles, custom exceptions, polymorphism, and practical applications of sorted collections.

## Project Structure

```
Feb14Practise/
├── Questions/
│   ├── Problem1/  - Smart Warehouse Inventory
│   ├── Problem2/  - Hospital Emergency Queue
│   ├── Problem3/  - Banking Transaction Risk
│   ├── Problem4/  - Airline Booking System
│   ├── Problem5/  - Course Registration
│   ├── Problem6/  - Flash Sale Bidding
│   ├── Problem7/  - Library Fines
│   ├── Problem8/  - Traffic Violations
│   ├── Problem9/  - IT Support Tickets
│   └── Problem10/ - Investment Portfolio
├── Program.cs     - Main menu
└── README.md      - This file
```

## Why SortedDictionary?

**SortedDictionary<TKey, TValue>** automatically maintains elements sorted by key:
- Keys are always in sorted order
- O(log n) for insert, delete, search
- Perfect for priority-based systems
- Supports custom comparers for descending order

## Problems Overview

### Problem 1: Smart Warehouse Inventory Prioritization System

**Scenario**: Warehouse products sorted by priority (1=Critical, 10=Low)

**Data Structure**: `SortedDictionary<int, List<Product>>`

**Key Concepts**:
- Abstract Product class
- Derived classes: Electronics, Perishable, FragileItem
- Custom exceptions: LowStockException, DuplicateSKUException

**Features**:
- Add/remove products
- Update stock with automatic alerts
- Get highest priority products
- Stock threshold monitoring

**Example**:
```csharp
warehouse.AddProduct(1, new Electronics("E001", "Laptop", 50, 10, 24));
warehouse.AddProduct(5, new Perishable("P001", "Milk", 200, 50, DateTime.Now.AddDays(7)));
var highPriority = warehouse.GetHighestPriorityProducts(); // Priority 1 items
```

**Learning Focus**: Priority management, stock validation, inheritance

---

### Problem 2: Hospital Emergency Queue Management System

**Scenario**: Patients treated based on severity (1=Critical)

**Data Structure**: `SortedDictionary<int, Queue<Patient>>`

**Key Concepts**:
- Abstract Person class
- Patient inheritance
- Polymorphic Treat() method
- FIFO within same severity

**Features**:
- Add patient to severity queue
- Get next patient (highest severity first)
- Remove patient
- Queue overflow protection

**Example**:
```csharp
manager.AddPatient(new Patient("P001", "John", 45, 1, "Heart Attack"));
manager.AddPatient(new Patient("P002", "Sarah", 30, 3, "Broken Arm"));
var nextPatient = manager.GetNextPatient(); // John (severity 1)
```

**Learning Focus**: Queue + Priority, FIFO ordering, emergency triage

---

### Problem 3: Banking Transaction Risk Monitoring System

**Scenario**: Transactions sorted by risk score (descending)

**Data Structure**: `SortedDictionary<int, List<Transaction>>` with custom comparer

**Key Concepts**:
- Abstract Transaction class
- OnlineTransaction, WireTransfer
- Strategy pattern for risk calculation
- Descending order sorting

**Features**:
- Add transaction with risk scoring
- Fraud detection (risk > 80)
- Transaction limit enforcement
- High-risk transaction filtering

**Example**:
```csharp
var comparer = Comparer<int>.Create((a, b) => b.CompareTo(a)); // Descending
var transactions = new SortedDictionary<int, List<Transaction>>(comparer);
monitor.AddTransaction(new OnlineTransaction("T001", 5000, "ACC001", "192.168.1.1", "DEV001"));
```

**Learning Focus**: Risk scoring, custom comparers, fraud detection

---

### Problem 4: Airline Booking Fare Classification System

**Scenario**: Tickets sorted by price category

**Data Structure**: `SortedDictionary<decimal, List<Ticket>>`

**Key Concepts**:
- Abstract Ticket class
- Economy, Business, FirstClass
- Polymorphic CalculateFare()
- Seat availability tracking

**Features**:
- Add ticket with fare calculation
- Prevent duplicate seat booking
- Display bookings by fare
- Seat availability check

**Example**:
```csharp
system.AddTicket(new Economy("T001", "John", "12A", 5000));
system.AddTicket(new Business("T002", "Sarah", "3B", 5000)); // Fare: 12500
system.AddTicket(new FirstClass("T003", "Mike", "1A", 5000)); // Fare: 20000
```

**Learning Focus**: Fare calculation, seat management, polymorphism

---

### Problem 5: University Course Registration Priority System

**Scenario**: Students registered by GPA (descending)

**Data Structure**: `SortedDictionary<double, List<Student>>` with custom comparer

**Key Concepts**:
- Abstract Person class
- Student inheritance
- GPA-based priority
- Seat allocation

**Features**:
- Register student with GPA validation
- Allocate seats by priority
- Course capacity management
- Duplicate enrollment prevention

**Example**:
```csharp
course.RegisterStudent(new Student("S001", "Alice", 20, 9.2, "CS"));
course.RegisterStudent(new Student("S002", "Bob", 21, 8.5, "ECE"));
course.AllocateSeats(); // Alice gets Seat 1 (higher GPA)
```

**Learning Focus**: GPA priority, seat allocation, capacity management

---

### Problem 6: E-Commerce Flash Sale Bidding Engine

**Scenario**: Bids sorted by highest bid first

**Data Structure**: `SortedDictionary<decimal, List<Bid>>` with custom comparer

**Key Concepts**:
- Abstract User class
- Buyer, Seller
- Polymorphic bid validation
- Auction lifecycle

**Features**:
- Add bid with wallet validation
- Determine winner (highest bid)
- Close auction
- Bid too low detection

**Example**:
```csharp
auction.AddBid(new Bid("BID001", buyer1, 15000, "PROD001"));
auction.AddBid(new Bid("BID002", buyer2, 18000, "PROD001"));
auction.CloseAuction();
var winner = auction.DetermineWinner(); // buyer2 with 18000
```

**Learning Focus**: Auction logic, wallet validation, winner determination

---

### Problem 7: Library Fine Calculation & Penalty System

**Scenario**: Members sorted by outstanding fine

**Data Structure**: `SortedDictionary<decimal, LibraryUser>`

**Key Concepts**:
- Abstract LibraryUser class
- StudentMember, FacultyMember
- Override CalculateFine()
- Payment processing

**Features**:
- Add fine based on days overdue
- Pay fine with validation
- Different rates for member types
- Outstanding fine tracking

**Example**:
```csharp
manager.AddFine(student, 10); // 10 days * ₹5 = ₹50
manager.AddFine(faculty, 10); // 10 days * ₹3 = ₹30
manager.PayFine("M001", 30);
```

**Learning Focus**: Fine calculation, member types, payment processing

---

### Problem 8: Smart Traffic Violation Monitoring System

**Scenario**: Violations sorted by penalty amount (descending)

**Data Structure**: `SortedDictionary<decimal, List<Violation>>` with custom comparer

**Key Concepts**:
- Abstract Vehicle class
- Car, Truck, Bike
- Violation encapsulation
- Repeat offender tracking

**Features**:
- Add violation with penalty
- Escalate repeat offenders
- Penalty limit enforcement
- Vehicle type tracking

**Example**:
```csharp
monitor.AddViolation(new Violation("V001", car, "Speeding", 2000));
monitor.AddViolation(new Violation("V002", car, "Red Light", 1000));
monitor.EscalateRepeatOffenders(); // car has 2 violations
```

**Learning Focus**: Penalty tracking, repeat offenders, vehicle types

---

### Problem 9: IT Support Ticket Severity System

**Scenario**: Tickets sorted by severity level

**Data Structure**: `SortedDictionary<int, Queue<SupportTicket>>`

**Key Concepts**:
- Abstract User class
- Employee, Admin
- Override ResolveTicket()
- Ticket escalation

**Features**:
- Add ticket to severity queue
- Process ticket (FIFO within severity)
- Escalate ticket to higher severity
- Ticket resolution tracking

**Example**:
```csharp
system.AddTicket(new SupportTicket("T001", "Server Down", "Critical", 1, emp));
system.AddTicket(new SupportTicket("T002", "Printer Issue", "Low", 4, emp));
var ticket = system.ProcessTicket(); // T001 (severity 1)
system.EscalateTicket("T002"); // Move to severity 3
```

**Learning Focus**: Severity queues, escalation, FIFO processing

---

### Problem 10: Investment Portfolio Risk Categorization System

**Scenario**: Investments sorted by risk rating (1-5)

**Data Structure**: `SortedDictionary<int, List<Asset>>`

**Key Concepts**:
- Abstract Asset class
- Stocks, Bonds, MutualFunds
- Polymorphic CalculateReturn()
- Portfolio risk analysis

**Features**:
- Add investment with risk validation
- Recalculate portfolio risk
- Investment limit enforcement
- Expected return calculation

**Example**:
```csharp
manager.AddInvestment(new Stocks("S001", "Tech Corp", 500000, 4, "TechCorp", 1500));
manager.AddInvestment(new Bonds("B001", "Govt Bond", 300000, 1, 6.5m));
manager.RecalculatePortfolioRisk(); // Weighted average: 2.86
```

**Learning Focus**: Risk analysis, portfolio management, return calculation

---

## Common Patterns Across All Problems

### 1. Abstract Base Classes
Every problem uses abstraction:
```csharp
public abstract class Product
{
    public abstract string GetProductType();
}
```

### 2. Custom Exceptions
Each problem has specific exceptions:
```csharp
public class LowStockException : InventoryException
{
    public LowStockException(string message) : base(message) { }
}
```

### 3. Polymorphism
Different implementations for different types:
```csharp
public override decimal CalculateFare()
{
    return BaseFare * 2.5m; // Business class
}
```

### 4. SortedDictionary Usage
Automatic sorting by key:
```csharp
var dict = new SortedDictionary<int, List<Item>>();
dict[5] = new List<Item>();
dict[1] = new List<Item>();
// Automatically ordered: 1, 5
```

### 5. Custom Comparers
For descending order:
```csharp
var dict = new SortedDictionary<int, List<Item>>(
    Comparer<int>.Create((a, b) => b.CompareTo(a))
);
```

## How to Run

```bash
cd Feb14Practise
dotnet build
dotnet run
```

### Menu Options

```
Select a problem to run (1-10) or 0 to exit:
1. Smart Warehouse Inventory Prioritization
2. Hospital Emergency Queue Management
3. Banking Transaction Risk Monitoring
4. Airline Booking Fare Classification
5. University Course Registration Priority
6. E-Commerce Flash Sale Bidding Engine
7. Library Fine Calculation & Penalty
8. Smart Traffic Violation Monitoring
9. IT Support Ticket Severity System
10. Investment Portfolio Risk Categorization
11. Run All Problems
0. Exit
```

## Key Learning Objectives

After completing all 10 problems, you should understand:

1. ✅ **SortedDictionary** usage and benefits
2. ✅ **Custom Comparers** for descending order
3. ✅ **Abstract Classes** and inheritance
4. ✅ **Polymorphism** with method overriding
5. ✅ **Custom Exceptions** and hierarchies
6. ✅ **Encapsulation** of business logic
7. ✅ **Design Patterns** (Strategy, Template Method)
8. ✅ **Real-world applications** of data structures

## Difficulty Levels

| Problem | Difficulty | Key Challenge |
|---------|-----------|---------------|
| 1 | ⭐⭐ | Stock validation |
| 2 | ⭐⭐⭐ | Queue + Priority |
| 3 | ⭐⭐⭐ | Risk scoring |
| 4 | ⭐⭐ | Fare calculation |
| 5 | ⭐⭐ | GPA priority |
| 6 | ⭐⭐⭐ | Auction logic |
| 7 | ⭐⭐ | Fine calculation |
| 8 | ⭐⭐ | Repeat offenders |
| 9 | ⭐⭐⭐ | Escalation |
| 10 | ⭐⭐⭐ | Portfolio analysis |

## Time Complexity

All problems use SortedDictionary with:
- **Insert**: O(log n)
- **Delete**: O(log n)
- **Search**: O(log n)
- **Iterate**: O(n)

## Best Practices Demonstrated

1. **Separation of Concerns**: Business logic separate from UI
2. **Single Responsibility**: Each class has one purpose
3. **Open/Closed Principle**: Open for extension, closed for modification
4. **Liskov Substitution**: Derived classes can replace base classes
5. **Dependency Inversion**: Depend on abstractions, not concretions

## Common Mistakes to Avoid

1. Forgetting to use custom comparer for descending order
2. Not validating input before adding to dictionary
3. Assuming keys are unique (use List<T> as value for duplicates)
4. Not handling empty dictionary cases
5. Mixing up key types (int vs decimal vs double)

## Extension Ideas

For each problem, you could add:
1. Database persistence
2. REST API endpoints
3. Web UI
4. Reporting and analytics
5. Email notifications
6. Logging and audit trail
7. Unit tests
8. Performance benchmarking

## Technologies Used

- **Language**: C# 10.0
- **Framework**: .NET 10.0
- **Data Structure**: SortedDictionary<TKey, TValue>
- **Concepts**: OOP, Polymorphism, Exceptions

## Testing

Each problem includes:
- Demo class with test scenarios
- Success and failure cases
- Edge case testing
- Exception handling demonstrations

## Performance Considerations

- SortedDictionary uses Red-Black tree internally
- Memory overhead: ~32 bytes per node
- Best for: Frequent insertions/deletions with sorted access
- Not best for: Random access by index

## Comparison with Other Structures

| Feature | SortedDictionary | Dictionary | SortedList |
|---------|-----------------|------------|------------|
| Sorted | Yes | No | Yes |
| Insert | O(log n) | O(1) | O(n) |
| Search | O(log n) | O(1) | O(log n) |
| Memory | High | Medium | Low |
| Index Access | No | No | Yes |

---

**Project Type**: Console Application  
**Difficulty**: Intermediate to Advanced  
**Focus**: SortedDictionary & OOP  
**Estimated Time**: 10-12 hours  
**Total Problems**: 10  
**Total Files**: 50+
