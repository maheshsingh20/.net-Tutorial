using System;
namespace Assignment2Part1Question7
{
  class BinaryToDecimal
  {
    public static void ConvertBinaryToDecimal()
    {
      Console.Write("Enter binary number: ");
      string binary = Console.ReadLine()!;
      
      int decimalValue = 0;
      int baseValue = 1; // 2^0
      
      // Process from right to left
      for (int i = binary.Length - 1; i >= 0; i--)
      {
        if (binary[i] == '1')
        {
          decimalValue += baseValue;
        }
        else if (binary[i] != '0')
        {
          Console.WriteLine("Invalid binary number!");
          return;
        }
        baseValue *= 2;
      }
      
      Console.WriteLine($"Binary {binary} = Decimal {decimalValue}");
    }
  }
}