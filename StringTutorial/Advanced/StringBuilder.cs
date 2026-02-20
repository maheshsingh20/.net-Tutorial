using System;
using System.Text;

namespace StringTutorial.Advanced
{
    public class StringBuilderDemo
    {
        public static void Run()
        {
            Console.WriteLine("=== StringBuilder - Mutable Strings ===\n");

            // Why StringBuilder?
            Console.WriteLine("1. Why StringBuilder?");
            Console.WriteLine("   String is immutable - each modification creates a new string");
            Console.WriteLine("   StringBuilder is mutable - modifications happen in-place");
            Console.WriteLine("   Use StringBuilder for multiple string concatenations\n");

            // Creating StringBuilder
            Console.WriteLine("2. Creating StringBuilder:");
            StringBuilder sb1 = new StringBuilder();
            StringBuilder sb2 = new StringBuilder("Hello");
            StringBuilder sb3 = new StringBuilder(100); // Initial capacity
            Console.WriteLine($"   Empty: '{sb1}'");
            Console.WriteLine($"   With text: '{sb2}'");
            Console.WriteLine($"   With capacity: Capacity={sb3.Capacity}");

            // Append
            Console.WriteLine("\n3. Append:");
            StringBuilder sb = new StringBuilder("Hello");
            Console.WriteLine($"   Initial: '{sb}'");
            sb.Append(" World");
            Console.WriteLine($"   After Append(' World'): '{sb}'");
            sb.Append('!');
            Console.WriteLine($"   After Append('!'): '{sb}'");

            // AppendLine
            Console.WriteLine("\n4. AppendLine:");
            StringBuilder lines = new StringBuilder();
            lines.AppendLine("Line 1");
            lines.AppendLine("Line 2");
            lines.AppendLine("Line 3");
            Console.WriteLine($"   Result:\n{lines}");

            // AppendFormat
            Console.WriteLine("5. AppendFormat:");
            StringBuilder formatted = new StringBuilder();
            formatted.AppendFormat("Name: {0}, Age: {1}", "Alice", 25);
            Console.WriteLine($"   {formatted}");

            // Insert
            Console.WriteLine("\n6. Insert:");
            StringBuilder insert = new StringBuilder("Hello World");
            Console.WriteLine($"   Original: '{insert}'");
            insert.Insert(5, " Beautiful");
            Console.WriteLine($"   After Insert(5, ' Beautiful'): '{insert}'");

            // Remove
            Console.WriteLine("\n7. Remove:");
            StringBuilder remove = new StringBuilder("Hello Beautiful World");
            Console.WriteLine($"   Original: '{remove}'");
            remove.Remove(5, 10);
            Console.WriteLine($"   After Remove(5, 10): '{remove}'");

            // Replace
            Console.WriteLine("\n8. Replace:");
            StringBuilder replace = new StringBuilder("Hello World");
            Console.WriteLine($"   Original: '{replace}'");
            replace.Replace("World", "C#");
            Console.WriteLine($"   After Replace('World', 'C#'): '{replace}'");

            // Clear
            Console.WriteLine("\n9. Clear:");
            StringBuilder clear = new StringBuilder("Hello World");
            Console.WriteLine($"   Before Clear: '{clear}' (Length: {clear.Length})");
            clear.Clear();
            Console.WriteLine($"   After Clear: '{clear}' (Length: {clear.Length})");

            // Performance comparison
            Console.WriteLine("\n10. Performance Comparison:");
            Console.WriteLine("    Building string with 1000 concatenations...");
            
            // Using String (slow)
            var watch1 = System.Diagnostics.Stopwatch.StartNew();
            string str = "";
            for (int i = 0; i < 1000; i++)
            {
                str += "x";
            }
            watch1.Stop();
            Console.WriteLine($"    String concatenation: {watch1.ElapsedMilliseconds}ms");

            // Using StringBuilder (fast)
            var watch2 = System.Diagnostics.Stopwatch.StartNew();
            StringBuilder sbPerf = new StringBuilder();
            for (int i = 0; i < 1000; i++)
            {
                sbPerf.Append("x");
            }
            watch2.Stop();
            Console.WriteLine($"    StringBuilder: {watch2.ElapsedMilliseconds}ms");
            Console.WriteLine($"    StringBuilder is {watch1.ElapsedMilliseconds / (watch2.ElapsedMilliseconds + 1)}x faster!");
        }
    }
}
