# Generics Practice - Real-World Scenarios

## Overview

This project contains two comprehensive problems demonstrating advanced C# generics concepts with real-world applications.

## Project Structure

```
GenericsPractice/
├── Problem1/               # E-Commerce Inventory System
│   ├── IProduct.cs
│   ├── ProductRepository.cs
│   ├── ElectronicProduct.cs
│   ├── DiscountedProduct.cs
│   ├── InventoryManager.cs
│   └── InventoryDemo.cs
├── Problem2/               # Course Registration System
│   ├── IStudent.cs
│   ├── ICourse.cs
│   ├── EngineeringStudent.cs
│   ├── LabCourse.cs
│   ├── EnrollmentSystem.cs
│   ├── GradeBook.cs
│   └── CourseRegistrationDemo.cs
├── Program.cs              # Main menu
└── README.md               # This file
```

## Problem 1: E-Commerce Inventory System

### Objective
Design a flexible inventory system that can handle different product categories with varying attributes while maintaining type safety.

### Key Concepts
- Generic repository pattern with constraints
- Interface-based generics
- Func<T, TResult> delegates
- Generic wrapper classes
- LINQ with generics

### Features
- Type-safe product repository
- Validation (unique ID, positive price, non-empty name)
- Flexible product filtering with predicates
- Discount system with generic wrapper
- Bulk price updates
- Mixed collection handling

### Generic Constraints Used
```csharp
public class ProductRepository<T> where T : class, IProduct
public class DiscountedProduct<T> where T : IProduct
public void ProcessProducts<T>(IEnumerable<T> products) where T : IProduct
```

## Problem 2: Course Registration System

### Objective
Design a type-safe course registration system with constraints on student enrollment and grade management.

### Key Concepts
- Multiple generic type parameters
- Generic constraints with multiple interfaces
- Tuple usage in generics
- Dictionary with composite keys
- Nullable return types

### Features
- Type-safe enrollment system
- Validation (capacity, prerequisites, duplicates)
- Student workload calculation
- Grade management with GPA calculation
- Top student identification
- Immutable collections (IReadOnlyList)

### Generic Constraints Used
```csharp
public class EnrollmentSystem<TStudent, TCourse>
    where TStudent : IStudent
    where TCourse : ICourse

public class GradeBook<TStudent, TCourse>
    where TStudent : IStudent
    where TCourse : ICourse
```

## How to Run

```bash
cd GenericsPractice
dotnet build
dotnet run
```

### Menu Options
```
1. Problem 1: E-Commerce Inventory System
2. Problem 2: Course Registration System
0. Exit
```

## Learning Objectives

### Problem 1
1. ✅ Generic classes with single type parameter
2. ✅ Interface constraints
3. ✅ Class constraints
4. ✅ Generic methods
5. ✅ Func<T, TResult> delegates
6. ✅ Generic wrapper pattern
7. ✅ LINQ with generics

### Problem 2
1. ✅ Generic classes with multiple type parameters
2. ✅ Multiple interface constraints
3. ✅ Composite keys in dictionaries
4. ✅ Nullable return types
5. ✅ Tuple usage
6. ✅ IReadOnlyList for immutability
7. ✅ Complex validation logic

## Key Differences Between Problems

| Aspect | Problem 1 | Problem 2 |
|--------|-----------|-----------|
| Type Parameters | Single (T) | Multiple (TStudent, TCourse) |
| Constraints | class, IProduct | IStudent, ICourse |
| Collections | List, Dictionary | Dictionary with tuples |
| Return Types | IEnumerable | IReadOnlyList, Nullable |
| Complexity | Intermediate | Advanced |

## Generic Patterns Demonstrated

### 1. Repository Pattern
```csharp
public class Repository<T> where T : class, IEntity
{
    private List<T> _items = new List<T>();
    public void Add(T item) { }
    public IEnumerable<T> Find(Func<T, bool> predicate) { }
}
```

### 2. Wrapper Pattern
```csharp
public class Wrapper<T> where T : IBase
{
    private T _item;
    public T Item => _item;
}
```

### 3. Manager Pattern
```csharp
public class Manager<T1, T2>
    where T1 : IInterface1
    where T2 : IInterface2
{
    private Dictionary<T2, List<T1>> _data;
}
```

## Best Practices Demonstrated

1. **Use Constraints**: Limit generic types appropriately
2. **Validation**: Always validate inputs
3. **Immutability**: Return IReadOnlyList when appropriate
4. **Null Safety**: Use nullable types for optional returns
5. **Separation of Concerns**: Keep business logic separate
6. **Error Messages**: Provide clear, actionable messages

## Common Mistakes Avoided

1. ❌ Not using constraints when needed
2. ❌ Returning mutable collections
3. ❌ Missing validation
4. ❌ Poor error messages
5. ❌ Mixing concerns

## Extension Ideas

### Problem 1
- Add database persistence
- Implement caching
- Add search functionality
- Create REST API
- Add inventory alerts

### Problem 2
- Add waitlist functionality
- Implement course prerequisites graph
- Add transcript generation
- Create scheduling system
- Add payment integration

## Technologies Used

- **Language**: C# 10.0
- **Framework**: .NET 10.0
- **Concepts**: Generics, LINQ, Delegates, Interfaces
- **Patterns**: Repository, Wrapper, Manager

## Performance Considerations

- Generic collections avoid boxing
- LINQ uses deferred execution
- Constraints enable compile-time optimization
- Type-specific code generation

## Testing Scenarios

### Problem 1
- ✅ Adding products with validation
- ✅ Duplicate ID detection
- ✅ Negative price validation
- ✅ Finding products by predicate
- ✅ Applying discounts
- ✅ Mixed collection handling

### Problem 2
- ✅ Successful enrollment
- ✅ Capacity limit enforcement
- ✅ Prerequisite checking
- ✅ Duplicate enrollment prevention
- ✅ Grade validation
- ✅ GPA calculation
- ✅ Top student identification

---

**Project Type**: Console Application  
**Difficulty**: Intermediate to Advanced  
**Focus**: C# Generics & Type Safety  
**Estimated Time**: 6-8 hours  
**Prerequisites**: OOP, Interfaces, LINQ, Delegates
