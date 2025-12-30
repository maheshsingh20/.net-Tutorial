using System;
namespace Assignment2Part1Question3
{
  class ArmstrongNumberChecker
  {
    public static void CheckArmstrong()
    {
      Console.Write("Enter a number: ");
      int num = Convert.ToInt32(Console.ReadLine());
      
      int originalNum = num;
      int digitCount = num.ToString().Length;
      int sum = 0;
      
      while (num > 0)
      {
        int digit = num % 10;
        sum += (int)Math.Pow(digit, digitCount);
        num /= 10;
      }
      
      if (sum == originalNum)
        Console.WriteLine($"{originalNum} is an Armstrong number");
      else
        Console.WriteLine($"{originalNum} is not an Armstrong number");
    }
  }
}