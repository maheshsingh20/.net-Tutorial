using System;
using System.Diagnostics;
using System.Text;
using System.Linq;

namespace StringTutorial.Performance
{
    public class PerformanceComparison
    {
        public static void Run()
        {
            Console.WriteLine("String Performance Comparison\n");

            int iterations = 10000;

            // Concatenation comparison
            Console.WriteLine($"1. Concatenation ({iterations} iterations):");
            
            Stopwatch sw1 = Stopwatch.StartNew();
            string result1 = "";
            for (int i = 0; i < iterations; i++)
            {
                result1 += "x";
            }
            sw1.Stop();
            Console.WriteLine($"   String +=: {sw1.ElapsedMilliseconds}ms");

            Stopwatch sw2 = Stopwatch.StartNew();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < iterations; i++)
            {
                sb.Append("x");
            }
            string result2 = sb.ToString();
            sw2.Stop();
            Console.WriteLine($"   StringBuilder: {sw2.ElapsedMilliseconds}ms");
            Console.WriteLine($"   StringBuilder is {sw1.ElapsedMilliseconds / Math.Max(1, sw2.ElapsedMilliseconds)}x faster");

            // String.Concat vs +
            Console.WriteLine("\n2. String.Concat vs + operator:");
            string[] parts = { "Hello", " ", "World", "!" };
            
            Stopwatch sw3 = Stopwatch.StartNew();
            for (int i = 0; i < iterations; i++)
            {
                string r = parts[0] + parts[1] + parts[2] + parts[3];
            }
            sw3.Stop();
            Console.WriteLine($"   + operator: {sw3.ElapsedMilliseconds}ms");

            Stopwatch sw4 = Stopwatch.StartNew();
            for (int i = 0; i < iterations; i++)
            {
                string r = String.Concat(parts);
            }
            sw4.Stop();
            Console.WriteLine($"   String.Concat: {sw4.ElapsedMilliseconds}ms");

            // String.Join vs StringBuilder
            Console.WriteLine("\n3. String.Join vs StringBuilder:");
            string[] words = Enumerable.Range(0, 100).Select(i => $"word{i}").ToArray();
            
            Stopwatch sw5 = Stopwatch.StartNew();
            for (int i = 0; i < 1000; i++)
            {
                string r = String.Join(" ", words);
            }
            sw5.Stop();
            Console.WriteLine($"   String.Join: {sw5.ElapsedMilliseconds}ms");

            Stopwatch sw6 = Stopwatch.StartNew();
            for (int i = 0; i < 1000; i++)
            {
                StringBuilder sbTemp = new StringBuilder();
                foreach (string word in words)
                {
                    sbTemp.Append(word).Append(" ");
                }
                string r = sbTemp.ToString();
            }
            sw6.Stop();
            Console.WriteLine($"   StringBuilder: {sw6.ElapsedMilliseconds}ms");

            // Comparison methods
            Console.WriteLine("\n4. String Comparison Methods:");
            string str1 = "Hello World";
            string str2 = "hello world";
            
            Stopwatch sw7 = Stopwatch.StartNew();
            for (int i = 0; i < iterations; i++)
            {
                bool r = str1.ToLower() == str2.ToLower();
            }
            sw7.Stop();
            Console.WriteLine($"   ToLower() comparison: {sw7.ElapsedMilliseconds}ms");

            Stopwatch sw8 = Stopwatch.StartNew();
            for (int i = 0; i < iterations; i++)
            {
                bool r = str1.Equals(str2, StringComparison.OrdinalIgnoreCase);
            }
            sw8.Stop();
            Console.WriteLine($"   OrdinalIgnoreCase: {sw8.ElapsedMilliseconds}ms");

            // Substring vs Span
            Console.WriteLine("\n5. Substring Operations:");
            string longString = new string('x', 1000);
            
            Stopwatch sw9 = Stopwatch.StartNew();
            for (int i = 0; i < iterations; i++)
            {
                string sub = longString.Substring(0, 100);
            }
            sw9.Stop();
            Console.WriteLine($"   Substring: {sw9.ElapsedMilliseconds}ms");

            Stopwatch sw10 = Stopwatch.StartNew();
            for (int i = 0; i < iterations; i++)
            {
                ReadOnlySpan<char> span = longString.AsSpan(0, 100);
            }
            sw10.Stop();
            Console.WriteLine($"   Span<char>: {sw10.ElapsedMilliseconds}ms");

            // Best practices
            Console.WriteLine("\n6. Best Practices:");
            Console.WriteLine("   - Use StringBuilder for multiple concatenations");
            Console.WriteLine("   - Use String.Join for joining arrays");
            Console.WriteLine("   - Use StringComparison for case-insensitive comparisons");
            Console.WriteLine("   - Use Span<char> for substring operations when possible");
            Console.WriteLine("   - Avoid ToLower()/ToUpper() in loops");
        }
    }
}
