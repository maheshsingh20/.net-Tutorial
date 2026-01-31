using System;
using System.IO.Pipelines;
using System.Linq;

namespace Problem1
{
  public class Problem1
  {
    public static void Main(string[] args)
    {
      Console.WriteLine("Enter a string:");
      string input = Console.ReadLine();

      int spaces = 0;
      foreach (char c in input)
      {
        if (c == ' ')
          spaces++;
      }

      int wordCount = spaces + 1;

      if (wordCount % 2 == 0)
      {
        string result = "";
        for(int i = 0; i < input.Length; i++)
        {
          if (input[i] == ' ')
          {
            result = curr + " " + result;
            curr = "";
          }
          else
          {
            curr += input[i];
          }
        }
      }
      else
      {
        // ODD → reverse each word
        string result = "";
        string curr = "";
        for (int i = 0; i < input.Length; i++)
        {
          if (input[i] == ' ')
          {
            result += Reverse(curr) + " ";
            curr = "";
          }
          else
          {
            curr += input[i];
          }
        }

        result += Reverse(curr);
        Console.WriteLine(result);
      }
    }

    static string Reverse(string s)
    {
      return new string(s.Reverse().ToArray());
    }
  }
}
