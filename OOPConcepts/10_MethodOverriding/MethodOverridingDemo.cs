using System;

namespace OOPConcepts.MethodOverriding
{
    // METHOD OVERRIDING: Redefining parent class method in child class
    // Uses: virtual (parent), override (child), base keyword
    // Enables runtime polymorphism
    
    public class Employee
    {
        public string Name { get; set; }
        public int Id { get; set; }
        protected double baseSalary;
        
        public Employee(string name, int id, double salary)
        {
            Name = name;
            Id = id;
            baseSalary = salary;
        }
        
        // VIRTUAL: Can be overridden in derived classes
        public virtual double CalculateSalary()
        {
            return baseSalary;
        }
        
        public virtual void DisplayInfo()
        {
            Console.WriteLine($"Employee: {Name} (ID: {Id})");
            Console.WriteLine($"Salary: ${CalculateSalary():F2}");
        }
        
        public virtual string GetRole()
        {
            return "Employee";
        }
    }
    
    public class Manager : Employee
    {
        public double Bonus { get; set; }
        public int TeamSize { get; set; }
        
        public Manager(string name, int id, double salary, double bonus, int teamSize) 
            : base(name, id, salary)
        {
            Bonus = bonus;
            TeamSize = teamSize;
        }
        
        // OVERRIDE: Provides new implementation
        public override double CalculateSalary()
        {
            return baseSalary + Bonus;
        }
        
        public override void DisplayInfo()
        {
            // BASE: Calls parent class method
            base.DisplayInfo();
            Console.WriteLine($"Bonus: ${Bonus}");
            Console.WriteLine($"Team Size: {TeamSize}");
        }
        
        public override string GetRole()
        {
            return "Manager";
        }
    }
    
    public class Developer : Employee
    {
        public string ProgrammingLanguage { get; set; }
        public int ProjectsCompleted { get; set; }
        
        public Developer(string name, int id, double salary, string language) 
            : base(name, id, salary)
        {
            ProgrammingLanguage = language;
            ProjectsCompleted = 0;
        }
        
        public override double CalculateSalary()
        {
            // Bonus based on projects completed
            double projectBonus = ProjectsCompleted * 500;
            return baseSalary + projectBonus;
        }
        
        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Language: {ProgrammingLanguage}");
            Console.WriteLine($"Projects: {ProjectsCompleted}");
        }
        
        public override string GetRole()
        {
            return "Developer";
        }
    }
    
    public class MethodOverridingDemo
    {
        public static void Run()
        {
            Console.WriteLine("\n=== METHOD OVERRIDING ===");
            Console.WriteLine("Redefining parent method in child class\n");
            
            Employee emp = new Employee("John", 101, 50000);
            Manager mgr = new Manager("Alice", 102, 70000, 15000, 5);
            Developer dev = new Developer("Bob", 103, 60000, "C#");
            dev.ProjectsCompleted = 10;
            
            Console.WriteLine("--- Employee ---");
            emp.DisplayInfo();
            
            Console.WriteLine("\n--- Manager ---");
            mgr.DisplayInfo();
            
            Console.WriteLine("\n--- Developer ---");
            dev.DisplayInfo();
            
            // Runtime polymorphism
            Console.WriteLine("\n--- Polymorphic Behavior ---");
            Employee[] employees = { emp, mgr, dev };
            
            foreach (Employee e in employees)
            {
                Console.WriteLine($"{e.GetRole()}: {e.Name} - ${e.CalculateSalary():F2}");
            }
        }
    }
}
