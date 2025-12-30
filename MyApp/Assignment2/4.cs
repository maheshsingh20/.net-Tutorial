using System;
namespace Assignment2Part1Question4
{
  class ReverseAndPalindrome
  {
    public static void CheckReverseAndPalindrome()
    {
      Console.Write("Enter a number: ");
      int num = Convert.ToInt32(Console.ReadLine());
      
      int originalNum = num;
      int reversed = 0;
      
      while (num > 0)
      {
        reversed = reversed * 10 + num % 10;
        num /= 10;
      }
      
      Console.WriteLine($"Original number: {originalNum}");
      Console.WriteLine($"Reversed number: {reversed}");
      
      if (originalNum == reversed)
        Console.WriteLine($"{originalNum} is a palindrome");
      else
        Console.WriteLine($"{originalNum} is not a palindrome");
    }
  }
}