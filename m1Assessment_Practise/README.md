# M1 Assessment Practice - Advanced C# Concepts

A comprehensive collection of 25 advanced C# programming questions covering concurrency, design patterns, async programming, and enterprise patterns.

## 📋 Project Overview

This project contains practice questions for M1 (Module 1) assessment, focusing on advanced C# concepts including thread safety, design patterns, async/await, and real-world enterprise scenarios.

## 🎯 Question Categories

### Concurrency & Threading (Questions 1-3, 11)
- Thread-safe ticket booking system
- Concurrent counter with locks
- Producer-consumer pattern
- Deadlock-free banking

### Async Programming (Questions 4, 9, 16)
- Async file processing
- Retry mechanisms with exponential backoff
- Circuit breaker pattern

### Design Patterns (Questions 10, 17-25)
- Command Pattern (Undo/Redo)
- Dependency Injection
- Strategy, Observer, Factory patterns
- Decorator, Adapter, Singleton patterns
- Builder pattern

### Enterprise Patterns (Questions 5-8, 12-15, 18)
- Rate limiter
- Banking system
- Cache implementation
- Event aggregator
- Workflow engine (State Machine)
- CSV import with partial success
- Notification system
- Object pool
- Middleware pipeline

## 📁 Project Structure

```
m1Assessment_Practise/
├── Questions/
│   ├── Question1/
│   │   ├── Problem.cs              # Concurrent ticket booking
│   │   └── TicketBookingSystem.cs
│   ├── Question2/
│   │   ├── Problem.cs              # Thread-safe counter
│   │   └── ThreadSafeCounter.cs
│   ├── Question3/
│   │   ├── Problem.cs              # Producer-consumer
│   │   └── ProducerConsumer.cs
│   ├── Question4/
│   │   ├── Problem.cs              # Async file processing
│   │   └── FileProcessor.cs
│   ├── Question5/
│   │   ├── Problem.cs              # Rate limiter
│   │   └── RateLimiter.cs
│   ├── Question6/
│   │   ├── Problem.cs              # Banking system
│   │   └── BankingSystem.cs
│   ├── Question7/
│   │   ├── Problem.cs              # Cache implementation
│   │   └── Cache.cs
│   ├── Question8/
│   │   ├── Problem.cs              # Event aggregator
│   │   └── EventAggregator.cs
│   ├── Question9/
│   │   ├── Problem.cs              # Retry mechanism
│   │   └── RetryHandler.cs
│   ├── Question10/
│   │   ├── Problem.cs              # Command pattern
│   │   └── CommandPattern.cs
│   ├── Question11/
│   │   ├── Problem.cs              # Deadlock-free banking
│   │   └── DeadlockFreeBanking.cs
│   ├── Question12/
│   │   ├── Problem.cs              # Workflow engine
│   │   └── WorkflowEngine.cs
│   ├── Question13/
│   │   ├── Problem.cs              # CSV import
│   │   └── CsvImporter.cs
│   ├── Question14/
│   │   ├── Problem.cs              # Notification system
│   │   └── NotificationSystem.cs
│   ├── Question15/
│   │   ├── Problem.cs              # Object pool
│   │   └── ObjectPool.cs
│   ├── Question16/
│   │   ├── Problem.cs              # Circuit breaker
│   │   └── CircuitBreaker.cs
│   ├── Question17/
│   │   ├── Problem.cs              # Dependency injection
│   │   └── DIContainer.cs
│   ├── Question18/
│   │   ├── Problem.cs              # Middleware pipeline
│   │   └── Middleware.cs
│   ├── Question19/
│   │   ├── Problem.cs              # Strategy pattern
│   │   └── StrategyPattern.cs
│   ├── Question20/
│   │   ├── Problem.cs              # Observer pattern
│   │   └── ObserverPattern.cs
│   ├── Question21/
│   │   ├── Problem.cs              # Factory pattern
│   │   └── FactoryPattern.cs
│   ├── Question22/
│   │   ├── Problem.cs              # Decorator pattern
│   │   └── DecoratorPattern.cs
│   ├── Question23/
│   │   ├── Problem.cs              # Adapter pattern
│   │   └── AdapterPattern.cs
│   ├── Question24/
│   │   ├── Problem.cs              # Singleton pattern
│   │   └── SingletonPattern.cs
│   └── Question25/
│       ├── Problem.cs              # Builder pattern
│       └── BuilderPattern.cs
├── Program.cs                      # Main entry point
├── m1Assessment_Practise.csproj    # Project file
└── README.md                       # This file
```

