using System;

namespace Generics
{
  public class GenericDS<T>
  {
    private T[] items;
    public GenericDS(int size)
    {
      items = new T[size];
    }
    public void Add(int index, T item)
    {
      if (index >= items.Length || index < 0)
      {
        throw new IndexOutOfRangeException("Index out of range");
        
      }
      items[index] = item;
    }
     
    public T this[int index]
    {
      get
      {
        if (index >= items.Length || index < 0)
        {
          throw new IndexOutOfRangeException("Index out of range");
        }
        return items[index];
      }
      set
      {
        if (index >= items.Length || index < 0)
        {
          throw new IndexOutOfRangeException("Index out of range");
        }
        items[index] = value;
      }
    }
    
    public static void DisplayItem(T item)
    {
      Console.WriteLine(item);
    }
  }
}