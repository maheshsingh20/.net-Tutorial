using System;
using System.Linq;
using System.Text;

namespace StringTutorial.Exercises
{
    public class PracticeProblems
    {
        public static void Run()
        {
            Console.WriteLine("=== Practice Problems ===\n");

            // 1. Find longest word
            Console.WriteLine("1. Find Longest Word:");
            string sentence1 = "The quick brown fox jumps over the lazy dog";
            string longest = FindLongestWord(sentence1);
            Console.WriteLine($"   Sentence: '{sentence1}'");
            Console.WriteLine($"   Longest word: '{longest}' (Length: {longest.Length})");

            // 2. Count each character
            Console.WriteLine("\n2. Count Each Character:");
            string text = "hello";
            var charCount = CountCharacters(text);
            Console.WriteLine($"   Text: '{text}'");
            foreach (var kvp in charCount)
            {
                Console.WriteLine($"   '{kvp.Key}': {kvp.Value}");
            }

            // 3. Remove specific character
            Console.WriteLine("\n3. Remove Specific Character:");
            string original = "Hello World";
            char toRemove = 'l';
            string removed = RemoveCharacter(original, toRemove);
            Console.WriteLine($"   Original: '{original}'");
            Console.WriteLine($"   Remove '{toRemove}': '{removed}'");

            // 4. First non-repeating character
            Console.WriteLine("\n4. First Non-Repeating Character:");
            string[] testStrings = { "swiss", "level", "aabbcc", "abcdef" };
            foreach (string str in testStrings)
            {
                char? result = FirstNonRepeatingChar(str);
                Console.WriteLine($"   '{str}': {(result.HasValue ? $"'{result.Value}'" : "None")}");
            }

            // 5. Compress string
            Console.WriteLine("\n5. String Compression:");
            string[] compressTest = { "aabcccccaaa", "abc", "aabbcc" };
            foreach (string str in compressTest)
            {
                string compressed = CompressString(str);
                Console.WriteLine($"   '{str}' → '{compressed}'");
            }

            // 6. Check rotation
            Console.WriteLine("\n6. Check String Rotation:");
            string s1 = "waterbottle";
            string s2 = "erbottlewat";
            Console.WriteLine($"   '{s1}' and '{s2}' are rotations: {IsRotation(s1, s2)}");

            // 7. Remove consecutive duplicates
            Console.WriteLine("\n7. Remove Consecutive Duplicates:");
            string withDups = "aabbccddaabbcc";
            string noDups = RemoveConsecutiveDuplicates(withDups);
            Console.WriteLine($"   Original: '{withDups}'");
            Console.WriteLine($"   Result: '{noDups}'");

            // 8. Word frequency
            Console.WriteLine("\n8. Word Frequency:");
            string paragraph = "the quick brown fox jumps over the lazy dog the fox";
            var wordFreq = WordFrequency(paragraph);
            Console.WriteLine($"   Text: '{paragraph}'");
            foreach (var kvp in wordFreq.OrderByDescending(x => x.Value).Take(3))
            {
                Console.WriteLine($"   '{kvp.Key}': {kvp.Value} times");
            }
        }

        static string FindLongestWord(string sentence)
        {
            string[] words = sentence.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            return words.OrderByDescending(w => w.Length).First();
        }

        static System.Collections.Generic.Dictionary<char, int> CountCharacters(string str)
        {
            var dict = new System.Collections.Generic.Dictionary<char, int>();
            foreach (char c in str)
            {
                if (dict.ContainsKey(c))
                    dict[c]++;
                else
                    dict[c] = 1;
            }
            return dict;
        }

        static string RemoveCharacter(string str, char toRemove)
        {
            return string.Concat(str.Where(c => c != toRemove));
        }

        static char? FirstNonRepeatingChar(string str)
        {
            var charCount = CountCharacters(str);
            foreach (char c in str)
            {
                if (charCount[c] == 1)
                    return c;
            }
            return null;
        }

        static string CompressString(string str)
        {
            if (string.IsNullOrEmpty(str)) return str;
            
            StringBuilder compressed = new StringBuilder();
            int count = 1;
            
            for (int i = 1; i < str.Length; i++)
            {
                if (str[i] == str[i - 1])
                {
                    count++;
                }
                else
                {
                    compressed.Append(str[i - 1]);
                    compressed.Append(count);
                    count = 1;
                }
            }
            
            compressed.Append(str[str.Length - 1]);
            compressed.Append(count);
            
            return compressed.Length < str.Length ? compressed.ToString() : str;
        }

        static bool IsRotation(string s1, string s2)
        {
            if (s1.Length != s2.Length) return false;
            string combined = s1 + s1;
            return combined.Contains(s2);
        }

        static string RemoveConsecutiveDuplicates(string str)
        {
            if (string.IsNullOrEmpty(str)) return str;
            
            StringBuilder result = new StringBuilder();
            result.Append(str[0]);
            
            for (int i = 1; i < str.Length; i++)
            {
                if (str[i] != str[i - 1])
                {
                    result.Append(str[i]);
                }
            }
            
            return result.ToString();
        }

        static System.Collections.Generic.Dictionary<string, int> WordFrequency(string text)
        {
            string[] words = text.ToLower().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var freq = new System.Collections.Generic.Dictionary<string, int>();
            
            foreach (string word in words)
            {
                if (freq.ContainsKey(word))
                    freq[word]++;
                else
                    freq[word] = 1;
            }
            
            return freq;
        }
    }
}
