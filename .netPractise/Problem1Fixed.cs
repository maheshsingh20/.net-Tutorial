using System;
using System.Linq;

namespace Problem1
{
    public class Problem1Fixed
    {
        public static string ReverseString(string str)
        {
            return new string(str.Reverse().ToArray());
        }
        
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter a string:");
            string input = Console.ReadLine() ?? "";
            
            int spaceCount = 0;
            foreach (char c in input)
            {
                if (c == ' ')
                {
                    spaceCount++;
                }
            }
            
            if (spaceCount % 2 == 0)
            {
                // Even number of spaces: reverse each word
                string result = "";
                string currentWord = "";
                
                for (int i = 0; i < input.Length; i++)
                {
                    if (input[i] == ' ')
                    {
                        if (currentWord.Length > 0)
                        {
                            result += ReverseString(currentWord) + " ";
                            currentWord = "";
                        }
                    }
                    else
                    {
                        currentWord += input[i];
                    }
                }
                
                // Handle the last word
                if (currentWord.Length > 0)
                {
                    result += ReverseString(currentWord);
                }
                
                Console.WriteLine(result.Trim());
            }
            else
            {
                // Odd number of spaces: reverse entire string
                Console.WriteLine(ReverseString(input));
            }
        }
    }
}