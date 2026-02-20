using System;
using System.Text;

namespace StringTutorial.Immutability
{
    public class ImmutabilityDemo
    {
        public static void Run()
        {
            Console.WriteLine("String Immutability Demonstration\n");

            // String immutability
            Console.WriteLine("1. String Immutability:");
            string str1 = "Hello";
            string str2 = str1;
            Console.WriteLine($"   str1: '{str1}' (Address: {str1.GetHashCode()})");
            Console.WriteLine($"   str2: '{str2}' (Address: {str2.GetHashCode()})");
            
            str1 = str1 + " World";
            Console.WriteLine($"\n   After str1 += ' World':");
            Console.WriteLine($"   str1: '{str1}' (Address: {str1.GetHashCode()})");
            Console.WriteLine($"   str2: '{str2}' (Address: {str2.GetHashCode()})");
            Console.WriteLine("   Note: str1 now points to a NEW string object");

            // String interning
            Console.WriteLine("\n2. String Interning:");
            string a = "hello";
            string b = "hello";
            string c = new string(new char[] { 'h', 'e', 'l', 'l', 'o' });
            
            Console.WriteLine($"   a: '{a}' (Address: {a.GetHashCode()})");
            Console.WriteLine($"   b: '{b}' (Address: {b.GetHashCode()})");
            Console.WriteLine($"   c: '{c}' (Address: {c.GetHashCode()})");
            Console.WriteLine($"   a == b: {a == b}");
            Console.WriteLine($"   ReferenceEquals(a, b): {ReferenceEquals(a, b)}");
            Console.WriteLine($"   ReferenceEquals(a, c): {ReferenceEquals(a, c)}");

            // String.Intern
            Console.WriteLine("\n3. String.Intern Method:");
            string d = String.Intern(c);
            Console.WriteLine($"   d = String.Intern(c)");
            Console.WriteLine($"   ReferenceEquals(a, d): {ReferenceEquals(a, d)}");
            Console.WriteLine("   Now d references the same interned string as a");

            // Performance impact
            Console.WriteLine("\n4. Performance Impact of Immutability:");
            Console.WriteLine("   Concatenating 1000 strings...");
            
            var watch1 = System.Diagnostics.Stopwatch.StartNew();
            string result1 = "";
            for (int i = 0; i < 1000; i++)
            {
                result1 += "x";
            }
            watch1.Stop();
            Console.WriteLine($"   String concatenation: {watch1.ElapsedMilliseconds}ms");
            Console.WriteLine($"   (Creates 1000 new string objects)");

            var watch2 = System.Diagnostics.Stopwatch.StartNew();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 1000; i++)
            {
                sb.Append("x");
            }
            string result2 = sb.ToString();
            watch2.Stop();
            Console.WriteLine($"   StringBuilder: {watch2.ElapsedMilliseconds}ms");
            Console.WriteLine($"   (Modifies internal buffer, creates 1 final string)");

            // Memory allocation
            Console.WriteLine("\n5. Memory Allocation:");
            Console.WriteLine("   Each string modification creates a new object:");
            string original = "Hello";
            Console.WriteLine($"   Original: '{original}' (Hash: {original.GetHashCode()})");
            
            string modified1 = original.ToUpper();
            Console.WriteLine($"   ToUpper(): '{modified1}' (Hash: {modified1.GetHashCode()})");
            
            string modified2 = original.Replace('l', 'L');
            Console.WriteLine($"   Replace(): '{modified2}' (Hash: {modified2.GetHashCode()})");
            
            string modified3 = original + "!";
            Console.WriteLine($"   Concat: '{modified3}' (Hash: {modified3.GetHashCode()})");
            
            Console.WriteLine("\n   All operations created NEW string objects");
            Console.WriteLine($"   Original unchanged: '{original}'");
        }
    }
}
