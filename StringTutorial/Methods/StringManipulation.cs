using System;

namespace StringTutorial.Methods
{
    public class StringManipulation
    {
        public static void Run()
        {
            Console.WriteLine("=== String Manipulation Methods ===\n");

            string text = "  Hello, World!  ";

            // ToUpper and ToLower
            Console.WriteLine("1. Case Conversion:");
            Console.WriteLine($"   Original: '{text}'");
            Console.WriteLine($"   ToUpper(): '{text.ToUpper()}'");
            Console.WriteLine($"   ToLower(): '{text.ToLower()}'");

            // Trim methods
            Console.WriteLine("\n2. Trim Methods:");
            Console.WriteLine($"   Original: '{text}' (Length: {text.Length})");
            Console.WriteLine($"   Trim(): '{text.Trim()}' (Length: {text.Trim().Length})");
            Console.WriteLine($"   TrimStart(): '{text.TrimStart()}'");
            Console.WriteLine($"   TrimEnd(): '{text.TrimEnd()}'");

            // Substring
            Console.WriteLine("\n3. Substring:");
            string str = "Hello, World!";
            Console.WriteLine($"   Original: '{str}'");
            Console.WriteLine($"   Substring(0, 5): '{str.Substring(0, 5)}'");
            Console.WriteLine($"   Substring(7): '{str.Substring(7)}'");
            Console.WriteLine($"   Substring(7, 5): '{str.Substring(7, 5)}'");

            // Replace
            Console.WriteLine("\n4. Replace:");
            Console.WriteLine($"   Original: '{str}'");
            Console.WriteLine($"   Replace('World', 'C#'): '{str.Replace("World", "C#")}'");
            Console.WriteLine($"   Replace('o', 'O'): '{str.Replace('o', 'O')}'");

            // Insert
            Console.WriteLine("\n5. Insert:");
            Console.WriteLine($"   Original: '{str}'");
            Console.WriteLine($"   Insert(5, ' Beautiful'): '{str.Insert(5, " Beautiful")}'");

            // Remove
            Console.WriteLine("\n6. Remove:");
            Console.WriteLine($"   Original: '{str}'");
            Console.WriteLine($"   Remove(5): '{str.Remove(5)}'");
            Console.WriteLine($"   Remove(5, 7): '{str.Remove(5, 7)}'");

            // PadLeft and PadRight
            Console.WriteLine("\n7. Padding:");
            string num = "42";
            Console.WriteLine($"   Original: '{num}'");
            Console.WriteLine($"   PadLeft(5): '{num.PadLeft(5)}'");
            Console.WriteLine($"   PadLeft(5, '0'): '{num.PadLeft(5, '0')}'");
            Console.WriteLine($"   PadRight(5, '*'): '{num.PadRight(5, '*')}'");
        }
    }
}
