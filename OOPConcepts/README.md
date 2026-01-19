# Object-Oriented Programming (OOP) Concepts in C#

A comprehensive project demonstrating all major OOP concepts with detailed explanations and practical examples.

## Project Structure

```
OOPConcepts/
├── 1_ClassesAndObjects/
│   └── BasicClass.cs           # Classes, Objects, Fields, Properties, Methods
│
├── 2_Encapsulation/
│   └── EncapsulationDemo.cs    # Data hiding, Access control
│
├── 3_Inheritance/
│   └── InheritanceDemo.cs      # Single, Multi-level, Hierarchical inheritance
│
├── 4_Polymorphism/
│   └── PolymorphismDemo.cs     # Method Overloading, Method Overriding
│
├── 5_Abstraction/
│   └── AbstractionDemo.cs      # Abstract classes, Abstract methods
│
├── 6_Interface/
│   └── InterfaceDemo.cs        # Interface implementation, Multiple inheritance
│
├── 7_StaticMembers/
│   └── StaticDemo.cs           # Static fields, methods, classes, constructors
│
├── 8_Properties/
│   └── PropertiesDemo.cs       # Get/Set accessors, Validation, Auto-properties
│
├── 9_Constructors/
│   └── ConstructorDemo.cs      # Default, Parameterized, Copy, Static constructors
│
├── 10_MethodOverriding/
│   └── MethodOverridingDemo.cs # Virtual, Override, Base keyword
│
├── 11_AccessModifiers/
│   └── AccessModifiersDemo.cs  # Public, Private, Protected, Internal
│
├── 12_SealedClass/
│   └── SealedDemo.cs           # Sealed classes and methods
│
└── Program.cs                   # Main entry point
```

## OOP Concepts Covered

### 1. Classes and Objects
- **Class**: Blueprint for creating objects
- **Object**: Instance of a class
- **Fields**: Variables that store data
- **Properties**: Controlled access to fields
- **Methods**: Functions that define behavior
- **Constructors**: Initialize objects

### 2. Encapsulation
- **Definition**: Bundling data and methods together
- **Purpose**: Hide internal details, provide controlled access
- **Benefits**: Data protection, flexibility, maintainability
- **Implementation**: Access modifiers, properties

### 3. Inheritance
- **Definition**: Creating new classes from existing classes
- **Types**: 
  - Single: One parent, one child
  - Multi-level: Chain of inheritance
  - Hierarchical: Multiple children from one parent
- **Benefits**: Code reusability, extensibility

### 4. Polymorphism
- **Definition**: "Many forms" - same interface, different implementations
- **Types**:
  - **Compile-time**: Method Overloading (same name, different parameters)
  - **Runtime**: Method Overriding (virtual/override keywords)

### 5. Abstraction
- **Definition**: Hiding complexity, showing only essential features
- **Abstract Class**: Cannot be instantiated, can have abstract and concrete methods
- **Abstract Method**: No implementation, must be overridden
- **Purpose**: Define contract for derived classes

### 6. Interface
- **Definition**: Pure abstraction, contract for implementation
- **Features**:
  - Only method signatures (no implementation)
  - Supports multiple inheritance
  - All members are public by default
- **Use**: Define capabilities that classes must implement

### 7. Static Members
- **Static Field**: Shared across all instances
- **Static Method**: Belongs to class, not instances
- **Static Class**: Cannot be instantiated, only static members
- **Static Constructor**: Called once before any instance
- **Access**: Using class name, not object reference

### 8. Properties
- **Definition**: Provide controlled access to private fields
- **Get Accessor**: Retrieves value
- **Set Accessor**: Assigns value with validation
- **Auto-property**: Shorthand syntax
- **Read-only**: Only get accessor
- **Calculated**: Computed from other values

### 9. Constructors
- **Default**: No parameters
- **Parameterized**: With parameters
- **Copy**: Creates copy of existing object
- **Static**: Initializes static members
- **Constructor Chaining**: Calling one constructor from another (this keyword)

### 10. Method Overriding
- **Virtual**: Method that can be overridden
- **Override**: Provides new implementation in derived class
- **Base**: Calls parent class method
- **Purpose**: Runtime polymorphism

### 11. Access Modifiers
- **public**: Accessible everywhere
- **private**: Only within the class
- **protected**: Within class and derived classes
- **internal**: Within same assembly
- **protected internal**: Within assembly OR derived classes

### 12. Sealed Class/Method
- **Sealed Class**: Cannot be inherited
- **Sealed Method**: Cannot be overridden further
- **Purpose**: Prevent further derivation, improve performance

## How to Run

```bash
# Build the project
dotnet build

# Run the project
dotnet run
```

## Key Concepts Explained

### Four Pillars of OOP
1. **Encapsulation**: Data hiding and bundling
2. **Inheritance**: Code reusability through parent-child relationships
3. **Polymorphism**: Same interface, different behaviors
4. **Abstraction**: Hiding complexity, showing essentials

### Benefits of OOP
- **Modularity**: Code organized in classes
- **Reusability**: Inheritance and composition
- **Flexibility**: Polymorphism and interfaces
- **Maintainability**: Encapsulation and abstraction
- **Scalability**: Easy to extend and modify

## Learning Path

1. Start with **Classes and Objects** - Foundation
2. Learn **Encapsulation** - Data protection
3. Understand **Inheritance** - Code reuse
4. Master **Polymorphism** - Flexibility
5. Explore **Abstraction** and **Interfaces** - Design
6. Study **Static Members** - Class-level features
7. Practice **Properties** and **Constructors** - Best practices
8. Advanced: **Method Overriding**, **Access Modifiers**, **Sealed**

## Real-World Applications

- **Banking System**: Encapsulation for account security
- **Employee Management**: Inheritance for different employee types
- **Shape Drawing**: Polymorphism for different shapes
- **Payment Processing**: Interfaces for multiple payment methods
- **Utility Classes**: Static members for helper functions
