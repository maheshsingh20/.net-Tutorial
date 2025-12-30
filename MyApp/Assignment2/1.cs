using System;
namespace Assignment2Part1Question1
{
  class FibonacciSeries
  {
    public static void DisplayFibonacci()
    {
      Console.Write("Enter number of terms: ");
      int n = Convert.ToInt32(Console.ReadLine());
      
      int first = 0, second = 1;
      
      if (n >= 1)
      {
        Console.Write($"Fibonacci Series: {first}");
      }
      if (n >= 2)
      {
        Console.Write($", {second}");
      }
      
      for (int i = 3; i <= n; i++)
      {
        int next = first + second;
        Console.Write($", {next}");
        first = second;
        second = next;
      }
      Console.WriteLine();
    }
  }
}