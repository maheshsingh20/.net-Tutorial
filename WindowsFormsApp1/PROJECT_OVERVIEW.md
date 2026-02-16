# WindowsFormsApp1 - Product Management System

## 🎯 Project Purpose

A **Windows Forms Application** for managing products with database connectivity, implementing repository pattern and custom exception handling.

## 📁 File Structure & Purpose

```
WindowsFormsApp1/
├── Program.cs                    # Application entry point
├── Form1.cs                      # Main UI form (Product management interface)
├── Form1.Designer.cs             # Auto-generated UI designer code
├── Form1.resx                    # Form resources (images, strings, etc.)
├── Product.cs                    # Product entity class
├── IRepo.cs                      # Generic repository interface
├── IProductRepo.cs               # Product-specific repository interface
├── ProductUtility.cs             # Product repository implementation (ADO.NET)
├── MyCustomException.cs          # Custom exception class
├── Class1.cs                     # Additional utility class
├── App.config                    # Application configuration
└── Properties/
    ├── AssemblyInfo.cs           # Assembly metadata
    ├── Resources.Designer.cs     # Resource management
    ├── Resources.resx            # Application resources
    ├── Settings.Designer.cs      # Settings management
    └── Settings.settings         # Application settings
```

## 📄 Detailed File Purposes

### **1. Program.cs**
**Purpose**: Application entry point
```csharp
[STAThread]
static void Main()
{
    Application.EnableVisualStyles();
    Application.SetCompatibleTextRenderingDefault(false);
    Application.Run(new Form1());  // Launch main form
}
```
- Initializes Windows Forms application
- Sets visual styles
- Launches Form1 as main window

### **2. Form1.cs**
**Purpose**: Main user interface for product management
- **UI Components** (likely):
  - TextBoxes for product input (ID, Name, Price, Description)
  - Buttons for CRUD operations (Add, Update, Delete, Show All)
  - DataGridView for displaying products
  - Labels for field names

- **Event Handlers**:
  - `Form1_Load` - Initialize form on load
  - `btnShowAllProduct_Click` - Display all products
  - `button2_Click` - Likely Update/Delete operation
  - `button3_Click` - Another operation
  - Various TextChanged events for validation

### **3. Form1.Designer.cs**
**Purpose**: Auto-generated UI layout code
- Contains all UI control definitions
- Layout positioning and properties
- Event handler wiring
- **DO NOT EDIT MANUALLY** - Modified through Visual Studio Designer

### **4. Form1.resx**
**Purpose**: Form resources
- Stores form-specific resources
- Images, icons, strings
- Localization data
- Binary serialized data

### **5. Product.cs**
**Purpose**: Product entity/model class

**Structure**:
```csharp
public class Product
{
    // Fields
    private int prodID;
    private string prodName;
    private int price;
    private string desc;
    
    // Properties with validation
    public int ProdID { 
        get { return prodID; }
        set { 
            if (value < 0 || value > 999)
                throw new MyCustomException("Product ID is not valid!!");
            prodID = value;
        }
    }
    // Other properties...
}
```

**Features**:
- Encapsulation with private fields
- CLR Properties with validation
- Custom exception throwing for invalid data
- Represents database table structure

### **6. IRepo.cs**
**Purpose**: Generic repository interface

**Expected Methods**:
```csharp
public interface IRepo<T>
{
    bool AddData(T obj);
    bool UpdateData(int id, T obj);
    bool DeleteData(int id);
    T SearchByID(int id);
    List<int> ShowAll();
}
```

**Benefits**:
- Generic CRUD operations
- Can be reused for any entity
- Promotes code reusability
- Follows Repository Pattern

### **7. IProductRepo.cs**
**Purpose**: Product-specific repository interface

**Methods**:
```csharp
public interface IProductRepo : IRepo<Product>
{
    List<Product> ShowAllProductByCategory(int catID);
    List<Product> SortProductByPriceAsc();
    List<Product> SortProductByPriceDesc();
    List<Product> GetTop3BudgetProduct();
}
```

**Features**:
- Extends generic IRepo<Product>
- Adds product-specific operations
- Category filtering
- Sorting by price
- Budget product queries

### **8. ProductUtility.cs**
**Purpose**: Product repository implementation using ADO.NET

