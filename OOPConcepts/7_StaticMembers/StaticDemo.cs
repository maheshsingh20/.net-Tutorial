using System;

namespace OOPConcepts.StaticMembers
{
    // STATIC: Belongs to class itself, not to instances
    // Shared across all objects of the class
    // Accessed using class name, not object reference
    
    public class Counter
    {
        // Static field: Shared by all instances
        private static int count = 0;
        
        // Instance field: Unique to each object
        private int instanceId;
        
        // Static property
        public static int TotalCount
        {
            get { return count; }
        }
        
        // Constructor
        public Counter()
        {
            count++;  // Increment shared counter
            instanceId = count;
        }
        
        // Static method: Can only access static members
        public static void ResetCount()
        {
            count = 0;
            Console.WriteLine("Counter reset to 0");
        }
        
        // Instance method: Can access both static and instance members
        public void DisplayInfo()
        {
            Console.WriteLine($"Instance ID: {instanceId}, Total Count: {count}");
        }
    }
    
    public class MathUtility
    {
        // Static class members for utility functions
        
        public static double PI = 3.14159;
        
        public static int Add(int a, int b)
        {
            return a + b;
        }
        
        public static int Multiply(int a, int b)
        {
            return a * b;
        }
        
        public static double CalculateCircleArea(double radius)
        {
            return PI * radius * radius;
        }
        
        public static int Factorial(int n)
        {
            if (n <= 1) return 1;
            return n * Factorial(n - 1);
        }
    }
    
    // STATIC CLASS: Cannot be instantiated, contains only static members
    public static class StringHelper
    {
        public static string Reverse(string input)
        {
            char[] chars = input.ToCharArray();
            Array.Reverse(chars);
            return new string(chars);
        }
        
        public static int CountVowels(string input)
        {
            int count = 0;
            string vowels = "aeiouAEIOU";
            foreach (char c in input)
            {
                if (vowels.Contains(c))
                    count++;
            }
            return count;
        }
        
        public static bool IsPalindrome(string input)
        {
            string reversed = Reverse(input);
            return input.Equals(reversed, StringComparison.OrdinalIgnoreCase);
        }
    }
    
    public class Employee
    {
        // Static field to track employee count
        private static int employeeCount = 0;
        
        // Static field for company name (shared by all)
        public static string CompanyName = "TechCorp";
        
        // Instance fields
        public string Name { get; set; }
        public int EmployeeId { get; private set; }
        
        // Static constructor: Called once before any instance is created
        static Employee()
        {
            Console.WriteLine("Static constructor called - Initializing Employee class");
            CompanyName = "TechCorp Inc.";
        }
        
        // Instance constructor
        public Employee(string name)
        {
            employeeCount++;
            EmployeeId = employeeCount;
            Name = name;
        }
        
        public static int GetEmployeeCount()
        {
            return employeeCount;
        }
        
        public void DisplayInfo()
        {
            Console.WriteLine($"ID: {EmployeeId}, Name: {Name}, Company: {CompanyName}");
        }
    }
    
    public class StaticDemo
    {
        public static void Run()
        {
            Console.WriteLine("\n=== STATIC MEMBERS ===");
            Console.WriteLine("Belongs to class, shared across all instances\n");
            
            // Static counter example
            Console.WriteLine("--- Static Counter ---");
            Counter c1 = new Counter();
            Counter c2 = new Counter();
            Counter c3 = new Counter();
            
            c1.DisplayInfo();
            c2.DisplayInfo();
            c3.DisplayInfo();
            
            Console.WriteLine($"Total objects created: {Counter.TotalCount}");
            Counter.ResetCount();
            
            // Static utility methods
            Console.WriteLine("\n--- Static Utility Methods ---");
            Console.WriteLine($"5 + 3 = {MathUtility.Add(5, 3)}");
            Console.WriteLine($"5 * 3 = {MathUtility.Multiply(5, 3)}");
            Console.WriteLine($"Circle area (r=5): {MathUtility.CalculateCircleArea(5):F2}");
            Console.WriteLine($"Factorial of 5: {MathUtility.Factorial(5)}");
            
            // Static class example
            Console.WriteLine("\n--- Static Class ---");
            string text = "hello";
            Console.WriteLine($"Original: {text}");
            Console.WriteLine($"Reversed: {StringHelper.Reverse(text)}");
            Console.WriteLine($"Vowels: {StringHelper.CountVowels(text)}");
            Console.WriteLine($"Is 'radar' palindrome? {StringHelper.IsPalindrome("radar")}");
            
            // Static constructor and fields
            Console.WriteLine("\n--- Static Constructor ---");
            Employee emp1 = new Employee("Alice");
            Employee emp2 = new Employee("Bob");
            Employee emp3 = new Employee("Charlie");
            
            emp1.DisplayInfo();
            emp2.DisplayInfo();
            emp3.DisplayInfo();
            
            Console.WriteLine($"Total employees: {Employee.GetEmployeeCount()}");
        }
    }
}
