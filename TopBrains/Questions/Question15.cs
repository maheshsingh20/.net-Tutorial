using System;

namespace TopBrains.Questions
{
    public class Question15
    {
        public static double? ComputeAverage(double?[] values)
        {
            double sum = 0;
            int count = 0;
            
            foreach (double? value in values)
            {
                if (value.HasValue)
                {
                    sum += value.Value;
                    count++;
                }
            }
            
            if (count == 0)
                return null;
            
            double average = sum / count;
            return Math.Round(average, 2, MidpointRounding.AwayFromZero);
        }
        
        public static void Main(string[] args)
        {
            Console.Write("Enter number of values: ");
            int count = int.Parse(Console.ReadLine());
            
            double?[] values = new double?[count];
            
            for (int i = 0; i < count; i++)
            {
                Console.Write($"Value {i + 1} (press Enter for null): ");
                string input = Console.ReadLine();
                
                if (string.IsNullOrEmpty(input))
                {
                    values[i] = null;
                }
                else
                {
                    if (double.TryParse(input, out double val))
                    {
                        values[i] = val;
                    }
                    else
                    {
                        values[i] = null;
                    }
                }
            }
            
            double? result = ComputeAverage(values);
            
            if (result.HasValue)
            {
                Console.WriteLine($"Average: {result.Value}");
            }
            else
            {
                Console.WriteLine("Average: null (no non-null values)");
            }
        }
    }
}