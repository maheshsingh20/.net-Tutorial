using System;

namespace OOPConcepts.Polymorphism
{
    // POLYMORPHISM: "Many forms" - same interface, different implementations
    // Types: 1) Compile-time (Method Overloading)
    //        2) Runtime (Method Overriding)
    
    // === COMPILE-TIME POLYMORPHISM (Method Overloading) ===
    public class Calculator
    {
        // METHOD OVERLOADING: Same method name, different parameters
        // Decided at compile time based on method signature
        
        public int Add(int a, int b)
        {
            Console.WriteLine("Adding two integers");
            return a + b;
        }
        
        public int Add(int a, int b, int c)
        {
            Console.WriteLine("Adding three integers");
            return a + b + c;
        }
        
        public double Add(double a, double b)
        {
            Console.WriteLine("Adding two doubles");
            return a + b;
        }
        
        public string Add(string a, string b)
        {
            Console.WriteLine("Concatenating strings");
            return a + b;
        }
    }
    
    // === RUNTIME POLYMORPHISM (Method Overriding) ===
    public class Shape
    {
        public string Name { get; set; }
        
        // Virtual method can be overridden
        public virtual double CalculateArea()
        {
            return 0;
        }
        
        public virtual void Draw()
        {
            Console.WriteLine("Drawing a shape");
        }
    }
    
    public class Circle : Shape
    {
        public double Radius { get; set; }
        
        public Circle(double radius)
        {
            Name = "Circle";
            Radius = radius;
        }
        
        // Override: Providing specific implementation
        public override double CalculateArea()
        {
            return Math.PI * Radius * Radius;
        }
        
        public override void Draw()
        {
            Console.WriteLine($"Drawing a circle with radius {Radius}");
        }
    }
    
    public class Rectangle : Shape
    {
        public double Length { get; set; }
        public double Width { get; set; }
        
        public Rectangle(double length, double width)
        {
            Name = "Rectangle";
            Length = length;
            Width = width;
        }
        
        public override double CalculateArea()
        {
            return Length * Width;
        }
        
        public override void Draw()
        {
            Console.WriteLine($"Drawing rectangle {Length}x{Width}");
        }
    }
    
    public class Triangle : Shape
    {
        public double Base { get; set; }
        public double Height { get; set; }
        
        public Triangle(double baseLength, double height)
        {
            Name = "Triangle";
            Base = baseLength;
            Height = height;
        }
        
        public override double CalculateArea()
        {
            return 0.5 * Base * Height;
        }
        
        public override void Draw()
        {
            Console.WriteLine($"Drawing triangle with base {Base} and height {Height}");
        }
    }
    
    public class PolymorphismDemo
    {
        public static void Run()
        {
            Console.WriteLine("\n=== POLYMORPHISM ===");
            Console.WriteLine("Same interface, different implementations\n");
            
            // COMPILE-TIME POLYMORPHISM (Method Overloading)
            Console.WriteLine("--- Method Overloading ---");
            Calculator calc = new Calculator();
            Console.WriteLine($"Result: {calc.Add(5, 10)}");
            Console.WriteLine($"Result: {calc.Add(5, 10, 15)}");
            Console.WriteLine($"Result: {calc.Add(5.5, 10.5)}");
            Console.WriteLine($"Result: {calc.Add("Hello", "World")}");
            
            // RUNTIME POLYMORPHISM (Method Overriding)
            Console.WriteLine("\n--- Method Overriding ---");
            
            Circle circle = new Circle(5);
            Rectangle rectangle = new Rectangle(10, 5);
            Triangle triangle = new Triangle(8, 6);
            
            // Using base class reference
            Shape[] shapes = { circle, rectangle, triangle };
            
            foreach (Shape shape in shapes)
            {
                shape.Draw();  // Calls appropriate overridden method
                Console.WriteLine($"Area: {shape.CalculateArea():F2}\n");
            }
        }
    }
}
