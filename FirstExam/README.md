# FirstExam - Practice Problems

Two comprehensive practice problems for exam preparation covering real-world business scenarios with complete CRUD operations and calculations.

## 📋 Project Overview

This project contains 2 complete practice problems simulating real-world business applications with menu-driven interfaces, data validation, and business logic calculations.

## 🎯 Problems

### Problem 1: QuickMart Traders - Sales Transaction System
**Domain**: Retail/Trading  
**Concept**: Profit/Loss calculation and transaction management

**Features**:
- Create new sales transactions
- Calculate profit/loss automatically
- View last transaction details
- Recompute profit margins
- Input validation

**Business Logic**:
```
Profit/Loss Amount = |Selling Amount - Purchase Amount|
Profit Margin % = (Profit/Loss Amount / Purchase Amount) × 100

Status:
- PROFIT: Selling > Purchase
- LOSS: Selling < Purchase
- BREAK-EVEN: Selling = Purchase
```

---

### Problem 2: MediSure Clinic - Patient Billing System
**Domain**: Healthcare  
**Concept**: Medical billing with insurance discounts

**Features**:
- Create patient bills
- Insurance-based discount calculation
- View bill details
- Clear bill data
- Input validation

**Business Logic**:
```
Gross Amount = Consultation Fee + Lab Charges + Medicine Charges
Discount Amount = Gross Amount × 10% (if insured) or 0 (if not insured)
Final Payable = Gross Amount - Discount Amount
```

## 📁 Project Structure

```
FirstExam/
├── Question/
│   ├── problem1.cs         # QuickMart Traders
│   ├── problem2.cs         # MediSure Clinic
│   └── data.txt           # Sample data
├── Program.cs              # Main menu system
├── FirstExam.csproj        # Project file
└── README.md              # This file
```

## 🚀 Running the Project

### Build
```bash
cd FirstExam
dotnet build
```

### Run
```bash
dotnet run
```

### Interactive Menu
```
╔════════════════════════════════════════════╗
║         First Exam - Practice Problems      ║
╚════════════════════════════════════════════╝

Select a problem to run:

1. Problem 1: QuickMart Traders (Sales Transaction System)
2. Problem 2: MediSure Clinic (Patient Billing System)
0. Exit

Enter your choice:
```

## 📚 Problem Details

### Problem 1: QuickMart Traders

**Menu Options**:
1. Create New Transaction
2. View Last Transaction
3. Calculate Profit/Loss
4. Exit

**Sample Flow**:
```
Enter Invoice No: INV001
Enter Customer Name: John Doe
Enter Item Name: Laptop
Enter Quantity: 2
Enter Purchase Amount (total): 80000
Enter Selling Amount (total): 95000

Transaction saved successfully.
Status: PROFIT
Profit/Loss Amount: 15000.00
Profit Margin (%): 18.75
```

**Data Model**:
```csharp
public class SaleTransaction
{
    public string InvoiceNo { get; set; }
    public string CustomerName { get; set; }
    public string ItemName { get; set; }
    public int Quantity { get; set; }
    public decimal PurchaseAmount { get; set; }
    public decimal SellingAmount { get; set; }
    public string ProfitOrLossStatus { get; set; }
    public decimal ProfitOrLossAmount { get; set; }
    public decimal ProfitMarginPercent { get; set; }
}
```

**Validation Rules**:
- Invoice No: Cannot be empty
- Quantity: Must be > 0
- Purchase Amount: Must be > 0
- Selling Amount: Must be ≥ 0

---

### Problem 2: MediSure Clinic

**Menu Options**:
1. Create New Bill
2. View Last Bill
3. Clear Last Bill
4. Exit

**Sample Flow**:
```
Enter Bill Id: BILL001
Enter Patient Name: Jane Smith
Is the patient insured? (Y/N): Y
Enter Consultation Fee: 500
Enter Lab Charges: 1500
Enter Medicine Charges: 800

Bill created successfully.
Gross Amount: 2800.00
Discount Amount: 280.00
Final Payable: 2520.00
```

**Data Model**:
```csharp
public class PatientBill
{
    public string BillId { get; set; }
    public string PatientName { get; set; }
    public bool HasInsurance { get; set; }
    public decimal ConsultationFee { get; set; }
    public decimal LabCharges { get; set; }
    public decimal MedicineCharges { get; set; }
    public decimal GrossAmount { get; set; }
    public decimal DiscountAmount { get; set; }
    public decimal FinalPayable { get; set; }
}
```

