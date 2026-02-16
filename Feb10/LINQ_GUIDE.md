# Feb10 - LINQ and Lambda Expressions Guide

## 📁 Project Structure

```
Feb10/
├── Program.cs                    # Main entry point with menu
├── Questions/
│   ├── LINQ/
│   │   ├── LinqDemo.cs          # Comprehensive LINQ demonstrations
│   │   └── Lambda.cs            # Lambda expression examples
│   └── Problem1/
│       └── ShowDetail.cs        # Entity demonstration
```

## 🎯 Purpose of Each File

### **1. Program.cs**
**Purpose**: Main menu-driven entry point
- Provides interactive menu to choose different demonstrations
- Options:
  1. Problem 1 - Entity Demo
  2. Lambda Expression Demo
  3. LINQ Comprehensive Demo
  4. LINQ Practice Exercises
  5. Exit

### **2. LinqDemo.cs**
**Purpose**: Complete LINQ tutorial with 23 different operations

#### LINQ Operations Covered:

**Filtering & Selection:**
1. `Where` - Filter data based on conditions
2. `Select` - Project/transform data
3. `Distinct` - Get unique values

**Sorting:**
4. `OrderBy` - Sort ascending
5. `OrderByDescending` - Sort descending
6. `ThenBy` - Secondary sorting

**Element Operations:**
7. `First` / `FirstOrDefault` - Get first element
8. `Single` / `SingleOrDefault` - Get single element
9. `Last` / `LastOrDefault` - Get last element

**Quantifiers:**
10. `Any` - Check if any element matches
11. `All` - Check if all elements match

**Aggregation:**
12. `Count` - Count elements
13. `Sum` - Sum numeric values
14. `Average` - Calculate average
15. `Min` / `Max` - Find minimum/maximum

**Partitioning:**
16. `Take` - Take first N elements
17. `Skip` - Skip first N elements
18. `TakeWhile` / `SkipWhile` - Conditional partitioning

**Grouping & Joining:**
19. `GroupBy` - Group elements by key
20. `Join` - Join two collections
21. `SelectMany` - Flatten nested collections

**Conversion:**
22. `ToList` / `ToArray` / `ToDictionary` - Convert to collections
23. `Aggregate` - Custom aggregation

**Query Syntax:**
- Demonstrates both Method Syntax and Query Syntax
- Shows method chaining for complex queries

#### Sample Data:
- **Employee** entity with: Id, Name, Age, Department, Salary, City
- **Department** entity with: Name, Location
- **EmployeeWithSkills** entity with: Name, Skills (List)

### **3. Lambda.cs**
**Purpose**: Lambda expression basics
- Shows simple lambda syntax: `(x, y) => x + y`
- Uses `Func<int, int, int>` delegate
- Demonstrates inline function definition

### **4. ShowDetail.cs** (Problem1)
**Purpose**: Entity class demonstration
- Shows how to create and use entity classes
- Demonstrates properties and methods

## 🚀 How to Run

### Run Specific Demos:

```bash
# Run the main menu
cd Feb10
dotnet run

# Or run LINQ demo directly
dotnet run --project Feb10.csproj
```

### Expected Output Examples:

**LINQ Where Example:**
```
1. WHERE - Employees with Salary > 50000:
   Amit - $55,000.00
   Sneha - $60,000.00
   Vikram - $70,000.00
```

**LINQ GroupBy Example:**
```
5. GROUPBY - Employees by Department:
   IT: 3 employees
      - Amit
      - Raj
      - Vikram
   HR: 2 employees
      - Priya
      - Anjali
```

## 📚 Key LINQ Concepts

### Method Syntax vs Query Syntax

**Method Syntax (Lambda):**
```csharp
var result = employees
    .Where(e => e.Age > 25)
    .OrderBy(e => e.Name)
    .Select(e => e.Name);
```

**Query Syntax (SQL-like):**
```csharp
var result = from e in employees
             where e.Age > 25
             orderby e.Name
             select e.Name;
```

### Deferred Execution
- LINQ queries are not executed until enumerated
- Allows building complex queries step by step
- Executed when: `ToList()`, `ToArray()`, `foreach`, `Count()`, etc.

### Lambda Expressions
- Syntax: `(parameters) => expression`
- Used extensively in LINQ
- Can be single expression or statement block

## 🎓 Learning Path

1. **Start with Lambda.cs** - Understand lambda basics
2. **Run LinqDemo.cs** - See all LINQ operations
3. **Practice each operation** - Modify queries
4. **Combine operations** - Build complex queries

## 💡 Common Use Cases

### Filter and Sort:
```csharp
var result = employees
    .Where(e => e.Department == "IT")
    .OrderByDescending(e => e.Salary)
    .Take(5);
```

### Group and Aggregate:
```csharp
var deptSalaries = employees
    .GroupBy(e => e.Department)
    .Select(g => new {
        Department = g.Key,
        AvgSalary = g.Average(e => e.Salary),
        Count = g.Count()
    });
```

### Join Collections:
```csharp
var joined = employees.Join(
    departments,
    emp => emp.Department,
    dept => dept.Name,
    (emp, dept) => new { emp.Name, dept.Location }
);
```

## 🔍 LINQ Benefits

✅ **Readable**: SQL-like syntax
✅ **Type-safe**: Compile-time checking
✅ **IntelliSense**: IDE support
✅ **Consistent**: Same syntax for different data sources
✅ **Powerful**: Complex queries in few lines
✅ **Maintainable**: Easy to understand and modify

## 📝 Practice Exercises

Try modifying LinqDemo.cs to:
1. Find employees with salary between 45000 and 60000
2. Get average age by department
3. Find the youngest employee in each city
4. Count employees per city
5. Get employees whose names start with 'A'
6. Find departments with more than 2 employees
7. Calculate total salary by department
8. Get top 3 highest paid employees
9. Find employees older than average age
10. Group by city and show count

## 🛠️ Technologies Used

- C# 8.0+
- .NET Core/Framework
- System.Linq namespace
- Lambda expressions
- Anonymous types
- Extension methods