## 🚀 Running the Project

### Build
```bash
cd m1Assessment_Practise
dotnet build
```

### Run
```bash
dotnet run
```

### Run Specific Question
To run a specific question:
1. Open `Questions/QuestionX/Problem.cs`
2. Uncomment the `Main` method
3. Comment out the `Main` method in `Program.cs`
4. Run: `dotnet run`

## 📚 Featured Questions

### Question 1: Concurrent Ticket Booking
**Concept**: Thread safety with locks

**Problem**: Multiple threads trying to book tickets simultaneously without race conditions.

**Key Learning**:
- `lock` statement
- Thread synchronization
- Race condition prevention

```csharp
lock (_lockObject)
{
    if (_availableTickets > 0)
    {
        _availableTickets--;
        return true;
    }
    return false;
}
```

---

### Question 3: Producer-Consumer Pattern
**Concept**: Thread communication with BlockingCollection

**Problem**: Implement producer-consumer pattern for processing tasks.

**Key Learning**:
- `BlockingCollection<T>`
- Thread coordination
- Queue-based processing

---

### Question 4: Async File Processing
**Concept**: Async/await for I/O operations

**Problem**: Process multiple files asynchronously without blocking.

**Key Learning**:
- `async`/`await` keywords
- `Task<T>` and `Task`
- Parallel file processing

```csharp
public async Task<string> ProcessFileAsync(string filePath)
{
    string content = await File.ReadAllTextAsync(filePath);
    // Process content
    return result;
}
```

---

### Question 9: Retry Mechanism
**Concept**: Exponential backoff retry pattern

**Problem**: Retry failed operations with increasing delays.

**Key Learning**:
- Retry logic
- Exponential backoff
- Exception handling

```csharp
for (int attempt = 0; attempt < maxRetries; attempt++)
{
    try
    {
        return await operation();
    }
    catch (Exception ex)
    {
        if (attempt == maxRetries - 1) throw;
        await Task.Delay(TimeSpan.FromSeconds(Math.Pow(2, attempt)));
    }
}
```

---

### Question 10: Command Pattern
**Concept**: Undo/Redo functionality

**Problem**: Implement command pattern with undo/redo support.

**Key Learning**:
- Command pattern
- Stack-based undo/redo
- Encapsulation of operations

---

### Question 11: Deadlock-Free Banking
**Concept**: Ordered locking to prevent deadlocks

**Problem**: Transfer money between accounts without deadlocks.

**Key Learning**:
- Deadlock prevention
- Ordered resource acquisition
- Thread safety in banking

```csharp
// Always lock accounts in consistent order
var first = account1.Id.CompareTo(account2.Id) < 0 ? account1 : account2;
var second = first == account1 ? account2 : account1;

lock (first)
{
    lock (second)
    {
        // Transfer logic
    }
}
```

---

### Question 12: Workflow Engine (State Machine)
**Concept**: State pattern for workflow management

**Problem**: Implement workflow with states: Draft → Submitted → Approved → Completed.

**Key Learning**:
- State machine
- State transitions
- Workflow management

---

### Question 16: Circuit Breaker Pattern
**Concept**: Fault tolerance

**Problem**: Prevent cascading failures by breaking circuit after failures.

**Key Learning**:
- Circuit breaker states: Closed, Open, Half-Open
- Failure threshold
- Automatic recovery

---

### Question 17: Dependency Injection
**Concept**: IoC container

