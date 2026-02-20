using System;

namespace StringTutorial.Advanced
{
    public class StringFormatting
    {
        public static void Run()
        {
            Console.WriteLine("=== String Formatting ===\n");

            // String interpolation
            Console.WriteLine("1. String Interpolation:");
            string name = "Alice";
            int age = 25;
            Console.WriteLine($"   Name: {name}, Age: {age}");
            Console.WriteLine($"   Expression: 10 + 20 = {10 + 20}");

            // String.Format
            Console.WriteLine("\n2. String.Format:");
            string formatted = String.Format("Name: {0}, Age: {1}", name, age);
            Console.WriteLine($"   {formatted}");

            // Composite formatting
            Console.WriteLine("\n3. Composite Formatting:");
            Console.WriteLine("   Name: {0}, Age: {1}, City: {2}", name, age, "New York");

            // Format specifiers
            Console.WriteLine("\n4. Format Specifiers:");
            double price = 1234.5678;
            Console.WriteLine($"   Currency: {price:C}");
            Console.WriteLine($"   Fixed-point (2 decimals): {price:F2}");
            Console.WriteLine($"   Number with commas: {price:N}");
            Console.WriteLine($"   Percentage: {0.85:P}");

            // Alignment
            Console.WriteLine("\n5. Alignment:");
            Console.WriteLine($"   {"Left",-10}|{"Center",10}|{"Right",10}");
            Console.WriteLine($"   {name,-10}|{age,10}|{price,10:F2}");

            // Date formatting
            Console.WriteLine("\n6. Date Formatting:");
            DateTime now = DateTime.Now;
            Console.WriteLine($"   Short date: {now:d}");
            Console.WriteLine($"   Long date: {now:D}");
            Console.WriteLine($"   Short time: {now:t}");
            Console.WriteLine($"   Long time: {now:T}");
            Console.WriteLine($"   Custom: {now:yyyy-MM-dd HH:mm:ss}");

            // Number formatting
            Console.WriteLine("\n7. Number Formatting:");
            int number = 42;
            Console.WriteLine($"   Decimal: {number:D5}");
            Console.WriteLine($"   Hexadecimal: {number:X}");
            Console.WriteLine($"   Binary: {Convert.ToString(number, 2)}");

            // Padding
            Console.WriteLine("\n8. Padding with Interpolation:");
            Console.WriteLine($"   {"Item",-15}{"Quantity",10}{"Price",10}");
            Console.WriteLine($"   {"Apple",-15}{5,10}{1.99,10:F2}");
            Console.WriteLine($"   {"Banana",-15}{3,10}{0.79,10:F2}");

            // Escape sequences
            Console.WriteLine("\n9. Escape Sequences:");
            Console.WriteLine("   Newline: Line1\\nLine2");
            Console.WriteLine("   Tab: Column1\\tColumn2");
            Console.WriteLine("   Quote: He said \\\"Hello\\\"");
            Console.WriteLine("   Backslash: C:\\\\Users\\\\Documents");

            // Verbatim strings
            Console.WriteLine("\n10. Verbatim Strings:");
            string path = @"C:\Users\Documents\file.txt";
            Console.WriteLine($"    Path: {path}");
            string multiline = @"Line 1
Line 2
Line 3";
            Console.WriteLine($"    Multiline:\n{multiline}");
        }
    }
}
