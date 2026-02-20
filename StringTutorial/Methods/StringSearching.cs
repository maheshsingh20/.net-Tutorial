using System;

namespace StringTutorial.Methods
{
    public class StringSearching
    {
        public static void Run()
        {
            Console.WriteLine("=== String Searching Methods ===\n");

            string text = "The quick brown fox jumps over the lazy dog";

            // IndexOf
            Console.WriteLine("1. IndexOf:");
            Console.WriteLine($"   Text: '{text}'");
            Console.WriteLine($"   IndexOf('quick'): {text.IndexOf("quick")}");
            Console.WriteLine($"   IndexOf('fox'): {text.IndexOf("fox")}");
            Console.WriteLine($"   IndexOf('cat'): {text.IndexOf("cat")} (not found)");
            Console.WriteLine($"   IndexOf('o'): {text.IndexOf('o')} (first occurrence)");

            // LastIndexOf
            Console.WriteLine("\n2. LastIndexOf:");
            Console.WriteLine($"   LastIndexOf('o'): {text.LastIndexOf('o')} (last occurrence)");
            Console.WriteLine($"   LastIndexOf('the'): {text.LastIndexOf("the")}");

            // IndexOfAny
            Console.WriteLine("\n3. IndexOfAny:");
            char[] vowels = { 'a', 'e', 'i', 'o', 'u' };
            Console.WriteLine($"   IndexOfAny(vowels): {text.IndexOfAny(vowels)}");
            Console.WriteLine($"   First vowel found at index: {text.IndexOfAny(vowels)} ('{text[text.IndexOfAny(vowels)]}')");

            // LastIndexOfAny
            Console.WriteLine("\n4. LastIndexOfAny:");
            Console.WriteLine($"   LastIndexOfAny(vowels): {text.LastIndexOfAny(vowels)}");

            // Contains
            Console.WriteLine("\n5. Contains:");
            Console.WriteLine($"   Contains('fox'): {text.Contains("fox")}");
            Console.WriteLine($"   Contains('cat'): {text.Contains("cat")}");

            // Finding all occurrences
            Console.WriteLine("\n6. Finding All Occurrences:");
            string sample = "hello world, hello universe, hello everyone";
            string searchWord = "hello";
            int index = 0;
            int count = 0;
            Console.WriteLine($"   Text: '{sample}'");
            Console.WriteLine($"   Searching for: '{searchWord}'");
            
            while ((index = sample.IndexOf(searchWord, index)) != -1)
            {
                count++;
                Console.WriteLine($"   Found at index: {index}");
                index += searchWord.Length;
            }
            Console.WriteLine($"   Total occurrences: {count}");
        }
    }
}
