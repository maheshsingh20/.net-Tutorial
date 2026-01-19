using System;

namespace TopBrains.Questions
{
    public class Question7
    {
        public static string GetHeightCategory(int heightCm)
        {
            if (heightCm < 150)
                return "Short";
            else if (heightCm < 180)
                return "Average";
            else
                return "Tall";
        }
        
        public static void Main(string[] args)
        {
            Console.Write("Enter height in cm: ");
            int height = int.Parse(Console.ReadLine());
            
            string category = GetHeightCategory(height);
            Console.WriteLine($"Category: {category}");
        }
    }
}