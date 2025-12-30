using System;
namespace Assignment2Part1Question11
{
  class SumOfDigits
  {
    public static void CalculateDigitalRoot()
    {
      Console.Write("Enter a number: ");
      int num = Convert.ToInt32(Console.ReadLine());
      
      Console.WriteLine($"Original number: {num}");
      
      while (num >= 10)
      {
        int sum = 0;
        while (num > 0)
        {
          sum += num % 10;
          num /= 10;
        }
        num = sum;
        Console.WriteLine($"Sum of digits: {num}");
      }
      
      Console.WriteLine($"Digital Root: {num}");
    }
  }
}