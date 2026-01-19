using System;
using System.Text;

namespace TopBrains.Questions
{
    public class Question1
    {
        public static string Solve(string word1, string word2)
        {
            string step1 = RemoveCommonConsonants(word1, word2);
            string step2 = RemoveConsecutiveDuplicates(step1);
            return step2;
        }
        
        private static string RemoveCommonConsonants(string word1, string word2)
        {
            StringBuilder result = new StringBuilder();
            string vowels = "aeiouAEIOU";
            string word2Lower = word2.ToLower();
            
            foreach (char c in word1)
            {
                if (vowels.Contains(c))
                {
                    result.Append(c);
                }
                else
                {
                    if (!word2Lower.Contains(char.ToLower(c)))
                    {
                        result.Append(c);
                    }
                }
            }
            
            return result.ToString();
        }
        
        private static string RemoveConsecutiveDuplicates(string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;
                
            StringBuilder result = new StringBuilder();
            result.Append(input[0]);
            
            for (int i = 1; i < input.Length; i++)
            {
                if (input[i] != input[i - 1])
                {
                    result.Append(input[i]);
                }
            }
            
            return result.ToString();
        }
        
        public static void Main(string[] args)
        {
            Console.Write("Enter first word: ");
            string word1 = Console.ReadLine();
            Console.Write("Enter second word: ");
            string word2 = Console.ReadLine();
            
            if (!string.IsNullOrEmpty(word1) && !string.IsNullOrEmpty(word2))
            {
                string result = Solve(word1, word2);
                Console.WriteLine($"Result: {result}");
            }
        }
    }
}