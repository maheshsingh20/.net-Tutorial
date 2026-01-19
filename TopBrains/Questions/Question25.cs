using System;

namespace TopBrains.Questions
{
    public class Question25
    {
        public static double CalculateCircleArea(double radius)
        {
            double area = Math.PI * radius * radius;
            return Math.Round(area, 2, MidpointRounding.AwayFromZero);
        }
        
        public static void Main(string[] args)
        {
            Console.Write("Enter radius: ");
            double radius = double.Parse(Console.ReadLine());
            
            double area = CalculateCircleArea(radius);
            Console.WriteLine($"Area of circle with radius {radius}: {area}");
        }
    }
}