# Migration Guide

## Current Status

The generics practice problems are currently split across two locations:

1. **ECommerceInventory/** - Contains Problem 1 (Inventory System)
2. **ECommerceInventory/CourseRegistration/** - Contains Problem 2 (Course Registration)

## Recommended Structure

All code should be consolidated into **GenericsPractice/** project:

```
GenericsPractice/
├── Problem1/               # E-Commerce Inventory
│   ├── IProduct.cs
│   ├── ProductRepository.cs
│   ├── ElectronicProduct.cs
│   ├── ClothingProduct.cs
│   ├── BookProduct.cs
│   ├── GroceryProduct.cs
│   ├── DiscountedProduct.cs
│   ├── InventoryManager.cs
│   └── InventoryDemo.cs
│
├── Problem2/               # Course Registration
│   ├── IStudent.cs
│   ├── ICourse.cs
│   ├── EngineeringStudent.cs
│   ├── LabCourse.cs
│   ├── EnrollmentSystem.cs
│   ├── GradeBook.cs
│   └── CourseRegistrationDemo.cs
│
├── Program.cs              # Main menu
└── README.md
```

## Migration Steps

### Step 1: Update Namespaces

Change all namespaces from:
- `ECommerceInventory` → `GenericsPractice.Problem1`
- `ECommerceInventory.CourseRegistration` → `GenericsPractice.Problem2`

### Step 2: Move Files

Copy files from ECommerceInventory to GenericsPractice with proper folder structure.

### Step 3: Update Program.cs

Create a menu system that calls:
- `Problem1.InventoryDemo.Run()`
- `Problem2.CourseRegistrationDemo.Run()`

### Step 4: Test

Build and run to ensure both problems work correctly.

## Benefits of Consolidation

1. ✅ Better organization
2. ✅ Single project for all generics practice
3. ✅ Easier to navigate
4. ✅ Clear separation of concerns
5. ✅ Consistent structure

## Current Working State

Both problems are fully functional in their current locations:
- Run ECommerceInventory project for both demos
- The menu system allows switching between problems

## Future Improvements

1. Complete the migration to GenericsPractice
2. Add more generic problems
3. Create unit tests
4. Add performance benchmarks
5. Create detailed tutorials
