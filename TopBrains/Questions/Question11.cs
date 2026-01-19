using System;
using System.Text;
using System.Globalization;

namespace TopBrains.Questions
{
    public class Question11
    {
        public static string CleanupInventoryName(string productName)
        {
            if (string.IsNullOrEmpty(productName))
                return "";
            
            // Step 1: Remove consecutive duplicate characters
            StringBuilder sb = new StringBuilder();
            sb.Append(productName[0]);
            
            for (int i = 1; i < productName.Length; i++)
            {
                if (productName[i] != productName[i - 1])
                {
                    sb.Append(productName[i]);
                }
            }
            
            // Step 2: Trim extra spaces and convert to title case
            string result = sb.ToString().Trim();
            TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
            result = textInfo.ToTitleCase(result.ToLower());
            
            return result;
        }
        
        public static void Main(string[] args)
        {
            Console.Write("Enter product name: ");
            string input = Console.ReadLine();
            
            string cleaned = CleanupInventoryName(input);
            Console.WriteLine($"Cleaned name: {cleaned}");
        }
    }
}