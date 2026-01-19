using System;

namespace TopBrains.Questions
{
    public class Question13
    {
        public static int GCD(int a, int b)
        {
            if (b == 0)
                return a;
            
            return GCD(b, a % b);
        }
        
        public static void Main(string[] args)
        {
            Console.Write("Enter first number: ");
            int a = int.Parse(Console.ReadLine());
            Console.Write("Enter second number: ");
            int b = int.Parse(Console.ReadLine());
            
            int result = GCD(a, b);
            Console.WriteLine($"GCD: {result}");
        }
    }
}