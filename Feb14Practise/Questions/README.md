# SortedDictionary Practice - 10 Real-World Problems

This project contains 10 comprehensive problems demonstrating the use of `SortedDictionary<TKey, TValue>` in real-world scenarios with OOP principles, custom exceptions, and polymorphism.

## Project Structure

```
Feb14Practise/
├── Questions/
│   ├── Problem1/  - Smart Warehouse Inventory Prioritization
│   ├── Problem2/  - Hospital Emergency Queue Management
│   ├── Problem3/  - Banking Transaction Risk Monitoring
│   ├── Problem4/  - Airline Booking Fare Classification
│   ├── Problem5/  - University Course Registration Priority
│   ├── Problem6/  - E-Commerce Flash Sale Bidding Engine
│   ├── Problem7/  - Library Fine Calculation & Penalty
│   ├── Problem8/  - Smart Traffic Violation Monitoring
│   ├── Problem9/  - IT Support Ticket Severity System
│   └── Problem10/ - Investment Portfolio Risk Categorization
└── Program.cs     - Main menu to run all problems
```

## Problem Summaries

### 1. Smart Warehouse Inventory Prioritization System
- **Data Structure**: `SortedDictionary<int, List<Product>>`
- **Key Concepts**: Abstract Product class, derived classes (Electronics, Perishable, FragileItem)
- **Exceptions**: LowStockException, DuplicateSKUException, InvalidProductException
- **Features**: Priority-based sorting (1=Critical, 10=Low), stock validation, automatic alerts

### 2. Hospital Emergency Queue Management System
- **Data Structure**: `SortedDictionary<int, Queue<Patient>>`
- **Key Concepts**: Abstract Person class, Patient inheritance, polymorphic Treat() method
- **Exceptions**: InvalidSeverityException, PatientNotFoundException, QueueOverflowException
- **Features**: Severity-based queue (1=Critical), FIFO within same severity

### 3. Banking Transaction Risk Monitoring System
- **Data Structure**: `SortedDictionary<int, List<Transaction>>` (descending order)
- **Key Concepts**: Abstract Transaction, OnlineTransaction/WireTransfer, Strategy pattern
- **Exceptions**: FraudDetectedException, NegativeAmountException, TransactionLimitExceededException
- **Features**: Risk score calculation, fraud detection, transaction limits

### 4. Airline Booking Fare Classification System
- **Data Structure**: `SortedDictionary<decimal, List<Ticket>>`
- **Key Concepts**: Abstract Ticket, Economy/Business/FirstClass, polymorphic CalculateFare()
- **Exceptions**: SeatAlreadyBookedException, InvalidFareException
- **Features**: Fare-based sorting, seat availability tracking, fare calculation

### 5. University Course Registration Priority System
- **Data Structure**: `SortedDictionary<double, List<Student>>` (descending GPA)
- **Key Concepts**: Abstract Person, Student inheritance, GPA-based priority
- **Exceptions**: CourseFullException, InvalidGPAException, DuplicateEnrollmentException
- **Features**: GPA-based seat allocation, enrollment tracking, capacity management

### 6. E-Commerce Flash Sale Bidding Engine
- **Data Structure**: `SortedDictionary<decimal, List<Bid>>` (descending)
- **Key Concepts**: Abstract User, Buyer/Seller, polymorphic bid validation
- **Exceptions**: BidTooLowException, AuctionClosedException
- **Features**: Highest bid tracking, wallet validation, auction lifecycle

### 7. Library Fine Calculation & Penalty System
- **Data Structure**: `SortedDictionary<decimal, LibraryUser>`
- **Key Concepts**: Abstract LibraryUser, StudentMember/FacultyMember, override CalculateFine()
- **Exceptions**: FineNotFoundException, InvalidPaymentException
- **Features**: Fine calculation by member type, payment processing, outstanding tracking

### 8. Smart Traffic Violation Monitoring System
- **Data Structure**: `SortedDictionary<decimal, List<Violation>>` (descending)
- **Key Concepts**: Abstract Vehicle, Car/Truck/Bike, violation encapsulation
- **Exceptions**: InvalidVehicleException, PenaltyExceedsLimitException
- **Features**: Penalty-based sorting, repeat offender detection, escalation

### 9. IT Support Ticket Severity System
- **Data Structure**: `SortedDictionary<int, Queue<SupportTicket>>`
- **Key Concepts**: Abstract User, Employee/Admin, override ResolveTicket()
- **Exceptions**: TicketNotFoundException, InvalidPriorityException
- **Features**: Severity-based processing, ticket escalation, FIFO queue

### 10. Investment Portfolio Risk Categorization System
- **Data Structure**: `SortedDictionary<int, List<Investment>>`
- **Key Concepts**: Abstract Asset, Stocks/Bonds/MutualFunds, polymorphic CalculateReturn()
- **Exceptions**: InvalidRiskRatingException, InvestmentLimitExceededException
- **Features**: Risk-based categorization, portfolio analysis, return calculation

## How to Run

```bash
cd Feb14Practise
dotnet build
dotnet run
```

Select a problem number (1-10) from the menu, or choose 11 to run all problems sequentially.

## Key Learning Objectives

1. **SortedDictionary Usage**: Automatic sorting by key
2. **Custom Comparers**: Descending order sorting
3. **OOP Principles**: Abstraction, inheritance, polymorphism, encapsulation
4. **Exception Handling**: Custom exception hierarchies
5. **Real-World Scenarios**: Practical applications of data structures
6. **Design Patterns**: Strategy pattern, template method pattern

## Technologies Used

- C# 10.0
- .NET 10.0
- SortedDictionary<TKey, TValue>
- Object-Oriented Programming
- Custom Exception Handling
