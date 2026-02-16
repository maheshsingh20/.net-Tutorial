# HealthSync Advanced Billing System

## Overview

HealthSync is a medical consultant payroll automation system for Machine Masters. It demonstrates advanced Object-Oriented Programming concepts including abstraction, polymorphism, and virtual methods to handle complex payroll logic with multi-tier taxation (TDS).

## Project Structure

```
Feb14Practise2/
├── Consultant.cs              # Abstract base class
├── InHouseConsultant.cs       # Stipend-based consultant
├── VisitingConsultant.cs      # Visit-based consultant
├── Program.cs                 # Main application with menu
└── README.md                  # This file
```

## Architecture

### Class Hierarchy

```
Consultant (Abstract)
├── Properties:
│   ├── ConsultantId: string
│   └── Name: string
├── Methods:
│   ├── ValidateConsultantId(): bool (private)
│   ├── CalculateGrossPayout(): decimal (abstract)
│   ├── CalculateTDS(decimal): decimal (virtual)
│   ├── CalculateNetPayout(): decimal
│   ├── DisplayPayoutDetails(): void
│   └── GetConsultantType(): string (abstract)
│
├── InHouseConsultant
│   ├── MonthlyStipend: decimal
│   ├── CalculateGrossPayout(): decimal (override)
│   └── GetConsultantType(): string (override)
│   └── Uses inherited CalculateTDS() (sliding scale)
│
└── VisitingConsultant
    ├── ConsultationsCount: int
    ├── RatePerVisit: decimal
    ├── CalculateGrossPayout(): decimal (override)
    ├── CalculateTDS(decimal): decimal (override - flat 10%)
    └── GetConsultantType(): string (override)
```

## Core OOP Concepts

### 1. Abstraction

**Purpose**: Prevent creation of generic consultants

```csharp
public abstract class Consultant
{
    // Abstract method - must be implemented by derived classes
    public abstract decimal CalculateGrossPayout();
    
    // Abstract method for type identification
    public abstract string GetConsultantType();
}
```

**Why Abstract?**
- Every consultant must be either In-House or Visiting
- Forces subclasses to define their own payout calculation
- Provides common structure while allowing specialization

### 2. Polymorphism

**Method Overriding**: Each consultant type has its own calculation

```csharp
// In-House calculation
public override decimal CalculateGrossPayout()
{
    decimal allowances = MonthlyStipend * 0.20m; // 20%
    decimal bonuses = 1000m; // Fixed
    return MonthlyStipend + allowances + bonuses;
}

// Visiting calculation
public override decimal CalculateGrossPayout()
{
    return ConsultationsCount * RatePerVisit;
}
```

### 3. Virtual Methods

**Default Implementation with Override Option**

```csharp
// Base class - default sliding scale
public virtual decimal CalculateTDS(decimal grossPayout)
{
    if (grossPayout <= 5000)
        return 0.05m; // 5%
    else
        return 0.15m; // 15%
}

// Visiting consultant - overrides to flat rate
public override decimal CalculateTDS(decimal grossPayout)
{
    return 0.10m; // Flat 10%
}
```

## Validation Rules

### Consultant ID Format

**Rules**:
- Length: Exactly 6 characters
- Prefix: Must start with "DR"
- Suffix: Last 4 characters must be numeric

**Valid Examples**:
- DR2001 ✓
- DR8005 ✓
- DR3001 ✓
- DR9999 ✓

**Invalid Examples**:
- MD1001 ✗ (wrong prefix)
- DR123 ✗ (too short)
- DR12345 ✗ (too long)
- DRABC1 ✗ (non-numeric suffix)
- dr2001 ✗ (lowercase)

**Implementation**:
```csharp
private bool ValidateConsultantId(string id)
{
    if (string.IsNullOrEmpty(id) || id.Length != 6)
        return false;

    if (!id.StartsWith("DR"))
        return false;

    string numericPart = id.Substring(2);
    return int.TryParse(numericPart, out _);
}
```

## Payout Calculations

### In-House Consultant

**Formula**:
```
Allowances = MonthlyStipend × 0.20
Bonuses = ₹1,000 (Fixed)
Gross Payout = MonthlyStipend + Allowances + Bonuses
```

**TDS (Sliding Scale)**:
```
If Gross ≤ ₹5,000:  TDS = 5%
If Gross > ₹5,000:  TDS = 15%
```

**Net Payout**:
```
Net = Gross - (Gross × TDS Rate)
```

**Example**:
```
Stipend: ₹10,000
Allowances: ₹10,000 × 0.20 = ₹2,000
Bonuses: ₹1,000
Gross: ₹10,000 + ₹2,000 + ₹1,000 = ₹13,000
TDS: 15% (since ₹13,000 > ₹5,000)
TDS Amount: ₹13,000 × 0.15 = ₹1,950
Net: ₹13,000 - ₹1,950 = ₹11,050
```

### Visiting Consultant

**Formula**:
```
Gross Payout = ConsultationsCount × RatePerVisit
```

**TDS (Flat Rate)**:
```
TDS = 10% (always)
```

