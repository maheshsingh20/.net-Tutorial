using System;
using System.Text.RegularExpressions;

namespace StringTutorial.RegularExpressions
{
    public class RegexBasics
    {
        public static void Run()
        {
            Console.WriteLine("String Regular Expressions Basics\n");

            // IsMatch - Check if pattern exists
            Console.WriteLine("1. IsMatch - Pattern Matching:");
            string email = "user@example.com";
            string pattern = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";
            bool isValid = Regex.IsMatch(email, pattern);
            Console.WriteLine($"   Email: '{email}'");
            Console.WriteLine($"   Is valid: {isValid}");

            // Match - Find first match
            Console.WriteLine("\n2. Match - Find First Occurrence:");
            string text = "My phone is 123-456-7890";
            string phonePattern = @"\d{3}-\d{3}-\d{4}";
            Match match = Regex.Match(text, phonePattern);
            if (match.Success)
            {
                Console.WriteLine($"   Text: '{text}'");
                Console.WriteLine($"   Found: '{match.Value}' at index {match.Index}");
            }

            // Matches - Find all matches
            Console.WriteLine("\n3. Matches - Find All Occurrences:");
            string sentence = "Call me at 123-456-7890 or 987-654-3210";
            MatchCollection matches = Regex.Matches(sentence, phonePattern);
            Console.WriteLine($"   Text: '{sentence}'");
            Console.WriteLine($"   Found {matches.Count} phone numbers:");
            foreach (Match m in matches)
            {
                Console.WriteLine($"      - {m.Value}");
            }

            // Replace
            Console.WriteLine("\n4. Replace - Pattern Replacement:");
            string original = "Hello 123 World 456";
            string replaced = Regex.Replace(original, @"\d+", "XXX");
            Console.WriteLine($"   Original: '{original}'");
            Console.WriteLine($"   Replaced: '{replaced}'");

            // Split
            Console.WriteLine("\n5. Split - Split by Pattern:");
            string data = "apple,banana;orange:grape";
            string[] items = Regex.Split(data, @"[,;:]");
            Console.WriteLine($"   Data: '{data}'");
            Console.WriteLine("   Split result:");
            foreach (string item in items)
            {
                Console.WriteLine($"      - {item}");
            }

            // Groups - Capture groups
            Console.WriteLine("\n6. Groups - Capture Groups:");
            string dateText = "Date: 2024-02-20";
            string datePattern = @"(\d{4})-(\d{2})-(\d{2})";
            Match dateMatch = Regex.Match(dateText, datePattern);
            if (dateMatch.Success)
            {
                Console.WriteLine($"   Text: '{dateText}'");
                Console.WriteLine($"   Year: {dateMatch.Groups[1].Value}");
                Console.WriteLine($"   Month: {dateMatch.Groups[2].Value}");
                Console.WriteLine($"   Day: {dateMatch.Groups[3].Value}");
            }

            // Common patterns
            Console.WriteLine("\n7. Common Regex Patterns:");
            Console.WriteLine("   Email: ^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$");
            Console.WriteLine("   Phone: \\d{3}-\\d{3}-\\d{4}");
            Console.WriteLine("   URL: https?://[\\w\\.-]+");
            Console.WriteLine("   Digits only: ^\\d+$");
            Console.WriteLine("   Letters only: ^[a-zA-Z]+$");
            Console.WriteLine("   Alphanumeric: ^[a-zA-Z0-9]+$");
        }
    }
}
