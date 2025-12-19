using System;
namespace MyTutorial1
{
  class MyTutorial1
  {
    public static void Main(string[] args)
    {
      Console.WriteLine("Size of Array: ");
      int size = Convert.ToInt32(Console.ReadLine());
      int[] arr = new int[size];
      Console.WriteLine("Enter Array Elements: ");
      for (int i = 0; i < size; i++)
      {
        arr[i] = Convert.ToInt32(Console.ReadLine());
      }
      Console.WriteLine("Array Elements are: ");
      for (int i = 0; i < size; i++)
      {
        Console.Write(arr[i]);
        Console.Write(" ");
      }
    }
  }
}