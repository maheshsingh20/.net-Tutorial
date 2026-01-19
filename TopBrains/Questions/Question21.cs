using System;

namespace TopBrains.Questions
{
    public class Question21
    {
        public static string ConvertSecondsToTime(int totalSeconds)
        {
            int minutes = totalSeconds / 60;
            int seconds = totalSeconds % 60;
            
            return $"{minutes}:{seconds:D2}";
        }
        
        public static void Main(string[] args)
        {
            Console.Write("Enter total seconds: ");
            int totalSeconds = int.Parse(Console.ReadLine());
            
            string formatted = ConvertSecondsToTime(totalSeconds);
            Console.WriteLine($"{totalSeconds} seconds = {formatted}");
        }
    }
}