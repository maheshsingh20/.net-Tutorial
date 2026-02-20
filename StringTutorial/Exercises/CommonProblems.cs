using System;
using System.Linq;

namespace StringTutorial.Exercises
{
    public class CommonProblems
    {
        public static void Run()
        {
            Console.WriteLine("=== Common String Problems ===\n");

            // 1. Reverse a string
            Console.WriteLine("1. Reverse a String:");
            string original = "Hello World";
            string reversed = ReverseString(original);
            Console.WriteLine($"   Original: '{original}'");
            Console.WriteLine($"   Reversed: '{reversed}'");

            // 2. Check palindrome
            Console.WriteLine("\n2. Check Palindrome:");
            string[] testWords = { "radar", "hello", "level", "world" };
            foreach (string word in testWords)
            {
                Console.WriteLine($"   '{word}' is palindrome: {IsPalindrome(word)}");
            }

            // 3. Count vowels and consonants
            Console.WriteLine("\n3. Count Vowels and Consonants:");
            string text = "Hello World";
            var (vowels, consonants) = CountVowelsConsonants(text);
            Console.WriteLine($"   Text: '{text}'");
            Console.WriteLine($"   Vowels: {vowels}, Consonants: {consonants}");

            // 4. Remove duplicates
            Console.WriteLine("\n4. Remove Duplicate Characters:");
            string withDuplicates = "programming";
            string noDuplicates = RemoveDuplicates(withDuplicates);
            Console.WriteLine($"   Original: '{withDuplicates}'");
            Console.WriteLine($"   No Duplicates: '{noDuplicates}'");

            // 5. Count word occurrences
            Console.WriteLine("\n5. Count Word Occurrences:");
            string sentence = "the quick brown fox jumps over the lazy dog the end";
            string searchWord = "the";
            int count = CountWordOccurrences(sentence, searchWord);
            Console.WriteLine($"   Sentence: '{sentence}'");
            Console.WriteLine($"   Word '{searchWord}' appears {count} times");

            // 6. Title case
            Console.WriteLine("\n6. Convert to Title Case:");
            string lowercase = "hello world from c#";
            string titleCase = ToTitleCase(lowercase);
            Console.WriteLine($"   Original: '{lowercase}'");
            Console.WriteLine($"   Title Case: '{titleCase}'");

            // 7. Remove whitespace
            Console.WriteLine("\n7. Remove All Whitespace:");
            string withSpaces = "  Hello   World  ";
            string noSpaces = RemoveWhitespace(withSpaces);
            Console.WriteLine($"   Original: '{withSpaces}'");
            Console.WriteLine($"   No Whitespace: '{noSpaces}'");

            // 8. Check anagram
            Console.WriteLine("\n8. Check Anagram:");
            string word1 = "listen";
            string word2 = "silent";
            Console.WriteLine($"   '{word1}' and '{word2}' are anagrams: {AreAnagrams(word1, word2)}");
        }

        static string ReverseString(string str)
        {
            char[] chars = str.ToCharArray();
            Array.Reverse(chars);
            return new string(chars);
        }

        static bool IsPalindrome(string str)
        {
            string cleaned = str.ToLower().Replace(" ", "");
            string reversed = ReverseString(cleaned);
            return cleaned == reversed;
        }

        static (int vowels, int consonants) CountVowelsConsonants(string str)
        {
            int vowels = 0, consonants = 0;
            string vowelChars = "aeiouAEIOU";
            
            foreach (char c in str)
            {
                if (char.IsLetter(c))
                {
                    if (vowelChars.Contains(c))
                        vowels++;
                    else
                        consonants++;
                }
            }
            return (vowels, consonants);
        }

        static string RemoveDuplicates(string str)
        {
            return new string(str.Distinct().ToArray());
        }

        static int CountWordOccurrences(string text, string word)
        {
            string[] words = text.ToLower().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            return words.Count(w => w == word.ToLower());
        }

        static string ToTitleCase(string str)
        {
            string[] words = str.Split(' ');
            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].Length > 0)
                {
                    words[i] = char.ToUpper(words[i][0]) + words[i].Substring(1).ToLower();
                }
            }
            return string.Join(" ", words);
        }

        static string RemoveWhitespace(string str)
        {
            return string.Concat(str.Where(c => !char.IsWhiteSpace(c)));
        }

        static bool AreAnagrams(string str1, string str2)
        {
            string sorted1 = string.Concat(str1.ToLower().OrderBy(c => c));
            string sorted2 = string.Concat(str2.ToLower().OrderBy(c => c));
            return sorted1 == sorted2;
        }
    }
}
