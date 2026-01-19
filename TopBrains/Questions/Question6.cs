using System;

namespace TopBrains.Questions
{
    public class Question6
    {
        public static int FindLargest(int a, int b, int c)
        {
            if (a >= b && a >= c)
                return a;
            else if (b >= a && b >= c)
                return b;
            else
                return c;
        }
        
        public static void Main(string[] args)
        {
            Console.Write("Enter first number: ");
            int a = int.Parse(Console.ReadLine());
            Console.Write("Enter second number: ");
            int b = int.Parse(Console.ReadLine());
            Console.Write("Enter third number: ");
            int c = int.Parse(Console.ReadLine());
            
            int largest = FindLargest(a, b, c);
            Console.WriteLine($"Largest: {largest}");
        }
    }
}