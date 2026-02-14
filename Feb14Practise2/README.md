# HealthSync Advanced Billing System

## Executive Summary

The HealthSync Advanced Billing System is a C# application designed for Machine Masters to automate medical consultant payouts. The system utilizes Object-Oriented Programming (OOP) to handle complex payroll logic, multi-tier taxation (TDS), and strict data validation for two distinct employee categories: In-House and Visiting Consultants.

## System Architecture

### Core OOP Pillars

#### A. Abstraction (The Consultant Class)
- **Abstract Base Class**: Acts as a blueprint for all consultants
- **Purpose**: Prevents creation of "generic" consultants - every consultant must be either In-House or Visiting
- **Key Feature**: `CalculateGrossPayout()` method is abstract, forcing subclasses to define their own financial calculations

#### B. Polymorphism (Method Overriding)
The system uses polymorphism to handle specialized payout formulas:
- **In-House**: `MonthlyStipend + Allowances (20%) + Bonuses (₹1000)`
- **Visiting**: `ConsultationsCount × RatePerVisit`

#### C. Virtual Logic (Dynamic Taxation)
Virtual method for TDS (Tax Deducted at Source) calculation:
- **Default Logic**: Sliding scale (5% or 15%) based on earnings
- **Overridden Logic**: Visiting consultants use flat 10% rate

## Class Structure

```
Consultant (Abstract)
├── ConsultantId: string
├── Name: string
├── ValidateConsultantId(): bool (private)
├── CalculateGrossPayout(): decimal (abstract)
├── CalculateTDS(decimal): decimal (virtual)
├── CalculateNetPayout(): decimal
├── DisplayPayoutDetails(): void
└── GetConsultantType(): string (abstract)

InHouseConsultant : Consultant
├── MonthlyStipend: decimal
├── CalculateGrossPayout(): decimal (override)
└── GetConsultantType(): string (override)

VisitingConsultant : Consultant
├── ConsultationsCount: int
├── RatePerVisit: decimal
├── CalculateGrossPayout(): decimal (override)
├── CalculateTDS(decimal): decimal (override)
└── GetConsultantType(): string (override)
```

## Validation Rules

### Consultant ID Validation
All IDs must pass the `ValidateConsultantId()` check:
- **Length**: Exactly 6 characters
- **Prefix**: Must start with "DR"
- **Format**: Last 4 characters must be numeric

**Valid Examples**: DR2001, DR8005, DR3001
**Invalid Examples**: MD1001, DR123, DRABC1, DR12345

## Taxation Table

| Consultant Type | Condition | Applied Rate |
|----------------|-----------|--------------|
| In-House | Payout ≤ 5000 | 5% |
| In-House | Payout > 5000 | 15% |
| Visiting | Any Amount | 10% (Flat) |

## Payout Formulas

### In-House Consultant
```
Allowances = MonthlyStipend × 0.20
Bonuses = ₹1000 (Fixed)
Gross Payout = MonthlyStipend + Allowances + Bonuses
TDS Rate = (Gross ≤ 5000) ? 5% : 15%
Net Payout = Gross - (Gross × TDS Rate)
```

### Visiting Consultant
```
Gross Payout = ConsultationsCount × RatePerVisit
TDS Rate = 10% (Flat)
Net Payout = Gross - (Gross × TDS Rate)
```

## Sample Output Scenarios

### Scenario 1: In-House Consultant (High Earner)
**Input**: 
- ID: DR2001
- Stipend: ₹10,000

**Process**:
- Allowances: ₹10,000 × 0.20 = ₹2,000
- Bonuses: ₹1,000
- Gross: ₹10,000 + ₹2,000 + ₹1,000 = ₹13,000
- TDS: 15% (since ₹13,000 > ₹5,000)
- Net: ₹13,000 - (₹13,000 × 0.15) = ₹11,050

**Output**:
```
Gross Payout: 13000.00
TDS Applied: 15%
Net Payout: 11050.00
```

### Scenario 2: Visiting Consultant
**Input**:
- ID: DR8005
- Consultations: 10
- Rate: ₹600

**Process**:
- Gross: 10 × ₹600 = ₹6,000
- TDS: 10% (Flat)
- Net: ₹6,000 - (₹6,000 × 0.10) = ₹5,400

**Output**:
```
Gross Payout: 6000.00
TDS Applied: 10%
Net Payout: 5400.00
```

### Scenario 3: Validation Failure
**Input**: ID: MD1001

**Output**: `Invalid doctor id` (Process terminates)

### Scenario 4: In-House Consultant (Low Earner)
**Input**:
- ID: DR3001
- Stipend: ₹3,000

**Process**:
- Allowances: ₹3,000 × 0.20 = ₹600
- Bonuses: ₹1,000
- Gross: ₹3,000 + ₹600 + ₹1,000 = ₹4,600
- TDS: 5% (since ₹4,600 ≤ ₹5,000)
- Net: ₹4,600 - (₹4,600 × 0.05) = ₹4,370

**Output**:
```
Gross Payout: 4600.00
TDS Applied: 5%
Net Payout: 4370.00
```

## How to Run

### Build the Project
```bash
cd Feb14Practise2
dotnet build
```

### Run the Application
```bash
dotnet run
```

### Menu Options
1. **Process In-House Consultant** - Enter details for an in-house consultant
2. **Process Visiting Consultant** - Enter details for a visiting consultant
3. **Run All Test Scenarios** - Execute all predefined test cases
0. **Exit** - Close the application

## Key Features

### 1. Strict Validation
- ID format validation prevents invalid consultant records
- Negative value checks for financial inputs
- Exception handling for all edge cases

### 2. Polymorphic Behavior
- Different payout calculations based on consultant type
- Flexible TDS calculation with override capability
- Type-specific business logic encapsulation

### 3. Extensibility
- Easy to add new consultant types
- Virtual methods allow customization
- Abstract base ensures consistency

### 4. Error Handling
- Descriptive error messages
- Graceful failure handling
- Input validation at multiple levels

## OOP Concepts Demonstrated

### Abstraction
- Abstract `Consultant` class defines contract
- Abstract methods enforce implementation
- Prevents instantiation of base class

### Inheritance
- `InHouseConsultant` inherits from `Consultant`
- `VisitingConsultant` inherits from `Consultant`
- Code reuse through base class methods

### Polymorphism
- Method overriding for specialized behavior
- Virtual methods with default implementation
- Runtime type determination

### Encapsulation
- Private validation methods
- Public properties with validation
- Protected data access

## Technical Specifications

- **Language**: C# 10.0
- **Framework**: .NET 10.0
- **Architecture**: Object-Oriented
- **Design Pattern**: Template Method Pattern

## Testing

The application includes comprehensive test scenarios covering:
- ✅ High earner in-house consultants (15% TDS)
- ✅ Low earner in-house consultants (5% TDS)
- ✅ Visiting consultants (10% flat TDS)
- ✅ ID validation failures
- ✅ Edge cases (threshold values)
- ✅ Multiple validation scenarios

## Future Enhancements

- Database integration for persistent storage
- Batch processing for multiple consultants
- Report generation (PDF/Excel)
- Email notifications for payout processing
- Audit trail and logging
- Web API for remote access
- Dashboard for analytics

---

**Developed for**: Machine Masters
**Version**: 1.0
**Date**: February 14, 2026
