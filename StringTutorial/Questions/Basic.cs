using System;

namespace StringTutorial.Questions
{
  public class Basic
  {
    public static void Check()
    {
      string name = "Mahesh Singh";
      Console.WriteLine(name);
      // Console.WriteLine(name.Length);
      // Console.WriteLine(name.ToUpper());
      // Console.WriteLine(name.ToLower());
      // Console.WriteLine(name.StartsWith('M'));
      // Console.WriteLine(name.EndsWith('k'));

      string str1= "My name is Ser Duncan The Tall";
      string str2 = " I am from Westeros";
      // Console.WriteLine(str1 + str2);
      // Console.WriteLine(string.Concat(str1, str2));
      Console.WriteLine(str1.Substring(11, 15));

      for (int i = str1.Length - 1; i >= 0; i--)
      {
        Console.Write(str1[i]);
      }
      
    }
  }
}