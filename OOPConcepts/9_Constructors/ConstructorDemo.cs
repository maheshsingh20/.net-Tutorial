using System;

namespace OOPConcepts.Constructors
{
    // CONSTRUCTOR: Special method called when object is created
    // Same name as class, no return type
    // Types: Default, Parameterized, Copy, Static, Private
    
    public class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
        
        // Static field
        private static int totalProducts = 0;
        
        // DEFAULT CONSTRUCTOR (no parameters)
        public Product()
        {
            Name = "Unknown";
            Price = 0.0;
            Stock = 0;
            totalProducts++;
            Console.WriteLine("Default constructor called");
        }
        
        // PARAMETERIZED CONSTRUCTOR
        public Product(string name, double price)
        {
            Name = name;
            Price = price;
            Stock = 0;
            totalProducts++;
            Console.WriteLine($"Parameterized constructor called for {name}");
        }
        
        // CONSTRUCTOR OVERLOADING
        public Product(string name, double price, int stock)
        {
            Name = name;
            Price = price;
            Stock = stock;
            totalProducts++;
            Console.WriteLine($"Full constructor called for {name}");
        }
        
        // COPY CONSTRUCTOR
        public Product(Product other)
        {
            Name = other.Name;
            Price = other.Price;
            Stock = other.Stock;
            totalProducts++;
            Console.WriteLine($"Copy constructor called for {Name}");
        }
        
        // STATIC CONSTRUCTOR: Called once before any instance
        static Product()
        {
            Console.WriteLine("Static constructor called - initializing Product class");
            totalProducts = 0;
        }
        
        public static int GetTotalProducts()
        {
            return totalProducts;
        }
        
        public void DisplayInfo()
        {
            Console.WriteLine($"Product: {Name}, Price: ${Price}, Stock: {Stock}");
        }
    }
    
    // CONSTRUCTOR CHAINING: Calling one constructor from another
    public class Employee
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public string Department { get; set; }
        public double Salary { get; set; }
        
        // Constructor 1
        public Employee() : this("Unknown", 0)
        {
            Console.WriteLine("Default constructor");
        }
        
        // Constructor 2
        public Employee(string name, int id) : this(name, id, "General")
        {
            Console.WriteLine($"Constructor with name and id");
        }
        
        // Constructor 3
        public Employee(string name, int id, string dept) : this(name, id, dept, 30000)
        {
            Console.WriteLine($"Constructor with name, id, and department");
        }
        
        // Main constructor (all others chain to this)
        public Employee(string name, int id, string dept, double salary)
        {
            Name = name;
            Id = id;
            Department = dept;
            Salary = salary;
            Console.WriteLine($"Main constructor - Employee {name} created");
        }
        
        public void DisplayInfo()
        {
            Console.WriteLine($"ID: {Id}, Name: {Name}, Dept: {Department}, Salary: ${Salary}");
        }
    }
    
    public class ConstructorDemo
    {
        public static void Run()
        {
            Console.WriteLine("\n=== CONSTRUCTORS ===");
            Console.WriteLine("Special methods for object initialization\n");
            
            Console.WriteLine("--- Different Constructor Types ---");
            Product p1 = new Product();
            Product p2 = new Product("Laptop", 999.99);
            Product p3 = new Product("Mouse", 25.50, 100);
            Product p4 = new Product(p2); // Copy constructor
            
            Console.WriteLine($"\nTotal products created: {Product.GetTotalProducts()}");
            
            Console.WriteLine("\n--- Constructor Chaining ---");
            Employee e1 = new Employee();
            Console.WriteLine();
            Employee e2 = new Employee("Bob", 102);
            Console.WriteLine();
            Employee e3 = new Employee("Charlie", 103, "IT", 50000);
            
            Console.WriteLine("\n--- Employee Details ---");
            e1.DisplayInfo();
            e2.DisplayInfo();
            e3.DisplayInfo();
        }
    }
}
