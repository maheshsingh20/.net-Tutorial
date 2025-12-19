using System;
namespace Assignment1Part1Question2
{
  class Assignment1Part1Question2
  {
    public static void Main(string[] args)
    {
      int a = 10;
      int b = 20;
      int c = 30;
      if(a >= b && a >= c)
      {
        Console.WriteLine("Largest number is: " + a);
      }
      else if(b >= a && b >= c)
      {
        Console.WriteLine("Largest number is: " + b);
      }
      else
      {
        Console.WriteLine("Largest number is: " + c);
      }
    }
  }
}