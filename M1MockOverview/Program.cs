using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using Itgenie;

public class Program
{
  public static void Main(string[] args)
  {
    Console.WriteLine("Welcome to the Product Stock Finder!");
    Entity et = new Entity();
    for (int i = 0; i < 3; i++)
    {
      Console.WriteLine("Enter Product name: ");
      string productName = Console.ReadLine();
      Console.WriteLine("Enter the Product Quantity: ");
      int proDuctNumber = Convert.ToInt32(Console.ReadLine());
      Product.addProduct(et, proDuctNumber, productName);
    }
    Product.DisplayProducts(et);
    UpdateExistingKey.updateProduct(et, 16, "LP");
    Product.DisplayProducts(et);
  }
}