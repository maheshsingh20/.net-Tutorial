using System;
namespace Assignment1Part1Question3
{
  class Assignment1Part1Question3
  {
    public static void Main(string[] args)
    {
      Console.WriteLine("Enter year:");
      int year = Convert.ToInt32(Console.ReadLine());
      if ((year % 4 == 0 && year % 100 != 0) || (year % 400 == 0))
      {
        Console.WriteLine(year + " is a leap year.");
      }
      else
      {
        Console.WriteLine(year + " is not a leap year.");
      }
    }
  }
}