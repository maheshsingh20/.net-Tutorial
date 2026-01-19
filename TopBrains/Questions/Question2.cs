using System;

namespace TopBrains.Questions
{
    public class Question2
    {
        // Method 1: Using ref parameters
        public static void SwapWithRef(ref int a, ref int b)
        {
            a = a + b;
            b = a - b;
            a = a - b;
        }
        
        // Method 2: Using out parameters
        public static void SwapWithOut(int a, int b, out int swappedA, out int swappedB)
        {
            swappedA = b;
            swappedB = a;
        }
        public static void Main(string[] args)
        {
            Console.Write("Enter first number: ");
            int num1 = int.Parse(Console.ReadLine());
            Console.Write("Enter second number: ");
            int num2 = int.Parse(Console.ReadLine());
            Console.WriteLine($"Original: a = {num1}, b = {num2}");
            // Method 1: ref
            int refA = num1, refB = num2;
            SwapWithRef(ref refA, ref refB);
            Console.WriteLine($"After ref swap: a = {refA}, b = {refB}");
            
            // Method 2: out
            SwapWithOut(num1, num2, out int outA, out int outB);
            Console.WriteLine($"After out swap: a = {outA}, b = {outB}");
        }
    }
}