using System;
namespace Assignment2Part1Question15
{
  class SearchWithGoto
  {
    public static void SearchWithGotoExample()
    {
      Console.Write("Enter target number to search: ");
      int target = Convert.ToInt32(Console.ReadLine());
      
      int[,,] array3D = new int[3, 3, 3];
      Random random = new Random();
      
      // Fill array with random numbers
      Console.WriteLine("3D Array contents:");
      for (int i = 0; i < 3; i++)
      {
        for (int j = 0; j < 3; j++)
        {
          for (int k = 0; k < 3; k++)
          {
            array3D[i, j, k] = random.Next(1, 20);
            Console.Write($"{array3D[i, j, k]:D2} ");
          }
          Console.WriteLine();
        }
        Console.WriteLine("---");
      }
      
      // Search with goto
      for (int i = 0; i < 3; i++)
      {
        for (int j = 0; j < 3; j++)
        {
          for (int k = 0; k < 3; k++)
          {
            if (array3D[i, j, k] == target)
            {
              Console.WriteLine($"Found {target} at position [{i}][{j}][{k}]");
              goto Found;
            }
          }
        }
      }
      
      Console.WriteLine($"Number {target} not found in the array");
      return;
      
      Found:
      Console.WriteLine("Search completed successfully using goto!");
    }
  }
}