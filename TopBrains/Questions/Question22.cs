using System;

namespace TopBrains.Questions
{
    public interface IArea
    {
        double CalculateArea();
    }
    
    public abstract class Shape : IArea
    {
        public abstract double CalculateArea();
    }
    
    public class Circle : Shape
    {
        public double Radius { get; set; }
        
        public Circle(double radius)
        {
            Radius = radius;
        }
        
        public override double CalculateArea()
        {
            return Math.PI * Radius * Radius;
        }
    }
    
    public class Rectangle : Shape
    {
        public double Width { get; set; }
        public double Height { get; set; }
        
        public Rectangle(double width, double height)
        {
            Width = width;
            Height = height;
        }
        
        public override double CalculateArea()
        {
            return Width * Height;
        }
    }
    
    public class Triangle : Shape
    {
        public double Base { get; set; }
        public double Height { get; set; }
        
        public Triangle(double baseLength, double height)
        {
            Base = baseLength;
            Height = height;
        }
        
        public override double CalculateArea()
        {
            return 0.5 * Base * Height;
        }
    }
    
    public class Question22
    {
        public static double ComputeTotalArea(string[] shapes)
        {
            double totalArea = 0;
            
            foreach (string shapeData in shapes)
            {
                string[] parts = shapeData.Split(' ');
                if (parts.Length < 2) continue;
                
                Shape shape = null;
                
                switch (parts[0])
                {
                    case "C":
                        if (parts.Length >= 2 && double.TryParse(parts[1], out double radius))
                        {
                            shape = new Circle(radius);
                        }
                        break;
                        
                    case "R":
                        if (parts.Length >= 3 && 
                            double.TryParse(parts[1], out double width) &&
                            double.TryParse(parts[2], out double height))
                        {
                            shape = new Rectangle(width, height);
                        }
                        break;
                        
                    case "T":
                        if (parts.Length >= 3 &&
                            double.TryParse(parts[1], out double baseLength) &&
                            double.TryParse(parts[2], out double triangleHeight))
                        {
                            shape = new Triangle(baseLength, triangleHeight);
                        }
                        break;
                }
                
                if (shape != null)
                {
                    totalArea += shape.CalculateArea();
                }
            }
            
            return Math.Round(totalArea, 2, MidpointRounding.AwayFromZero);
        }
        
        public static void Main(string[] args)
        {
            Console.Write("Enter number of shapes: ");
            int count = int.Parse(Console.ReadLine());
            
            string[] shapes = new string[count];
            Console.WriteLine("Enter shape data:");
            Console.WriteLine("C radius (Circle)");
            Console.WriteLine("R width height (Rectangle)");
            Console.WriteLine("T base height (Triangle)");
            
            for (int i = 0; i < count; i++)
            {
                Console.Write($"Shape {i + 1}: ");
                shapes[i] = Console.ReadLine();
            }
            
            double totalArea = ComputeTotalArea(shapes);
            Console.WriteLine($"Total Area: {totalArea}");
        }
    }
}