**Validation Rules**:
- Bill ID: Cannot be empty
- Consultation Fee: Must be > 0
- Lab Charges: Must be ≥ 0
- Medicine Charges: Must be ≥ 0
- Insurance: Y/N input

**Discount Logic**:
- Insured patients: 10% discount on gross amount
- Non-insured patients: No discount

## 🎓 Concepts Covered

### Programming Concepts
- Static methods and properties
- Data validation
- Menu-driven interfaces
- Business logic implementation
- Decimal arithmetic for financial calculations

### OOP Principles
- Encapsulation (properties)
- Static members for shared state
- Method organization
- Class design

### Best Practices
- Input validation
- Error handling
- User-friendly messages
- Clear menu structure
- Formatted output

## 💡 Key Learning Points

### 1. Financial Calculations
```csharp
// Always use decimal for money
decimal grossAmount = consultationFee + labCharges + medicineCharges;
decimal discountAmount = hasInsurance ? grossAmount * 0.10m : 0;
decimal finalPayable = grossAmount - discountAmount;
```

### 2. Input Validation
```csharp
if (!decimal.TryParse(Console.ReadLine(), out decimal amount) || amount <= 0)
{
    Console.WriteLine("Amount must be greater than 0. Please try again.");
    return;
}
```

### 3. Static State Management
```csharp
public static PatientBill LastBill;
public static bool HasLastBill = false;
```

### 4. Conditional Logic
```csharp
if (sellingAmount > purchaseAmount)
{
    profitOrLossStatus = "PROFIT";
    profitOrLossAmount = sellingAmount - purchaseAmount;
}
else if (sellingAmount < purchaseAmount)
{
    profitOrLossStatus = "LOSS";
    profitOrLossAmount = purchaseAmount - sellingAmount;
}
else
{
    profitOrLossStatus = "BREAK-EVEN";
    profitOrLossAmount = 0;
}
```

## 🧪 Test Scenarios

### Problem 1 Test Cases

**Test Case 1: Profit Scenario**
```
Purchase: 50000
Selling: 60000
Expected: PROFIT, 10000, 20%
```

**Test Case 2: Loss Scenario**
```
Purchase: 50000
Selling: 45000
Expected: LOSS, 5000, 10%
```

**Test Case 3: Break-Even**
```
Purchase: 50000
Selling: 50000
Expected: BREAK-EVEN, 0, 0%
```

---

### Problem 2 Test Cases

**Test Case 1: Insured Patient**
```
Consultation: 500
Lab: 1000
Medicine: 500
Insurance: Yes
Expected: Gross=2000, Discount=200, Final=1800
```

**Test Case 2: Non-Insured Patient**
```
Consultation: 500
Lab: 1000
Medicine: 500
Insurance: No
Expected: Gross=2000, Discount=0, Final=2000
```

## 🔧 Technologies Used

- **Language**: C# 10.0
- **Framework**: .NET 10.0
- **Platform**: Console Application
- **Data Type**: Decimal for financial calculations

## 📊 Difficulty Level

| Problem | Difficulty | Time Estimate |
|---------|-----------|---------------|
| Problem 1 | Medium | 30-45 minutes |
| Problem 2 | Medium | 30-45 minutes |

## 🎯 Exam Preparation Tips

1. **Understand Requirements**
   - Read problem statement carefully
   - Identify input/output requirements
   - Note validation rules

2. **Plan Before Coding**
   - Design data model
   - Plan menu structure
   - Identify calculations needed

3. **Write Clean Code**
   - Use meaningful variable names
   - Add comments for complex logic
   - Format output clearly

4. **Test Thoroughly**
   - Test all menu options
   - Try edge cases
   - Verify calculations

5. **Handle Errors**
   - Validate all inputs
   - Provide clear error messages
   - Prevent crashes

## 📝 Common Mistakes to Avoid

1. **Using float/double for money** → Use decimal
2. **Not validating inputs** → Always validate
3. **Poor error messages** → Be specific
4. **Forgetting edge cases** → Test thoroughly
5. **Complex code** → Keep it simple

## 🤝 Contributing

This is an exam practice repository. Feel free to:
- Add more test cases
- Improve validation
- Enhance user experience

## 📄 License

Educational purposes only.

## 👤 Author

Created for exam preparation and practice.

---

**Last Updated**: February 19, 2026  
**Total Problems**: 2  
**.NET Version**: 10.0  
**C# Version**: 10.0

## 🎉 Good Luck with Your Exam!

Practice these problems multiple times to build confidence and speed. Focus on understanding the logic rather than memorizing code!
