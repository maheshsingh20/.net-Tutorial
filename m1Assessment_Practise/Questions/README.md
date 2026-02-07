# C#.NET Complex Scenario-Based Coding Questions (Capgemini M1 Style)

## Project Structure

Each question is organized in its own folder with separate entity files and a main `Problem.cs` file.

```
Questions/
├── Question1/
│   ├── Problem.cs (Main entry point)
│   ├── Seat.cs
│   └── TicketBookingSystem.cs
├── Question2/
│   ├── Problem.cs
│   └── RateLimiter.cs
...
```

## How to Run

To run a specific question, set the startup object in the `.csproj` file or run:

```bash
dotnet run --project m1Assessment_Practise.csproj
```

Then modify the `<StartupObject>` in the csproj to point to the question you want:
```xml
<StartupObject>m1Assessment_Practise.Questions.Question1.Problem</StartupObject>
```

## Questions Overview

### 1. Concurrent Ticket Booking
- **Concepts**: Thread Safety, Lock, Race Conditions
- **Files**: Seat.cs, TicketBookingSystem.cs, Problem.cs

### 2. Rate Limiter (Sliding Window)
- **Concepts**: Rate Limiting, Sliding Window Algorithm
- **Files**: RateLimiter.cs, Problem.cs

### 3. Resilient Payment Gateway
- **Concepts**: Retry Logic, Circuit Breaker Pattern
- **Files**: PaymentModels.cs, ResilientPaymentGateway.cs, Problem.cs

### 4. Producer-Consumer Order Processing
- **Concepts**: BlockingCollection, Concurrent Processing
- **Files**: Order.cs, OrderProcessor.cs, Problem.cs

### 5. Large File Log Analyzer
- **Concepts**: Streaming, Memory-Safe Processing
- **Files**: ErrorSummary.cs, LogAnalyzer.cs, Problem.cs

### 6. Transactional Money Transfer
- **Concepts**: Atomic Operations, Rollback, Audit Logging
- **Files**: Account.cs, TransferResult.cs, Exceptions.cs, BankingSystem.cs, Problem.cs

### 7. JSON Batch Validation Pipeline
- **Concepts**: Validation, JSON Processing, Regex
- **Files**: CustomerApplication.cs, ValidationModels.cs, CustomerValidator.cs, Problem.cs

### 8. Cache with TTL + LRU Eviction
- **Concepts**: Caching, TTL, LRU Algorithm
- **Files**: CacheItem.cs, AdvancedCache.cs, Problem.cs

### 9. Parallel Data Aggregation
- **Concepts**: PLINQ, Parallel Processing
- **Files**: Sale.cs, RegionReport.cs, SalesAnalyzer.cs, Problem.cs

### 10. Command Pattern (Undo/Redo)
- **Concepts**: Command Pattern, Design Patterns
- **Files**: ICommand.cs, Commands.cs, ShoppingCart.cs, CommandManager.cs, Problem.cs

### 11. Deadlock-Free Bank Transfers
- **Concepts**: Ordered Locking, Deadlock Prevention
- **Files**: BankAccount.cs, DeadlockFreeBanking.cs, Problem.cs

### 12. Workflow Engine (State Machine)
- **Concepts**: State Machine, Workflow Management
- **Files**: LoanModels.cs, WorkflowEngine.cs, Problem.cs

### 13. CSV Import with Partial Success
- **Concepts**: Error Handling, Partial Success
- **Files**: Product.cs, ImportModels.cs, ProductImporter.cs, Problem.cs

### 14. Secure Password Storage
- **Concepts**: PBKDF2, Hashing, Salt, Security
- **Files**: PasswordHasher.cs, Problem.cs

### 15. Custom LINQ Extensions
- **Concepts**: yield return, Extension Methods
- **Files**: CustomLinqExtensions.cs, Grouping.cs, Problem.cs

### 16. Multi-Tenant Report Generator
- **Concepts**: Grouping, Business Rules, Multi-Tenancy
- **Files**: Transaction.cs, TenantReport.cs, ReportGenerator.cs, Problem.cs

### 17. Async Pipeline with Ordering
- **Concepts**: SemaphoreSlim, Async/Await, Order Preservation
- **Files**: Models.cs, AsyncPipeline.cs, Problem.cs

### 18. Duplicate Detection (Fuzzy Matching)
- **Concepts**: Levenshtein Distance, Fuzzy Matching
- **Files**: Customer.cs, DuplicateGroup.cs, DuplicateDetector.cs, Problem.cs

### 19. Audit Trigger Simulation
- **Concepts**: Change Tracking, Reflection
- **Files**: AuditEntry.cs, Employee.cs, EntityTracker.cs, Problem.cs

### 20. RBAC Engine
- **Concepts**: Role-Based Access Control, Authorization
- **Files**: Models.cs, RBACEngine.cs, Problem.cs

### 21. Bulk Email Sender
- **Concepts**: Throttling, Retry Queue, Rate Limiting
- **Files**: Models.cs, EmailSender.cs, Problem.cs

### 22. Fraud Detection
- **Concepts**: Pattern Detection, Window Analysis
- **Files**: Models.cs, FraudDetector.cs, Problem.cs

### 23. Plugin Loader
- **Concepts**: Reflection, Dynamic Loading
- **Files**: IPlugin.cs, PluginLoader.cs, SamplePlugins.cs, Problem.cs

### 24. Thread-Safe Singleton
- **Concepts**: Singleton Pattern, Lazy Initialization
- **Files**: ConfigManager.cs, Problem.cs

### 25. Mini Order System
- **Concepts**: OOP, Validation, Exceptions, Complete System
- **Files**: Customer.cs, Product.cs, Order.cs, OrderItem.cs, Exceptions.cs, OrderSystem.cs, Problem.cs

## Key Concepts Covered

- **Concurrency**: Thread safety, locks, deadlock prevention, async/await
- **Design Patterns**: Command, Singleton, State Machine, Circuit Breaker
- **Data Processing**: Streaming, parallel processing, PLINQ
- **Security**: Password hashing, RBAC, validation
- **Performance**: Caching, rate limiting, memory optimization
- **Error Handling**: Retry logic, partial success, rollback
- **Advanced C#**: Reflection, LINQ, extension methods, yield return
