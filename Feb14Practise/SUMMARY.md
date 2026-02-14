# Feb14Practise - Project Summary

## Overview
This project contains 10 comprehensive real-world problems demonstrating advanced C# concepts including SortedDictionary, OOP principles, custom exceptions, and polymorphism.

## Project Statistics
- **Total Problems**: 10
- **Total Files**: 50+ C# files
- **Lines of Code**: ~2000+
- **Namespaces**: 10 (one per problem)

## Quick Reference

| # | Problem | Data Structure | Key Feature |
|---|---------|---------------|-------------|
| 1 | Warehouse Inventory | `SortedDictionary<int, List<Product>>` | Priority-based stock management |
| 2 | Hospital Emergency | `SortedDictionary<int, Queue<Patient>>` | Severity-based patient queue |
| 3 | Banking Risk | `SortedDictionary<int, List<Transaction>>` | Risk score monitoring (descending) |
| 4 | Airline Booking | `SortedDictionary<decimal, List<Ticket>>` | Fare-based classification |
| 5 | Course Registration | `SortedDictionary<double, List<Student>>` | GPA-based priority (descending) |
| 6 | Flash Sale Bidding | `SortedDictionary<decimal, List<Bid>>` | Highest bid tracking (descending) |
| 7 | Library Fines | `SortedDictionary<decimal, LibraryUser>` | Fine amount tracking |
| 8 | Traffic Violations | `SortedDictionary<decimal, List<Violation>>` | Penalty-based sorting (descending) |
| 9 | IT Support Tickets | `SortedDictionary<int, Queue<SupportTicket>>` | Severity-based processing |
| 10 | Investment Portfolio | `SortedDictionary<int, List<Asset>>` | Risk-based categorization |

## OOP Concepts Demonstrated

### Abstraction
- Abstract base classes in all 10 problems
- Template method pattern for common behaviors

### Inheritance
- Product → Electronics, Perishable, FragileItem
- Person → Patient, Student
- Transaction → OnlineTransaction, WireTransfer
- Ticket → Economy, Business, FirstClass
- User → Buyer, Seller, Employee, Admin
- LibraryUser → StudentMember, FacultyMember
- Vehicle → Car, Truck, Bike
- Asset → Stocks, Bonds, MutualFunds

### Polymorphism
- Virtual/Override methods for custom behavior
- CalculateFare(), CalculateReturn(), CalculateFine()
- Treat(), ResolveTicket(), ValidateBid()

### Encapsulation
- Private fields with public properties
- Validation in setters
- Encapsulated business logic

## Exception Hierarchy

Each problem implements custom exceptions:
- Base exceptions (e.g., InventoryException)
- Specific exceptions (e.g., LowStockException, DuplicateSKUException)
- Proper exception handling in all operations

## Design Patterns Used

1. **Strategy Pattern**: Risk calculation in banking transactions
2. **Template Method**: Abstract methods in base classes
3. **Factory Pattern**: Object creation in demos
4. **Observer Pattern**: Stock threshold monitoring

## Running the Project

```bash
# Build the project
dotnet build

# Run with interactive menu
dotnet run

# Run specific problem (example: Problem 1)
# Select option 1 from the menu
```

## File Organization

```
Feb14Practise/
├── Program.cs                    # Main menu
├── Questions/
│   ├── Problem1/
│   │   ├── Product.cs           # Abstract class + derived classes
│   │   ├── Exceptions.cs        # Custom exceptions
│   │   ├── WarehouseManager.cs  # Business logic
│   │   └── Demo.cs              # Demonstration
│   ├── Problem2/
│   │   ├── Person.cs
│   │   ├── Exceptions.cs
│   │   ├── EmergencyManager.cs
│   │   └── Demo.cs
│   └── ... (similar structure for all problems)
└── README.md
```

## Key Takeaways

1. **SortedDictionary** automatically maintains sorted order by key
2. **Custom Comparers** enable descending order sorting
3. **Abstract Classes** provide common structure and enforce contracts
4. **Custom Exceptions** improve error handling and debugging
5. **Polymorphism** enables flexible and extensible code
6. **Real-world scenarios** demonstrate practical applications

## Testing

Each problem includes:
- Demo class with test scenarios
- Exception handling demonstrations
- Edge case testing
- Success and failure paths

## Future Enhancements

- Unit tests for all components
- Persistence layer (database/file storage)
- REST API endpoints
- UI/Web interface
- Performance benchmarking
- Logging and monitoring

---

**Created**: February 14, 2026
**Language**: C# 10.0
**Framework**: .NET 10.0
