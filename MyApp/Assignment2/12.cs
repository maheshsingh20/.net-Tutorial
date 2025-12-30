using System;
namespace Assignment2Part1Question12
{
  class ContinueUsage
  {
    public static void PrintNumbersSkipMultiplesOf3()
    {
      Console.WriteLine("Numbers from 1 to 50 (skipping multiples of 3):");
      
      for (int i = 1; i <= 50; i++)
      {
        if (i % 3 == 0)
        {
          continue; // Skip multiples of 3
        }
        Console.Write(i + " ");
      }
      Console.WriteLine();
    }
  }
}