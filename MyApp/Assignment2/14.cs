using System;
namespace Assignment2Part1Question14
{
  class StrongNumberChecker
  {
    public static void CheckStrongNumber()
    {
      Console.Write("Enter a number: ");
      int num = Convert.ToInt32(Console.ReadLine());
      
      int originalNum = num;
      int sum = 0;
      
      while (num > 0)
      {
        int digit = num % 10;
        sum += CalculateFactorial(digit);
        num /= 10;
      }
      
      if (sum == originalNum)
        Console.WriteLine($"{originalNum} is a Strong number");
      else
        Console.WriteLine($"{originalNum} is not a Strong number");
    }
    
    private static int CalculateFactorial(int n)
    {
      if (n == 0 || n == 1)
        return 1;
      
      int factorial = 1;
      for (int i = 2; i <= n; i++)
      {
        factorial *= i;
      }
      return factorial;
    }
  }
}