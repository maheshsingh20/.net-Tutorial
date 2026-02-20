using System;
using System.Linq;

namespace StringTutorial.Advanced
{
    public class StringSplitJoin
    {
        public static void Run()
        {
            Console.WriteLine("=== String Split and Join ===\n");

            // Split by single character
            Console.WriteLine("1. Split by Single Character:");
            string csv = "apple,banana,orange,grape";
            string[] fruits = csv.Split(',');
            Console.WriteLine($"   Original: '{csv}'");
            Console.WriteLine("   After Split(','):");
            foreach (string fruit in fruits)
            {
                Console.WriteLine($"      - {fruit}");
            }

            // Split by multiple characters
            Console.WriteLine("\n2. Split by Multiple Characters:");
            string text = "apple;banana,orange:grape";
            char[] separators = { ',', ';', ':' };
            string[] items = text.Split(separators);
            Console.WriteLine($"   Original: '{text}'");
            Console.WriteLine("   After Split(',', ';', ':'):");
            foreach (string item in items)
            {
                Console.WriteLine($"      - {item}");
            }

            // Split by string
            Console.WriteLine("\n3. Split by String:");
            string sentence = "Hello and welcome and goodbye";
            string[] words = sentence.Split(new string[] { " and " }, StringSplitOptions.None);
            Console.WriteLine($"   Original: '{sentence}'");
            Console.WriteLine("   After Split(' and '):");
            foreach (string word in words)
            {
                Console.WriteLine($"      - {word}");
            }

            // Split with options
            Console.WriteLine("\n4. Split with StringSplitOptions:");
            string withSpaces = "apple,,banana,  ,orange";
            string[] result1 = withSpaces.Split(',');
            string[] result2 = withSpaces.Split(',', StringSplitOptions.RemoveEmptyEntries);
            string[] result3 = withSpaces.Split(',', StringSplitOptions.TrimEntries);
            
            Console.WriteLine($"   Original: '{withSpaces}'");
            Console.WriteLine($"   Default: [{string.Join(", ", result1.Select(s => $"'{s}'"))}]");
            Console.WriteLine($"   RemoveEmptyEntries: [{string.Join(", ", result2.Select(s => $"'{s}'"))}]");
            Console.WriteLine($"   TrimEntries: [{string.Join(", ", result3.Select(s => $"'{s}'"))}]");

            // Split with count limit
            Console.WriteLine("\n5. Split with Count Limit:");
            string data = "one,two,three,four,five";
            string[] limited = data.Split(',', 3);
            Console.WriteLine($"   Original: '{data}'");
            Console.WriteLine($"   Split(',', 3): [{string.Join(", ", limited.Select(s => $"'{s}'"))}]");

            // Join
            Console.WriteLine("\n6. String.Join:");
            string[] names = { "Alice", "Bob", "Charlie" };
            string joined1 = string.Join(", ", names);
            string joined2 = string.Join(" | ", names);
            Console.WriteLine($"   Array: [{string.Join(", ", names)}]");
            Console.WriteLine($"   Join(', '): '{joined1}'");
            Console.WriteLine($"   Join(' | '): '{joined2}'");

            // Join with numbers
            Console.WriteLine("\n7. Join with Numbers:");
            int[] numbers = { 1, 2, 3, 4, 5 };
            string numStr = string.Join("-", numbers);
            Console.WriteLine($"   Numbers: [{string.Join(", ", numbers)}]");
            Console.WriteLine($"   Join('-'): '{numStr}'");

            // Concat
            Console.WriteLine("\n8. String.Concat:");
            string concat1 = string.Concat("Hello", " ", "World");
            string concat2 = string.Concat(names);
            Console.WriteLine($"   Concat('Hello', ' ', 'World'): '{concat1}'");
            Console.WriteLine($"   Concat(names): '{concat2}'");

            // Split lines
            Console.WriteLine("\n9. Split Lines:");
            string multiline = @"Line 1
Line 2
Line 3";
            string[] lines = multiline.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            Console.WriteLine("   Multiline text split into:");
            for (int i = 0; i < lines.Length; i++)
            {
                Console.WriteLine($"      Line {i + 1}: '{lines[i]}'");
            }
        }
    }
}
