using System;
using System.Numerics;
namespace Assignment2Part1Question9
{
  class FactorialLargeNumbers
  {
    public static void CalculateFactorial()
    {
      Console.Write("Enter a number: ");
      int n = Convert.ToInt32(Console.ReadLine());
      
      if (n < 0)
      {
        Console.WriteLine("Factorial is not defined for negative numbers");
        return;
      }
      
      BigInteger factorial = 1;
      
      for (int i = 1; i <= n; i++)
      {
        factorial *= i;
      }
      
      Console.WriteLine($"Factorial of {n} is: {factorial}");
    }
  }
}