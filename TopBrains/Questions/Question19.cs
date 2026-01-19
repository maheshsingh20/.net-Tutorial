using System;

namespace TopBrains.Questions
{
    public class Question19
    {
        public static double ConvertFeetToCentimeters(int feet)
        {
            const double FEET_TO_CM = 30.48;
            double centimeters = feet * FEET_TO_CM;
            return Math.Round(centimeters, 2, MidpointRounding.AwayFromZero);
        }
        
        public static void Main(string[] args)
        {
            Console.Write("Enter feet: ");
            int feet = int.Parse(Console.ReadLine());
            
            double centimeters = ConvertFeetToCentimeters(feet);
            Console.WriteLine($"{feet} feet = {centimeters} cm");
        }
    }
}