using System;
namespace Assignment2Part1Question5
{
  class GCDAndLCM
  {
    public static void FindGCDAndLCM()
    {
      Console.Write("Enter first number: ");
      int num1 = Convert.ToInt32(Console.ReadLine());
      Console.Write("Enter second number: ");
      int num2 = Convert.ToInt32(Console.ReadLine());
      
      int originalNum1 = num1;
      int originalNum2 = num2;
      
      // Find GCD using Euclidean algorithm
      while (num2 != 0)
      {
        int temp = num2;
        num2 = num1 % num2;
        num1 = temp;
      }
      
      int gcd = num1;
      int lcm = (originalNum1 * originalNum2) / gcd;
      
      Console.WriteLine($"GCD of {originalNum1} and {originalNum2} is: {gcd}");
      Console.WriteLine($"LCM of {originalNum1} and {originalNum2} is: {lcm}");
    }
  }
}