using System;

namespace TopBrains.Questions
{
    public class Question23
    {
        public static int SumIntegers(object[] values)
        {
            int sum = 0;
            
            foreach (object value in values)
            {
                if (value is int x)
                {
                    sum += x;
                }
            }
            
            return sum;
        }
        
        public static void Main(string[] args)
        {
            Console.Write("Enter number of values: ");
            int count = int.Parse(Console.ReadLine());
            
            object[] values = new object[count];
            
            for (int i = 0; i < count; i++)
            {
                Console.Write($"Value {i + 1} (int/string/bool/null): ");
                string input = Console.ReadLine();
                
                if (string.IsNullOrEmpty(input) || input.ToLower() == "null")
                {
                    values[i] = null;
                }
                else if (int.TryParse(input, out int intValue))
                {
                    values[i] = intValue;
                }
                else if (bool.TryParse(input, out bool boolValue))
                {
                    values[i] = boolValue;
                }
                else
                {
                    values[i] = input;
                }
            }
            
            Console.WriteLine("\nArray contents:");
            for (int i = 0; i < values.Length; i++)
            {
                Console.WriteLine($"[{i}]: {values[i]} ({values[i]?.GetType().Name ?? "null"})");
            }
            
            int sum = SumIntegers(values);
            Console.WriteLine($"\nSum of integers: {sum}");
        }
    }
}