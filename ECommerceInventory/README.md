# E-Commerce Inventory System with Generics

## Overview

A flexible inventory management system demonstrating advanced C# generics concepts. The system handles different product categories with varying attributes while maintaining type safety through generic constraints and interfaces.

## Project Structure

```
ECommerceInventory/
├── IProduct.cs                 # Base product interface
├── ElectronicProduct.cs        # Product implementations (4 types)
├── ProductRepository.cs        # Generic repository with constraints
├── DiscountedProduct.cs        # Generic wrapper for discounts
├── InventoryManager.cs         # Generic operations manager
├── Program.cs                  # Demonstration and testing
└── README.md                   # This file
```

## Key Concepts Demonstrated

### 1. Generic Constraints

**Interface Constraint**:
```csharp
public class ProductRepository<T> where T : class, IProduct
```
- `T` must be a reference type (`class`)
- `T` must implement `IProduct` interface
- Ensures type safety and access to interface members

### 2. Generic Methods

**Method with Predicate**:
```csharp
public IEnumerable<T> FindProducts(Func<T, bool> predicate)
```
- Accepts any function that takes `T` and returns `bool`
- Enables flexible filtering without knowing specific type

**Method with Delegate**:
```csharp
public void UpdatePrices<T>(List<T> products, Func<T, decimal> priceAdjuster) 
    where T : IProduct
```
- Generic method with constraint
- Accepts function to calculate new prices
- Type-safe price updates

### 3. Generic Wrapper Class

**DiscountedProduct<T>**:
```csharp
public class DiscountedProduct<T> where T : IProduct
{
    private T _product;
    private decimal _discountPercentage;
    
    public decimal DiscountedPrice => _product.Price * (1 - _discountPercentage / 100);
}
```
- Wraps any product type
- Calculates discounted price
- Maintains original product reference

### 4. Polymorphism with Generics

**Mixed Collections**:
```csharp
List<IProduct> mixedProducts = new List<IProduct>();
mixedProducts.AddRange(electronicRepo.GetAllProducts());
mixedProducts.AddRange(clothingRepo.GetAllProducts());
```
- Different generic types unified through interface
- Polymorphic behavior maintained

## Product Types

### 1. ElectronicProduct
```csharp
public class ElectronicProduct : IProduct
{
    public int WarrantyMonths { get; set; }
    public string Brand { get; set; }
}
```

### 2. ClothingProduct
```csharp
public class ClothingProduct : IProduct
{
    public string Size { get; set; }
    public string Color { get; set; }
}
```

### 3. BookProduct
```csharp
public class BookProduct : IProduct
{
    public string Author { get; set; }
    public string ISBN { get; set; }
}
```

### 4. GroceryProduct
```csharp
public class GroceryProduct : IProduct
{
    public DateTime ExpiryDate { get; set; }
    public double Weight { get; set; }
}
```

## Features

### 1. Product Repository (Generic)

**Add Product with Validation**:
```csharp
public void AddProduct(T product)
{
    // Validates:
    // - Unique ID
    // - Positive price
    // - Non-empty name
}
```

**Find Products**:
```csharp
// Find by brand
var appleProducts = repo.FindProducts(p => p.Brand == "Apple");

// Find by price range
var midRange = repo.FindProducts(p => p.Price >= 30 && p.Price <= 100);

// Find by category
var electronics = repo.FindProducts(p => p.Category == Category.Electronics);
```

**Calculate Total Value**:
```csharp
decimal total = repo.CalculateTotalValue();
```

### 2. Discount System

**Apply Discount**:
```csharp
var discounted = new DiscountedProduct<ElectronicProduct>(product, 20);
Console.WriteLine(discounted.DiscountedPrice); // 20% off
```

**Bulk Discounts**:
```csharp
var discountedItems = manager.ApplyDiscounts(
    products,
    p => p.Price > 500,  // Predicate
    10                    // 10% discount
);
```

### 3. Inventory Management

**Process Products**:
```csharp
manager.ProcessProducts(products);
// - Prints all products
// - Finds most expensive
// - Groups by category
// - Applies conditional discounts
```

**Update Prices**:
```csharp
manager.UpdatePrices(products, p => p.Price * 1.10m); // 10% increase
```

## How to Run

```bash
cd ECommerceInventory
dotnet build
dotnet run
```

## Sample Output

```
E-Commerce Inventory System with Generics

STEP 1: Adding Products with Validation
============================================================
Added: iPhone 15 Pro (ID: 1, Price: $999.99)
Added: Samsung Galaxy S24 (ID: 2, Price: $849.99)
Added: MacBook Pro (ID: 3, Price: $1999.99)
...

Testing Validation - Duplicate ID:
  Caught: Product with ID 1 already exists

Testing Validation - Negative Price:
  Caught: Price must be positive

STEP 2: Finding Products by Brand (Apple)
============================================================
  - iPhone 15 Pro - Apple ($999.99, 12 months warranty)
  - MacBook Pro - Apple ($1999.99, 12 months warranty)

STEP 3: Applying Discounts
============================================================
20% Discount on All Electronics:
  - iPhone 15 Pro - Original: $999.99, Discount: 20%, Final: $799.99 (Save $200.00)
  - Samsung Galaxy S24 - Original: $849.99, Discount: 20%, Final: $679.99 (Save $170.00)
  ...

STEP 4: Total Value Calculation
============================================================
Total Inventory Value (Before Discount): $4053.40
Discount on Electronics Over $500 (10%): -$385.00
Total Inventory Value (After Discount): $3668.40
Total Savings: $385.00

STEP 5: Processing Mixed Collection
============================================================
All Products:
  - iPhone 15 Pro: $999.99
  - Samsung Galaxy S24: $849.99
  - MacBook Pro: $1999.99
  - Cotton T-Shirt: $19.99
  - Clean Code: $39.99
  ...

Most Expensive: MacBook Pro ($1999.99)

Products by Category:
  Electronics:
    - iPhone 15 Pro ($999.99)
    - Samsung Galaxy S24 ($849.99)
    ...
```

