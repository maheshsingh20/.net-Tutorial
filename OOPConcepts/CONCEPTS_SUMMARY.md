# OOP Concepts - Quick Reference Guide

## 1. Classes and Objects

**Class**: Blueprint/template for creating objects
```csharp
public class Person
{
    // Fields (data)
    private string name;
    
    // Properties (controlled access)
    public string Name { get; set; }
    
    // Constructor (initialization)
    public Person(string name) { this.name = name; }
    
    // Methods (behavior)
    public void Introduce() { }
}
```

**Object**: Instance of a class
```csharp
Person person = new Person("Alice");
```

---

## 2. Encapsulation

**Definition**: Bundling data and methods, hiding internal details

**Purpose**: Data protection, controlled access

```csharp
public class BankAccount
{
    private double balance;  // Hidden
    
    public void Deposit(double amount)  // Controlled access
    {
        if (amount > 0) balance += amount;
    }
}
```

**Benefits**:
- Data security
- Flexibility to change implementation
- Validation and business logic

---

## 3. Inheritance

**Definition**: Creating new classes from existing classes

**Syntax**: `class Child : Parent`

```csharp
public class Animal
{
    public void Eat() { }
}

public class Dog : Animal  // Dog inherits from Animal
{
    public void Bark() { }
}
```

**Types**:
- **Single**: One parent → one child
- **Multi-level**: Parent → Child → Grandchild
- **Hierarchical**: One parent → multiple children

---

## 4. Polymorphism

**Definition**: "Many forms" - same interface, different implementations

### A) Compile-time (Method Overloading)
Same method name, different parameters
```csharp
public int Add(int a, int b) { }
public double Add(double a, double b) { }
```

### B) Runtime (Method Overriding)
Redefining parent method in child
```csharp
public class Shape
{
    public virtual void Draw() { }  // Virtual
}

public class Circle : Shape
{
    public override void Draw() { }  // Override
}
```

---

## 5. Abstraction

**Definition**: Hiding complexity, showing only essentials

### Abstract Class
Cannot be instantiated, can have abstract and concrete methods
```csharp
public abstract class Vehicle
{
    public abstract void Start();  // Must be implemented
    public void Stop() { }         // Can be inherited as-is
}

public class Car : Vehicle
{
    public override void Start() { }  // Must implement
}
```

---

## 6. Interface

**Definition**: Pure abstraction, contract for implementation

```csharp
public interface IPlayable
{
    void Play();
    void Stop();
}

public class MediaPlayer : IPlayable
{
    public void Play() { }
    public void Stop() { }
}
```

**Features**:
- Only method signatures (no implementation)
- Supports multiple inheritance
- All members public by default

**Interface vs Abstract Class**:
| Interface | Abstract Class |
|-----------|---------------|
| Only signatures | Can have implementation |
| Multiple inheritance | Single inheritance |
| No fields | Can have fields |
| No constructors | Can have constructors |

---

## 7. Static Members

**Definition**: Belongs to class, not instances

```csharp
public class MathUtility
{
    public static double PI = 3.14159;  // Static field
    
    public static int Add(int a, int b)  // Static method
    {
        return a + b;
    }
}

// Access using class name
double result = MathUtility.Add(5, 10);
```

**Static Class**: Cannot be instantiated, only static members
```csharp
public static class StringHelper
{
    public static string Reverse(string s) { }
}
```

---

## 8. Properties

**Definition**: Controlled access to private fields with get/set

```csharp
public class Student
{
    private int age;
    
    // Full property with validation
    public int Age
    {
        get { return age; }
        set 
        { 
            if (value >= 0 && value <= 100)
                age = value;
        }
    }
    
    // Auto-property
    public string Name { get; set; }
    
    // Read-only property
    public string Status { get; }
}
```

---

## 9. Constructors

**Definition**: Special method for object initialization

