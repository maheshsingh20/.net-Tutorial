using System;
namespace Assignment2Part1Question2
{
  class PrimeNumberChecker
  {
    public static void CheckPrime()
    {
      Console.Write("Enter a number: ");
      int num = Convert.ToInt32(Console.ReadLine());
      
      if (num <= 1)
      {
        Console.WriteLine($"{num} is not a prime number");
        return;
      }
      
      bool isPrime = true;
      
      for (int i = 2; i <= Math.Sqrt(num); i++)
      {
        if (num % i == 0)
        {
          isPrime = false;
          break;
        }
      }
      
      if (isPrime)
        Console.WriteLine($"{num} is a prime number");
      else
        Console.WriteLine($"{num} is not a prime number");
    }
  }
}