**Net Payout**:
```
Net = Gross - (Gross × 0.10)
```

**Example**:
```
Consultations: 10
Rate: ₹600
Gross: 10 × ₹600 = ₹6,000
TDS: 10% (flat)
TDS Amount: ₹6,000 × 0.10 = ₹600
Net: ₹6,000 - ₹600 = ₹5,400
```

## Taxation Table

| Consultant Type | Gross Payout | TDS Rate | Calculation Method |
|----------------|--------------|----------|-------------------|
| In-House | ≤ ₹5,000 | 5% | Sliding Scale |
| In-House | > ₹5,000 | 15% | Sliding Scale |
| Visiting | Any Amount | 10% | Flat Rate |

## How to Run

### Build and Run
```bash
cd Feb14Practise2
dotnet build
dotnet run
```

### Menu Options

```
Main Menu:
1. Process In-House Consultant
2. Process Visiting Consultant
3. Run All Test Scenarios
0. Exit
```

### Option 1: Process In-House Consultant

**Input Prompts**:
```
Enter Consultant ID (e.g., DR2001): DR2001
Enter Name: Dr. Sarah Johnson
Enter Monthly Stipend: 10000
```

**Output**:
```
Payout Details for Dr. Sarah Johnson (DR2001)
Consultant Type: In-House Consultant
Gross Payout: 13000.00
TDS Applied: 15.00%
Net Payout: 11050.00
```

### Option 2: Process Visiting Consultant

**Input Prompts**:
```
Enter Consultant ID (e.g., DR8005): DR8005
Enter Name: Dr. Michael Chen
Enter Number of Consultations: 10
Enter Rate Per Visit: 600
```

**Output**:
```
Payout Details for Dr. Michael Chen (DR8005)
Consultant Type: Visiting Consultant
Gross Payout: 6000.00
TDS Applied: 10.00%
Net Payout: 5400.00
```

### Option 3: Run All Test Scenarios

Executes 6 predefined test scenarios:
1. In-House High Earner (15% TDS)
2. Visiting Consultant (10% TDS)
3. Validation Failure (Invalid ID)
4. In-House Low Earner (5% TDS)
5. At Threshold Test
6. Multiple Validation Failures

## Test Scenarios

### Scenario 1: In-House Consultant (High Earner)

**Input**:
```
ID: DR2001
Name: Dr. Sarah Johnson
Stipend: ₹10,000
```

**Process**:
```
Allowances: ₹10,000 × 0.20 = ₹2,000
Bonuses: ₹1,000
Gross: ₹10,000 + ₹2,000 + ₹1,000 = ₹13,000
TDS: 15% (since ₹13,000 > ₹5,000)
Net: ₹13,000 - (₹13,000 × 0.15) = ₹11,050
```

**Output**:
```
Payout Details for Dr. Sarah Johnson (DR2001)
Consultant Type: In-House Consultant
Gross Payout: 13000.00
TDS Applied: 15.00%
Net Payout: 11050.00
```

### Scenario 2: Visiting Consultant

**Input**:
```
ID: DR8005
Name: Dr. Michael Chen
Consultations: 10
Rate: ₹600
```

**Process**:
```
Gross: 10 × ₹600 = ₹6,000
TDS: 10% (flat)
Net: ₹6,000 - (₹6,000 × 0.10) = ₹5,400
```

**Output**:
```
Payout Details for Dr. Michael Chen (DR8005)
Consultant Type: Visiting Consultant
Gross Payout: 6000.00
TDS Applied: 10.00%
Net Payout: 5400.00
```

### Scenario 3: Validation Failure

**Input**:
```
ID: MD1001
Name: Dr. Invalid
Stipend: ₹5,000
```

**Output**:
```
Invalid doctor id
```

**Reason**: ID must start with "DR", not "MD"

### Scenario 4: In-House Consultant (Low Earner)

**Input**:
```
ID: DR3001
Name: Dr. Emily Brown
Stipend: ₹3,000
```

**Process**:
```
Allowances: ₹3,000 × 0.20 = ₹600
Bonuses: ₹1,000
Gross: ₹3,000 + ₹600 + ₹1,000 = ₹4,600
TDS: 5% (since ₹4,600 ≤ ₹5,000)
Net: ₹4,600 - (₹4,600 × 0.05) = ₹4,370
```

**Output**:
```
Payout Details for Dr. Emily Brown (DR3001)
Consultant Type: In-House Consultant
Gross Payout: 4600.00
TDS Applied: 5.00%
Net Payout: 4370.00
```

### Scenario 5: At Threshold

**Input**:
```
ID: DR4001
Name: Dr. James Wilson
Stipend: ₹3,333.33
```

**Process**:
```
Allowances: ₹3,333.33 × 0.20 = ₹666.67
Bonuses: ₹1,000
Gross: ₹3,333.33 + ₹666.67 + ₹1,000 = ₹5,000.00
TDS: 5% (since ₹5,000 ≤ ₹5,000)
Net: ₹5,000 - (₹5,000 × 0.05) = ₹4,750
```

