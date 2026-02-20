using System;

namespace StringTutorial.Methods
{
    public class StringComparisonDemo
    {
        public static void Run()
        {
            Console.WriteLine("=== String Comparison Methods ===\n");

            string str1 = "Hello";
            string str2 = "hello";
            string str3 = "Hello";

            // Equals method
            Console.WriteLine("1. Equals Method:");
            Console.WriteLine($"   '{str1}'.Equals('{str2}'): {str1.Equals(str2)}");
            Console.WriteLine($"   '{str1}'.Equals('{str3}'): {str1.Equals(str3)}");

            // Case-insensitive comparison
            Console.WriteLine("\n2. Case-Insensitive Comparison:");
            Console.WriteLine($"   '{str1}'.Equals('{str2}', StringComparison.OrdinalIgnoreCase): {str1.Equals(str2, System.StringComparison.OrdinalIgnoreCase)}");

            // == operator
            Console.WriteLine("\n3. == Operator:");
            Console.WriteLine($"   '{str1}' == '{str2}': {str1 == str2}");
            Console.WriteLine($"   '{str1}' == '{str3}': {str1 == str3}");

            // CompareTo method
            Console.WriteLine("\n4. CompareTo Method:");
            Console.WriteLine($"   '{str1}'.CompareTo('{str2}'): {str1.CompareTo(str2)}");
            Console.WriteLine($"   '{str2}'.CompareTo('{str1}'): {str2.CompareTo(str1)}");
            Console.WriteLine($"   '{str1}'.CompareTo('{str3}'): {str1.CompareTo(str3)}");
            Console.WriteLine("   (Returns: 0 if equal, <0 if less, >0 if greater)");

            // String.Compare static method
            Console.WriteLine("\n5. String.Compare Static Method:");
            Console.WriteLine($"   String.Compare('{str1}', '{str2}'): {String.Compare(str1, str2)}");
            Console.WriteLine($"   String.Compare('{str1}', '{str2}', true): {String.Compare(str1, str2, true)}");

            // StartsWith and EndsWith
            Console.WriteLine("\n6. StartsWith and EndsWith:");
            string text = "Hello, World!";
            Console.WriteLine($"   '{text}'.StartsWith('Hello'): {text.StartsWith("Hello")}");
            Console.WriteLine($"   '{text}'.EndsWith('World!'): {text.EndsWith("World!")}");
            Console.WriteLine($"   '{text}'.EndsWith('world!', StringComparison.OrdinalIgnoreCase): {text.EndsWith("world!", System.StringComparison.OrdinalIgnoreCase)}");

            // Contains method
            Console.WriteLine("\n7. Contains Method:");
            Console.WriteLine($"   '{text}'.Contains('World'): {text.Contains("World")}");
            Console.WriteLine($"   '{text}'.Contains('world'): {text.Contains("world")}");
        }
    }
}
