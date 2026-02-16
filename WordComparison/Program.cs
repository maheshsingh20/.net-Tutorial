using System;
using System.Collections.Generic;

namespace WordComparison
{
    class Program
    {
        static int CountDeletions(string word1, string word2)
        {
            Dictionary<char, int> word2Chars = new Dictionary<char, int>();
            
            foreach (char c in word2)
            {
                if (word2Chars.ContainsKey(c))
                    word2Chars[c]++;
                else
                    word2Chars[c] = 1;
            }
            
            int deletions = 0;
            
            foreach (char c in word1)
            {
                if (word2Chars.ContainsKey(c) && word2Chars[c] > 0)
                {
                    word2Chars[c]--;
                }
                else
                {
                    deletions++;
                }
            }
            
            foreach (var count in word2Chars.Values)
            {
                deletions += count;
            }
            
            return deletions;
        }
        
        static void Main(string[] args)
        {
            Console.Write("Enter word1: ");
            string word1 = Console.ReadLine();
            
            Console.Write("Enter word2: ");
            string word2 = Console.ReadLine();
            
            int result = CountDeletions(word1, word2);
            
            Console.WriteLine(result);
        }
    }
}
