# SmartBank - Customer Credit Risk Evaluation System

## Overview

SmartBank is a banking platform that evaluates customer financial stability and determines the maximum credit limit that can be offered. The system validates customer financial data and applies risk-based calculations with robust custom exception handling.

## Project Structure

```
13THFEB/
├── Questions/
│   ├── CreditRiskProcessor.cs      # Validation and calculation logic
│   ├── InvalidCreditDataException.cs # Custom exception
│   └── UserInterface.cs             # Main entry point
└── Program.cs                       # Application launcher
```

## Components

### 1. CreditRiskProcessor (Utility Class)

**Purpose**: Validates customer data and calculates credit limits

**Methods**:

#### ValidateCustomerDetails()
```csharp
public static bool ValidateCustomerDetails(
    int age, 
    string employmentType, 
    double monthlyIncome, 
    double dues, 
    int creditScore, 
    int defaults
)
```

**Validation Rules**:

| Field | Rule | Error Message |
|-------|------|---------------|
| Age | 21-65 (inclusive) | "Invalid age" |
| Employment Type | "Salaried" or "Self-Employed" | "Invalid employment type" |
| Monthly Income | ≥ ₹20,000 | "Invalid monthly income" |
| Credit Dues | ≥ 0 | "Invalid credit dues" |
| Credit Score | 300-900 | "Invalid credit score" |
| Loan Defaults | ≥ 0 | "Invalid default count" |

#### CalculateCreditLimit()
```csharp
public static int CalculateCreditLimit(
    double monthlyIncome, 
    double dues, 
    int creditScore, 
    int defaults
)
```

**Credit Limit Calculation**:

**Step 1: Calculate Debt Ratio**
```
Debt Ratio = Existing Dues / (Monthly Income × 12)
```

**Step 2: Determine Risk Category**

**High Risk → ₹50,000**
- Credit Score < 600 OR
- Defaults ≥ 3 OR
- Debt Ratio > 0.4

**Low Risk → ₹3,00,000**
- Credit Score ≥ 750 AND
- Defaults = 0 AND
- Debt Ratio < 0.25

**Medium Risk → ₹1,50,000**
- All other cases

### 2. InvalidCreditDataException

**Purpose**: Custom checked exception for validation failures

```csharp
public class InvalidCreditDataException : Exception
{
    public InvalidCreditDataException(string message) : base(message) { }
}
```

**When Thrown**:
- Any validation rule fails
- Invalid input detected
- Business rule violation

### 3. UserInterface

**Purpose**: Main class that handles user interaction

**Flow**:
1. Accept customer details via Scanner
2. Call `ValidateCustomerDetails()`
3. If valid → Call `CalculateCreditLimit()` and display
4. If invalid → Catch exception and display error message

## How to Run

```bash
cd 13THFEB
dotnet build
dotnet run
```

## Test Cases

### Test Case 1: Valid (Low Risk)

**Input**:
```
Enter customer name: Arjun
Enter age: 35
Enter employment type: Salaried
Enter monthly income: 80000
Enter existing credit dues: 100000
Enter credit score: 820
Enter number of loan defaults: 0
```

**Calculation**:
```
Debt Ratio = 100000 / (80000 × 12) = 0.104 (10.4%)
Risk Check:
  - Credit Score: 820 ≥ 750 ✓
  - Defaults: 0 = 0 ✓
  - Debt Ratio: 0.104 < 0.25 ✓
Result: Low Risk
```

**Output**:
```
Customer Name: Arjun
Approved Credit Limit: ₹300000
```

### Test Case 2: Valid (Medium Risk)

**Input**:
```
Enter customer name: Neha
Enter age: 42
Enter employment type: Self-Employed
Enter monthly income: 60000
Enter existing credit dues: 200000
Enter credit score: 690
Enter number of loan defaults: 1
```

**Calculation**:
```
Debt Ratio = 200000 / (60000 × 12) = 0.278 (27.8%)
Risk Check:
  - Credit Score: 690 (not ≥ 750)
  - Defaults: 1 (not 0)
Result: Medium Risk
```

**Output**:
```
Customer Name: Neha
Approved Credit Limit: ₹150000
```

### Test Case 3: Valid (High Risk)

**Input**:
```
Enter customer name: Rakesh
Enter age: 50
Enter employment type: Salaried
Enter monthly income: 45000
Enter existing credit dues: 300000
Enter credit score: 560
Enter number of loan defaults: 3
```

**Calculation**:
```
Debt Ratio = 300000 / (45000 × 12) = 0.556 (55.6%)
Risk Check:
  - Credit Score: 560 < 600 ✓ (High Risk)
  - Defaults: 3 ≥ 3 ✓ (High Risk)
  - Debt Ratio: 0.556 > 0.4 ✓ (High Risk)
Result: High Risk
```

**Output**:
```
Customer Name: Rakesh
Approved Credit Limit: ₹50000
```