**Problem**: Implement simple DI container for dependency management.

**Key Learning**:
- Dependency injection
- Service registration
- Lifetime management

---

### Questions 19-25: Design Patterns
Classic Gang of Four patterns:
- **Strategy**: Algorithm selection at runtime
- **Observer**: Event notification system
- **Factory**: Object creation abstraction
- **Decorator**: Add behavior dynamically
- **Adapter**: Interface compatibility
- **Singleton**: Single instance guarantee
- **Builder**: Complex object construction

## 🎓 Concepts Covered

### Concurrency
- Thread safety
- Locks and monitors
- Concurrent collections
- Deadlock prevention
- Race conditions

### Async Programming
- async/await
- Task-based asynchronous pattern (TAP)
- Parallel processing
- Async I/O operations

### Design Patterns
- Creational: Factory, Singleton, Builder
- Structural: Decorator, Adapter
- Behavioral: Strategy, Observer, Command, State

### Enterprise Patterns
- Repository pattern
- Unit of Work
- Circuit Breaker
- Retry with backoff
- Rate limiting
- Object pooling
- Middleware pipeline

## 💡 Key Learning Points

### 1. Thread Safety
```csharp
private readonly object _lock = new object();

public void ThreadSafeMethod()
{
    lock (_lock)
    {
        // Critical section
    }
}
```

### 2. Async/Await
```csharp
public async Task<T> GetDataAsync()
{
    var result = await FetchDataAsync();
    return ProcessData(result);
}
```

### 3. SOLID Principles
- Single Responsibility
- Open/Closed
- Liskov Substitution
- Interface Segregation
- Dependency Inversion

### 4. Exception Handling
```csharp
try
{
    await RiskyOperation();
}
catch (SpecificException ex)
{
    // Handle specific exception
    _logger.LogError(ex, "Operation failed");
    throw; // Re-throw if needed
}
finally
{
    // Cleanup
}
```

## 🧪 Testing Approach

Each question includes:
1. Problem statement
2. Implementation requirements
3. Test scenarios
4. Expected output

## 🔧 Technologies Used

- **Language**: C# 10.0
- **Framework**: .NET 10.0
- **Concepts**: Threading, Async, Design Patterns
- **Platform**: Cross-platform

## 📊 Difficulty Levels

| Questions | Difficulty | Focus Area |
|-----------|-----------|------------|
| 1-5 | Medium | Concurrency basics |
| 6-10 | Medium | Enterprise patterns |
| 11-15 | Hard | Advanced concurrency |
| 16-18 | Hard | Fault tolerance |
| 19-25 | Medium | Design patterns |

## 🎯 Assessment Preparation

### Study Plan
1. **Week 1**: Questions 1-5 (Concurrency)
2. **Week 2**: Questions 6-10 (Enterprise patterns)
3. **Week 3**: Questions 11-15 (Advanced topics)
4. **Week 4**: Questions 16-25 (Patterns & review)

### Practice Tips
- Understand the problem before coding
- Write clean, readable code
- Handle edge cases
- Add proper error handling
- Test thoroughly

## 📝 Best Practices Demonstrated

1. **Code Organization**
   - One question per folder
   - Clear separation of concerns
   - Meaningful names

2. **Error Handling**
   - Try-catch blocks
   - Custom exceptions
   - Graceful degradation

3. **Performance**
   - Async for I/O
   - Proper locking
   - Resource management

4. **Maintainability**
   - SOLID principles
   - Design patterns
   - Clean code

## 🤝 Contributing

This is an assessment practice repository. Feel free to:
- Add more questions
- Improve existing solutions
- Share alternative approaches

## 📄 License

Educational purposes only.

## 👤 Author

Created for M1 assessment preparation.

---

**Last Updated**: February 19, 2026  
**Total Questions**: 25  
**.NET Version**: 10.0  
**C# Version**: 10.0

## 🎉 Good Luck!

Practice these questions thoroughly to master advanced C# concepts and ace your M1 assessment!
