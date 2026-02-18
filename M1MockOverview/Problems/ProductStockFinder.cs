using System;
using System.Reflection.Metadata;
using Itgenie;
namespace Itgenie
{
  public class Product
  {
    public static void addProduct(Entity obj, int quantity, string product)
    {
      if (obj.dict.ContainsKey(product))
      {
        Console.WriteLine("Product is already in List");
      }
      else
      {
        obj.dict.Add(product, quantity);
      }
    }
    public static void DisplayProducts(Entity obj)
    {
      Console.WriteLine("Product List:");
      foreach (var item in obj.dict)
      {
        Console.WriteLine($"Product: {item.Key}, Quantity: {item.Value}");
      }
    }
  }
}