### Test Case 4: Invalid Age

**Input**:
```
Enter customer name: Pooja
Enter age: 19
Enter employment type: Salaried
Enter monthly income: 50000
Enter existing credit dues: 0
Enter credit score: 720
Enter number of loan defaults: 0
```

**Output**:
```
Invalid age
```

### Test Case 5: Invalid Employment Type

**Input**:
```
Enter customer name: Sandeep
Enter age: 40
Enter employment type: Contract
Enter monthly income: 70000
Enter existing credit dues: 100000
Enter credit score: 780
Enter number of loan defaults: 0
```

**Output**:
```
Invalid employment type
```

### Test Case 6: Invalid Monthly Income

**Input**:
```
Enter customer name: Anjali
Enter age: 30
Enter employment type: Salaried
Enter monthly income: 15000
Enter existing credit dues: 50000
Enter credit score: 750
Enter number of loan defaults: 0
```

**Output**:
```
Invalid monthly income
```

### Test Case 7: Invalid Credit Score

**Input**:
```
Enter customer name: Mohit
Enter age: 45
Enter employment type: Self-Employed
Enter monthly income: 90000
Enter existing credit dues: 200000
Enter credit score: 950
Enter number of loan defaults: 0
```

**Output**:
```
Invalid credit score
```

### Test Case 8: Invalid Default Count

**Input**:
```
Enter customer name: Rina
Enter age: 37
Enter employment type: Salaried
Enter monthly income: 65000
Enter existing credit dues: 120000
Enter credit score: 740
Enter number of loan defaults: -1
```

**Output**:
```
Invalid default count
```

## Key Concepts Demonstrated

### 1. Custom Exception Handling
- Creating custom exception classes
- Throwing exceptions on validation failure
- Catching and handling exceptions gracefully

### 2. Input Validation
- Multi-field validation
- Range checking
- String matching
- Business rule enforcement

### 3. Business Logic
- Complex calculation formulas
- Multi-condition decision making
- Risk assessment algorithms

### 4. Static Utility Methods
- Stateless utility functions
- Reusable validation logic
- Separation of concerns

## Code Walkthrough

### Validation Example

```csharp
// Age validation
if (age < 21 || age > 65)
{
    throw new InvalidCreditDataException("Invalid age");
}

// Employment type validation (case-sensitive)
if (employmentType != "Salaried" && employmentType != "Self-Employed")
{
    throw new InvalidCreditDataException("Invalid employment type");
}
```

### Credit Limit Calculation Example

```csharp
public static int CalculateCreditLimit(double monthlyIncome, double dues, 
                                       int creditScore, int defaults)
{
    // Calculate debt ratio
    double debtRatio = dues / (monthlyIncome * 12);

    // Check High Risk conditions
    if (creditScore < 600 || defaults >= 3 || debtRatio > 0.4)
    {
        return 50000;
    }

    // Check Low Risk conditions
    if (creditScore >= 750 && defaults == 0 && debtRatio < 0.25)
    {
        return 300000;
    }

    // Default to Medium Risk
    return 150000;
}
```

### Exception Handling Example

```csharp
try
{
    CreditRiskProcessor.ValidateCustomerDetails(age, employmentType, 
                                                monthlyIncome, dues, 
                                                creditScore, defaults);
    int creditLimit = CreditRiskProcessor.CalculateCreditLimit(monthlyIncome, 
                                                                dues, creditScore, 
                                                                defaults);
    Console.WriteLine($"Customer Name: {customerName}");
    Console.WriteLine($"Approved Credit Limit: ₹{creditLimit}");
}
catch (InvalidCreditDataException ex)
{
    Console.WriteLine(ex.Message);
}
```

## Learning Objectives

After completing this project, you should understand:

1. ✅ How to create and use custom exceptions
2. ✅ Input validation techniques
3. ✅ Complex business logic implementation
4. ✅ Risk assessment algorithms
5. ✅ Exception handling best practices
6. ✅ Static utility class design
7. ✅ Multi-condition decision making

## Common Mistakes to Avoid

1. **Case Sensitivity**: Employment type must be exactly "Salaried" or "Self-Employed"
2. **Inclusive Ranges**: Age 21 and 65 are valid (use <= and >=)
3. **Order of Checks**: Check High Risk first, then Low Risk, then default to Medium
4. **Debt Ratio Calculation**: Multiply monthly income by 12 for annual income

## Extension Ideas

1. Add more employment types
2. Implement credit history tracking
3. Add logging for audit trail
4. Create a database to store customer data
5. Add email notification for approval/rejection
6. Implement credit limit increase requests
7. Add co-applicant support

## Technologies Used

- **Language**: C# 10.0
- **Framework**: .NET 10.0
- **Concepts**: Exception Handling, Validation, Business Logic

---

**Project Type**: Console Application  
**Difficulty**: Intermediate  
**Focus**: Exception Handling & Validation  
**Estimated Time**: 2-3 hours
