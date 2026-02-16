# LINQ (Language Integrated Query) - Feb10

## Overview
This folder contains comprehensive LINQ demonstrations and practice exercises for C#.

## Files

### 1. Lambda.cs
Basic lambda expression demonstration showing:
- Function delegates
- Lambda syntax
- Simple arithmetic operations

### 2. LinqDemo.cs (NEW)
Comprehensive LINQ demonstrations covering 23 different operations:

#### Filtering & Projection
- `Where` - Filter data based on conditions
- `Select` - Project/transform data
- `SelectMany` - Flatten nested collections

#### Sorting
- `OrderBy` - Sort ascending
- `OrderByDescending` - Sort descending
- `ThenBy` - Secondary sorting

#### Aggregation
- `Count` - Count elements
- `Sum` - Sum numeric values
- `Average` - Calculate average
- `Min` / `Max` - Find minimum/maximum
- `Aggregate` - Custom aggregation

#### Element Operations
- `First` / `FirstOrDefault` - Get first element
- `Single` / `SingleOrDefault` - Get single element
- `Any` - Check if any element matches
- `All` - Check if all elements match

#### Set Operations
- `Distinct` - Get unique elements
- `Take` - Take first N elements
- `Skip` - Skip first N elements

#### Grouping & Joining
- `GroupBy` - Group elements by key
- `Join` - Join two collections

#### Conversion
- `ToList` - Convert to List
- `ToArray` - Convert to Array
- `ToDictionary` - Convert to Dictionary

### 3. LinqExercises.cs (NEW)
15 practical LINQ exercises with solutions:

1. Filter products by price
2. Get product names by category
3. Count products by category
4. Find most expensive product
5. Calculate total inventory value
6. Find low stock products
7. Calculate average price by category
8. Get top 3 most stocked products
9. Multi-level sorting
10. Check for out-of-stock items
11. Get distinct categories
12. Search products by name
13. Calculate total stock by category
14. Filter by price range
15. Create projections with calculations

## How to Run

### Method 1: Run from Main Program
```bash
cd Feb10
dotnet run
# Choose option 3 for LINQ Demo or option 4 for Exercises
```

### Method 2: Run Directly
```bash
# For LINQ Demo
dotnet run --project Feb10.csproj /p:StartupObject=Feb10.Questions.LINQ.LinqDemo

# For LINQ Exercises
dotnet run --project Feb10.csproj /p:StartupObject=Feb10.Questions.LINQ.LinqExercises
```

## LINQ Syntax Types

### Method Syntax (Fluent)
```csharp
var result = employees
    .Where(e => e.Age > 25)
    .OrderBy(e => e.Name)
    .Select(e => e.Name);
```

### Query Syntax (SQL-like)
```csharp
var result = from e in employees
             where e.Age > 25
             orderby e.Name
             select e.Name;
```

## Key Concepts Demonstrated

### 1. Deferred Execution
LINQ queries are not executed until enumerated:
```csharp
var query = employees.Where(e => e.Age > 25); // Not executed yet
foreach (var emp in query) { } // Executed here
```

### 2. Method Chaining
Multiple LINQ operations can be chained:
```csharp
var result = employees
    .Where(e => e.Age > 25)
    .OrderBy(e => e.Salary)
    .Take(5);
```

### 3. Lambda Expressions
Short anonymous functions used in LINQ:
```csharp
e => e.Age > 25  // Lambda expression
```

### 4. Anonymous Types
Create types on-the-fly:
```csharp
var result = employees.Select(e => new { e.Name, e.Age });
```

## Common LINQ Patterns

### Pattern 1: Filter and Project
```csharp
var names = employees
    .Where(e => e.Department == "IT")
    .Select(e => e.Name);
```

### Pattern 2: Group and Aggregate
```csharp
var summary = employees
    .GroupBy(e => e.Department)
    .Select(g => new { 
        Department = g.Key, 
        Count = g.Count(),
        AvgSalary = g.Average(e => e.Salary)
    });
```

### Pattern 3: Sort with Multiple Keys
```csharp
var sorted = employees
    .OrderBy(e => e.Department)
    .ThenByDescending(e => e.Salary);
```

### Pattern 4: Pagination
```csharp
var page = employees
    .Skip((pageNumber - 1) * pageSize)
    .Take(pageSize);
```

## Performance Tips

1. **Use `Any()` instead of `Count() > 0`**
   ```csharp
   // Good
   if (employees.Any(e => e.Age > 30))
   
   // Bad
   if (employees.Count(e => e.Age > 30) > 0)
   ```

2. **Use `FirstOrDefault()` for single items**
   ```csharp
   var emp = employees.FirstOrDefault(e => e.Id == 5);
   ```

3. **Materialize queries when needed**
   ```csharp
   var list = query.ToList(); // Execute and cache
   ```

## Practice Exercises

Try modifying the exercises to:
1. Add more complex filtering conditions
2. Combine multiple LINQ operations
3. Create custom aggregations
4. Work with nested collections
5. Implement pagination
6. Create complex projections

## Additional Resources

- LINQ Documentation: https://docs.microsoft.com/en-us/dotnet/csharp/linq/
- Lambda Expressions: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/lambda-expressions
- Query Syntax: https://docs.microsoft.com/en-us/dotnet/csharp/linq/query-expression-basics

## Status
✅ Lambda.cs - Basic lambda expressions
✅ LinqDemo.cs - 23 LINQ operations demonstrated
✅ LinqExercises.cs - 15 practice exercises with solutions
✅ All code tested and working
