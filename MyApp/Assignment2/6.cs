using System;
namespace Assignment2Part1Question6
{
  class PascalsTriangle
  {
    public static void PrintPascalsTriangle()
    {
      Console.Write("Enter number of rows: ");
      int rows = Convert.ToInt32(Console.ReadLine());
      
      for (int i = 0; i < rows; i++)
      {
        // Print spaces for alignment
        for (int j = 0; j < rows - i - 1; j++)
        {
          Console.Write(" ");
        }
        
        // Calculate and print Pascal's triangle values
        int value = 1;
        for (int j = 0; j <= i; j++)
        {
          Console.Write(value + " ");
          value = value * (i - j) / (j + 1);
        }
        Console.WriteLine();
      }
    }
  }
}