```csharp
public class Product
{
    // Default constructor
    public Product() { }
    
    // Parameterized constructor
    public Product(string name, double price) { }
    
    // Copy constructor
    public Product(Product other) { }
    
    // Static constructor (called once)
    static Product() { }
}
```

**Constructor Chaining**: Using `this` keyword
```csharp
public Employee() : this("Unknown", 0) { }
public Employee(string name, int id) { }
```

---

## 10. Method Overriding

**Definition**: Redefining parent method in child class

```csharp
public class Employee
{
    public virtual double CalculateSalary()  // Virtual
    {
        return baseSalary;
    }
}

public class Manager : Employee
{
    public override double CalculateSalary()  // Override
    {
        return baseSalary + bonus;
    }
}
```

**Keywords**:
- `virtual`: Method can be overridden
- `override`: Provides new implementation
- `base`: Calls parent class method

---

## 11. Access Modifiers

Control visibility and accessibility

| Modifier | Access Level |
|----------|-------------|
| `public` | Everywhere |
| `private` | Only within class |
| `protected` | Class and derived classes |
| `internal` | Within same assembly |
| `protected internal` | Assembly OR derived classes |

```csharp
public class Example
{
    public int PublicField;        // Accessible everywhere
    private int PrivateField;      // Only in this class
    protected int ProtectedField;  // This class + derived
    internal int InternalField;    // Same assembly
}
```

---

## 12. Sealed Class/Method

**Definition**: Prevents inheritance and overriding

```csharp
// Sealed class: Cannot be inherited
public sealed class FinalClass
{
    public void Method() { }
}

// Sealed method: Cannot be overridden further
public class Animal
{
    public virtual void MakeSound() { }
}

public class Dog : Animal
{
    public sealed override void MakeSound() { }
}

public class Puppy : Dog
{
    // ERROR: Cannot override sealed method
    // public override void MakeSound() { }
}
```

---

## Four Pillars of OOP

1. **Encapsulation**: Data hiding and bundling
2. **Inheritance**: Code reusability
3. **Polymorphism**: Same interface, different behaviors
4. **Abstraction**: Hiding complexity

---

## When to Use What?

| Concept | Use When |
|---------|----------|
| **Class** | Creating objects with data and behavior |
| **Encapsulation** | Protecting data, providing controlled access |
| **Inheritance** | Creating specialized versions of existing classes |
| **Polymorphism** | Same operation, different implementations |
| **Abstract Class** | Partial implementation, shared code |
| **Interface** | Pure contract, multiple inheritance needed |
| **Static** | Utility functions, shared data |
| **Sealed** | Preventing further inheritance |

---

## Best Practices

1. **Encapsulate** data using private fields and public properties
2. **Favor composition** over inheritance when possible
3. **Program to interfaces**, not implementations
4. Use **abstract classes** for shared implementation
5. Use **interfaces** for contracts and capabilities
6. Make classes **sealed** when inheritance is not intended
7. Use **static** for utility methods and constants
8. **Validate** data in property setters
9. Use **virtual/override** for runtime polymorphism
10. Follow **SOLID principles**

---

## Common Patterns

### Factory Pattern (Static Method)
```csharp
public static class ShapeFactory
{
    public static Shape CreateShape(string type)
    {
        if (type == "Circle") return new Circle();
        if (type == "Rectangle") return new Rectangle();
        return null;
    }
}
```

### Template Method (Abstract Class)
```csharp
public abstract class DataProcessor
{
    public void Process()
    {
        LoadData();
        ProcessData();
        SaveData();
    }
    
    protected abstract void ProcessData();
    protected void LoadData() { }
    protected void SaveData() { }
}
```

### Strategy Pattern (Interface)
```csharp
public interface IPaymentStrategy
{
    void Pay(double amount);
}

public class CreditCardPayment : IPaymentStrategy
{
    public void Pay(double amount) { }
}

public class PayPalPayment : IPaymentStrategy
{
    public void Pay(double amount) { }
}
```