## Validation Rules

### Product Addition
1. **Unique ID**: No duplicate product IDs allowed
2. **Positive Price**: Price must be > 0
3. **Non-Empty Name**: Name cannot be null or whitespace

### Discount Creation
1. **Valid Product**: Product cannot be null
2. **Discount Range**: Must be between 0 and 100

## Generic Advantages Demonstrated

### 1. Type Safety
```csharp
ProductRepository<ElectronicProduct> electronicRepo;
// Can only add ElectronicProduct instances
// Compile-time type checking
```

### 2. Code Reuse
```csharp
// Same repository code works for all product types
var electronicRepo = new ProductRepository<ElectronicProduct>();
var clothingRepo = new ProductRepository<ClothingProduct>();
var bookRepo = new ProductRepository<BookProduct>();
```

### 3. Flexibility
```csharp
// Generic methods work with any IProduct
public void ProcessProducts<T>(IEnumerable<T> products) where T : IProduct
{
    // Works with ElectronicProduct, ClothingProduct, etc.
}
```

### 4. Performance
- No boxing/unboxing (value types)
- No runtime type casting
- Compile-time optimization

## Advanced Patterns

### 1. Predicate Pattern
```csharp
// Flexible filtering
var results = repo.FindProducts(p => p.Price > 100 && p.Category == Category.Electronics);
```

### 2. Func Delegate Pattern
```csharp
// Custom price calculation
manager.UpdatePrices(products, p => {
    if (p.Category == Category.Electronics)
        return p.Price * 1.15m; // 15% increase
    return p.Price * 1.05m;     // 5% increase
});
```

### 3. LINQ with Generics
```csharp
// Complex queries
var expensive = products
    .Where(p => p.Price > 500)
    .OrderByDescending(p => p.Price)
    .Take(5);
```

### 4. Grouping
```csharp
// Group by category
var grouped = products.GroupBy(p => p.Category);
foreach (var group in grouped)
{
    Console.WriteLine($"{group.Key}: {group.Count()} items");
}
```

## Learning Objectives

After completing this project, you should understand:

1. ✅ **Generic Classes** with constraints
2. ✅ **Generic Methods** with type parameters
3. ✅ **Generic Constraints** (`where T : class, IProduct`)
4. ✅ **Interface-based Generics**
5. ✅ **Func<T, TResult>** delegates
6. ✅ **Predicate<T>** pattern
7. ✅ **LINQ with Generics**
8. ✅ **Type Safety** benefits
9. ✅ **Code Reusability** through generics
10. ✅ **Polymorphism** with generic types

## Common Generic Patterns

### 1. Repository Pattern
```csharp
public class Repository<T> where T : class, IEntity
{
    private List<T> _items = new List<T>();
    
    public void Add(T item) { }
    public T GetById(int id) { }
    public IEnumerable<T> GetAll() { }
}
```

### 2. Wrapper Pattern
```csharp
public class Wrapper<T>
{
    private T _value;
    public T Value => _value;
}
```

### 3. Factory Pattern
```csharp
public class Factory<T> where T : new()
{
    public T Create() => new T();
}
```

## Best Practices

1. **Use Constraints**: Limit generic types appropriately
2. **Meaningful Names**: Use descriptive type parameter names
3. **Interface Segregation**: Keep interfaces focused
4. **Validation**: Always validate generic inputs
5. **Documentation**: Document generic constraints
6. **Error Handling**: Handle exceptions gracefully

## Common Mistakes to Avoid

1. **Over-Generalization**: Don't make everything generic
2. **Missing Constraints**: Add constraints when needed
3. **Ignoring Validation**: Always validate inputs
4. **Complex Constraints**: Keep constraints simple
5. **Poor Naming**: Use clear type parameter names

## Extension Ideas

1. Add database persistence with Entity Framework
2. Implement caching layer
3. Add search functionality with Elasticsearch
4. Create REST API endpoints
5. Add inventory alerts (low stock)
6. Implement order management
7. Add supplier management
8. Create reporting dashboard
9. Add barcode scanning
10. Implement multi-warehouse support

## Performance Considerations

- **Generic Collections**: No boxing overhead
- **LINQ Queries**: Deferred execution
- **Memory**: Efficient type-specific storage
- **Compilation**: Optimized IL code generation

## Testing Scenarios Covered

1. ✅ Adding products with validation
2. ✅ Duplicate ID detection
3. ✅ Negative price validation
4. ✅ Empty name validation
5. ✅ Finding products by predicate
6. ✅ Applying discounts
7. ✅ Calculating total values
8. ✅ Processing mixed collections
9. ✅ Bulk price updates
10. ✅ Advanced queries (grouping, filtering)

## Technologies Used

- **Language**: C# 10.0
- **Framework**: .NET 10.0
- **Concepts**: Generics, LINQ, Delegates, Interfaces
- **Patterns**: Repository, Wrapper, Strategy

## Comparison: Generic vs Non-Generic

| Aspect | Generic | Non-Generic |
|--------|---------|-------------|
| Type Safety | Compile-time | Runtime |
| Performance | No boxing | Boxing overhead |
| Code Reuse | High | Low |
| Flexibility | High | Medium |
| Complexity | Medium | Low |

---

**Project Type**: Console Application  
**Difficulty**: Intermediate to Advanced  
**Focus**: C# Generics & Type Safety  
**Estimated Time**: 3-4 hours  
**Prerequisites**: Understanding of OOP, Interfaces, LINQ
