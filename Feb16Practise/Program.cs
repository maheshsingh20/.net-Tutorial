using System;
using Generics;
class Program
{
  public static void Main(string[] args)
  {
    GenericDS<int> intList = new GenericDS<int>(5);
    intList.Add(0, 10);
    intList.Add(1, 20);
    intList.Add(2, 30);
    intList.Add(3, 40);
    intList.Add(4, 50);
    
    for (int i = 0; i < 5; i++)
    {
      GenericDS<int>.DisplayItem(intList[i]);
    }
  }
}