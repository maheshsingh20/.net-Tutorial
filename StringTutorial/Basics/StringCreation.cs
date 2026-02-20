using System;

namespace StringTutorial.Basics
{
    public class StringCreation
    {
        public static void Run()
        {
            Console.WriteLine("=== String Creation Methods ===\n");

            // Method 1: String literal
            string str1 = "Hello, World!";
            Console.WriteLine($"1. String Literal: {str1}");

            // Method 2: String constructor with char array
            char[] chars = { 'H', 'e', 'l', 'l', 'o' };
            string str2 = new string(chars);
            Console.WriteLine($"2. From Char Array: {str2}");

            // Method 3: String constructor with repeated char
            string str3 = new string('*', 10);
            Console.WriteLine($"3. Repeated Char: {str3}");

            // Method 4: Empty string
            string str4 = string.Empty;
            string str5 = "";
            Console.WriteLine($"4. Empty String: '{str4}' (Length: {str4.Length})");

            // Method 5: Null string
            string str6 = null;
            Console.WriteLine($"5. Null String: {str6 ?? "null"}");

            // Method 6: Verbatim string (preserves formatting)
            string str7 = @"C:\Users\Documents\file.txt";
            Console.WriteLine($"6. Verbatim String: {str7}");

            // Method 7: Interpolated string
            string name = "Alice";
            int age = 25;
            string str8 = $"Name: {name}, Age: {age}";
            Console.WriteLine($"7. Interpolated String: {str8}");

            // Method 8: Multi-line string
            string str9 = @"Line 1
Line 2
Line 3";
            Console.WriteLine($"8. Multi-line String:\n{str9}");

            Console.WriteLine("\n=== String Immutability ===");
            string original = "Hello";
            string modified = original + " World";
            Console.WriteLine($"Original: {original}");
            Console.WriteLine($"Modified: {modified}");
            Console.WriteLine("Note: Original string remains unchanged (immutable)");
        }
    }
}