**Components**:
```csharp
public class ProductUtility : IProductRepo
{
    SqlConnection con;        // Database connection
    SqlDataAdapter adapt;     // Data adapter for DataSet
    DataSet ds;              // In-memory data cache
    
    // Implement all interface methods
    // Currently: throw new NotImplementedException()
}
```

**Responsibilities**:
- Database connectivity (SQL Server)
- Execute SQL queries
- CRUD operations implementation
- Data retrieval and manipulation
- Exception handling

**Status**: ⚠️ **INCOMPLETE** - All methods throw NotImplementedException

### **9. MyCustomException.cs**
**Purpose**: Custom exception class for application-specific errors

**Expected Structure**:
```csharp
public class MyCustomException : Exception
{
    public MyCustomException(string message) : base(message) { }
}
```

**Usage**:
- Product validation errors
- Business rule violations
- Custom error messages
- Better error handling

### **10. Class1.cs**
**Purpose**: Additional utility class (purpose unclear without content)
- May contain helper methods
- Utility functions
- Extension methods
- Constants or enums

### **11. App.config**
**Purpose**: Application configuration file

**Typical Contents**:
```xml
<configuration>
  <connectionStrings>
    <add name="ProductDB" 
         connectionString="Server=.;Database=ProductDB;Integrated Security=true;" />
  </connectionStrings>
  <appSettings>
    <!-- Application settings -->
  </appSettings>
</configuration>
```

**Stores**:
- Database connection strings
- Application settings
- Configuration parameters

### **12. Properties Folder**

#### **AssemblyInfo.cs**
- Assembly metadata (version, company, copyright)
- Assembly attributes
- COM visibility settings

#### **Resources.Designer.cs & Resources.resx**
- Application-wide resources
- Images, icons, strings
- Localization support

#### **Settings.Designer.cs & Settings.settings**
- User and application settings
- Strongly-typed settings access
- Persistent configuration

## 🏗️ Architecture Pattern

### **Repository Pattern**
```
UI Layer (Form1)
    ↓
Business Logic Layer
    ↓
Repository Interface (IProductRepo)
    ↓
Repository Implementation (ProductUtility)
    ↓
Database (SQL Server)
```

**Benefits**:
- Separation of concerns
- Testability
- Maintainability
- Loose coupling

## 🔧 Technologies Used

- **Framework**: .NET Framework (Windows Forms)
- **UI**: Windows Forms Designer
- **Data Access**: ADO.NET (SqlConnection, SqlDataAdapter, DataSet)
- **Database**: SQL Server (expected)
- **Pattern**: Repository Pattern
- **Exception Handling**: Custom exceptions

## ⚠️ Current Status

### ✅ Completed:
- Project structure
- Entity class (Product) with validation
- Interface definitions (IRepo, IProductRepo)
- Form UI layout
- Custom exception class

### ❌ Incomplete:
- ProductUtility implementation (all methods throw NotImplementedException)
- Form event handlers (empty methods)
- Database connection setup
- CRUD operation logic
- Data binding to UI controls

## 🚀 To Complete This Project:

1. **Implement ProductUtility methods**:
   - AddData
   - UpdateData
   - DeleteData
   - SearchByID
   - ShowAll
   - ShowAllProductByCategory
   - SortProductByPriceAsc/Desc
   - GetTop3BudgetProduct

2. **Complete Form1 event handlers**:
   - Load products on form load
   - Add product button click
   - Update product button click
   - Delete product button click
   - Show all products button click
   - Search functionality

3. **Setup Database**:
   - Create ProductDB database
   - Create Products table
   - Add connection string to App.config

4. **Add Data Binding**:
   - Bind DataGridView to product list
   - Bind TextBoxes to selected product
   - Implement validation

## 📊 Expected Database Schema

```sql
CREATE TABLE Products (
    ProdID INT PRIMARY KEY,
    ProdName NVARCHAR(100),
    Price INT,
    Description NVARCHAR(500),
    CategoryID INT
);
```

## 💡 Usage Scenario

1. User opens application (Form1 loads)
2. Products displayed in DataGridView
3. User can:
   - Add new product
   - Update existing product
   - Delete product
   - Search by ID
   - Filter by category
   - Sort by price
   - View budget products

## 🎓 Learning Objectives

- Windows Forms development
- ADO.NET data access
- Repository pattern
- Custom exception handling
- UI event handling
- Data binding
- CRUD operations
- SQL Server connectivity
