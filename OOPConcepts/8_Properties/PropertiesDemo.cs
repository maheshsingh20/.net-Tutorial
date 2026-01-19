using System;

namespace OOPConcepts.Properties
{
    // PROPERTIES: Provide controlled access to private fields
    // Combine benefits of fields and methods
    // Use get and set accessors
    
    public class Student
    {
        private string name;
        private int age;
        private double gpa;
        
        // Full property with validation
        public string Name
        {
            get { return name; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    name = value;
                else
                    Console.WriteLine("Name cannot be empty");
            }
        }
        
        // Property with validation in setter
        public int Age
        {
            get { return age; }
            set
            {
                if (value >= 0 && value <= 100)
                    age = value;
                else
                    Console.WriteLine("Invalid age");
            }
        }
        
        // Property with private setter (read-only from outside)
        public string StudentId { get; private set; }
        
        // Auto-implemented property
        public string Email { get; set; }
        
        // Read-only property (calculated)
        public string Status
        {
            get
            {
                if (gpa >= 3.5) return "Excellent";
                else if (gpa >= 3.0) return "Good";
                else if (gpa >= 2.0) return "Average";
                else return "Needs Improvement";
            }
        }
        
        // Property with both get and set logic
        public double GPA
        {
            get { return gpa; }
            set
            {
                if (value >= 0.0 && value <= 4.0)
                {
                    gpa = value;
                    Console.WriteLine($"GPA updated to {gpa:F2}");
                }
                else
                {
                    Console.WriteLine("GPA must be between 0.0 and 4.0");
                }
            }
        }
        
        public Student(string name, int age, string studentId)
        {
            Name = name;
            Age = age;
            StudentId = studentId;
            gpa = 0.0;
        }
        
        public void DisplayInfo()
        {
            Console.WriteLine($"ID: {StudentId}, Name: {Name}, Age: {Age}");
            Console.WriteLine($"GPA: {GPA:F2}, Status: {Status}");
        }
    }
    
    public class PropertiesDemo
    {
        public static void Run()
        {
            Console.WriteLine("\n=== PROPERTIES ===");
            Console.WriteLine("Controlled access to private fields with get/set\n");
            
            Student student = new Student("Alice", 20, "S001");
            student.Email = "alice@university.com";
            
            student.DisplayInfo();
            
            // Using property setters with validation
            student.GPA = 3.8;
            student.GPA = 5.0;  // Invalid
            
            student.Age = 21;
            student.Age = 150;  // Invalid
            
            Console.WriteLine();
            student.DisplayInfo();
        }
    }
}
