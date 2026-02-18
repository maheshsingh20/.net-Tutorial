using System;
using System.Collections.Generic;
using System.Reflection.Metadata;

namespace Itgenie
{
  public class UpdateExistingKey
  {
    public static void updateProduct(Entity obj, int quantity, string product)
    {
      if (!obj.dict.ContainsKey(product))
      {
        Console.WriteLine("Product is not in List");
      }
      else
      {
        obj.dict[product] = quantity;
      }
    }
  }
}