**Output**:
```
Payout Details for Dr. James Wilson (DR4001)
Consultant Type: In-House Consultant
Gross Payout: 5000.00
TDS Applied: 5.00%
Net Payout: 4750.00
```

### Scenario 6: Validation Failures

**Test 6a: ID too short**
```
Input: DR123
Output: Invalid doctor id
```

**Test 6b: Wrong prefix**
```
Input: AB1234
Output: Invalid doctor id
```

**Test 6c: Non-numeric suffix**
```
Input: DRABC1
Output: Invalid doctor id
```

## Code Walkthrough

### Creating Consultants

```csharp
// In-House Consultant
var inHouse = new InHouseConsultant("DR2001", "Dr. Sarah", 10000);

// Visiting Consultant
var visiting = new VisitingConsultant("DR8005", "Dr. Michael", 10, 600);
```

### Polymorphic Behavior

```csharp
// Both use the same interface but different implementations
Consultant consultant1 = new InHouseConsultant("DR2001", "Dr. Sarah", 10000);
Consultant consultant2 = new VisitingConsultant("DR8005", "Dr. Michael", 10, 600);

// Calls appropriate override
decimal gross1 = consultant1.CalculateGrossPayout(); // In-House formula
decimal gross2 = consultant2.CalculateGrossPayout(); // Visiting formula

// Different TDS calculations
decimal tds1 = consultant1.CalculateTDS(gross1); // Sliding scale
decimal tds2 = consultant2.CalculateTDS(gross2); // Flat 10%
```

### Exception Handling

```csharp
try
{
    var consultant = new InHouseConsultant("MD1001", "Invalid", 5000);
}
catch (ArgumentException ex)
{
    Console.WriteLine(ex.Message); // "Invalid doctor id"
}
```

## Key Learning Objectives

After completing this project, you should understand:

1. ✅ **Abstraction**: Creating abstract base classes
2. ✅ **Polymorphism**: Method overriding for specialized behavior
3. ✅ **Virtual Methods**: Default implementation with override option
4. ✅ **Inheritance**: Code reuse through base classes
5. ✅ **Encapsulation**: Private validation methods
6. ✅ **Exception Handling**: Throwing and catching exceptions
7. ✅ **Business Logic**: Complex calculation formulas
8. ✅ **Validation**: Input validation at constructor level

## Design Patterns

### Template Method Pattern

The `Consultant` class defines the template for payout calculation:

```csharp
public decimal CalculateNetPayout()
{
    decimal gross = CalculateGrossPayout();    // Implemented by subclass
    decimal tdsRate = CalculateTDS(gross);     // Can be overridden
    decimal tdsAmount = gross * tdsRate;
    return gross - tdsAmount;
}
```

### Strategy Pattern

Different TDS calculation strategies:
- In-House: Sliding scale strategy
- Visiting: Flat rate strategy

## Common Mistakes to Avoid

1. **ID Validation**: Must be exactly 6 characters, not more or less
2. **Prefix Case**: "DR" must be uppercase
3. **TDS Threshold**: ≤ 5000 uses 5%, > 5000 uses 15%
4. **Allowances**: 20% of stipend, not 20 rupees
5. **Bonuses**: Fixed ₹1000, not percentage

## Extension Ideas

1. Add more consultant types (Part-Time, Contract)
2. Implement bonus calculation based on performance
3. Add database persistence
4. Create monthly payroll reports
5. Add email notifications
6. Implement payment history tracking
7. Add tax certificate generation
8. Create admin dashboard

## Technologies Used

- **Language**: C# 10.0
- **Framework**: .NET 10.0
- **Concepts**: OOP, Abstraction, Polymorphism, Virtual Methods
- **Pattern**: Template Method, Strategy

## Comparison: In-House vs Visiting

| Aspect | In-House | Visiting |
|--------|----------|----------|
| **Base Pay** | Monthly Stipend | Per Visit Rate |
| **Allowances** | 20% of Stipend | None |
| **Bonuses** | ₹1,000 Fixed | None |
| **TDS** | 5% or 15% (Sliding) | 10% (Flat) |
| **Calculation** | Complex | Simple |
| **Predictability** | Fixed Monthly | Variable |

## Performance Considerations

- Validation happens at construction time
- Calculations are performed on-demand
- No database calls (in-memory only)
- Lightweight objects

## Testing Checklist

- [ ] Valid In-House consultant with high stipend
- [ ] Valid In-House consultant with low stipend
- [ ] Valid Visiting consultant
- [ ] Invalid ID (wrong prefix)
- [ ] Invalid ID (wrong length)
- [ ] Invalid ID (non-numeric suffix)
- [ ] Negative stipend
- [ ] Negative consultations
- [ ] Negative rate
- [ ] Threshold boundary (exactly ₹5000)

---

**Project Type**: Console Application  
**Difficulty**: Advanced  
**Focus**: OOP Principles & Polymorphism  
**Estimated Time**: 3-4 hours  
**Prerequisites**: Understanding of OOP concepts
