using System;

namespace TopBrains.Questions
{
    public class Question16
    {
        public static int SumValidIntegers(string[] tokens)
        {
            int sum = 0;
            
            foreach (string token in tokens)
            {
                if (int.TryParse(token, out int value))
                {
                    sum += value;
                }
            }
            
            return sum;
        }
        
        public static void Main(string[] args)
        {
            Console.Write("Enter number of tokens: ");
            int count = int.Parse(Console.ReadLine());
            
            string[] tokens = new string[count];
            for (int i = 0; i < count; i++)
            {
                Console.Write($"Token {i + 1}: ");
                tokens[i] = Console.ReadLine();
            }
            
            int result = SumValidIntegers(tokens);
            Console.WriteLine($"Sum of valid integers: {result}");
        }
    }
}