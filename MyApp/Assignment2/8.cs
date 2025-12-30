using System;
namespace Assignment2Part1Question8
{
  class DiamondPattern
  {
    public static void PrintDiamond()
    {
      Console.Write("Enter number of rows for diamond: ");
      int n = Convert.ToInt32(Console.ReadLine());
      
      // Upper half of diamond
      for (int i = 1; i <= n; i++)
      {
        // Print spaces
        for (int j = 1; j <= n - i; j++)
        {
          Console.Write(" ");
        }
        
        // Print stars
        for (int j = 1; j <= 2 * i - 1; j++)
        {
          Console.Write("*");
        }
        Console.WriteLine();
      }
      
      // Lower half of diamond
      for (int i = n - 1; i >= 1; i--)
      {
        // Print spaces
        for (int j = 1; j <= n - i; j++)
        {
          Console.Write(" ");
        }
        
        // Print stars
        for (int j = 1; j <= 2 * i - 1; j++)
        {
          Console.Write("*");
        }
        Console.WriteLine();
      }
    }
  }
}