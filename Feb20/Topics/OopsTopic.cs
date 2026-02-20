using System;

namespace Feb20
{
  public class Oops
  {
    public int Id;
    public Oops()
    {
      Console.WriteLine("Base class constructor");
    }
    public Oops(int id)
    {
      Id = id;
      Console.WriteLine("Base class parameterized constructor");
    }
  }
  public class OopsA : Oops
  {
    public OopsA() : base()
    {
      Console.WriteLine("Derived class constructor");
    }
    public OopsA(int id) : base(id)
    {
      Console.WriteLine("Derived class parameterized constructor");
    }
    public void print()
    {
      Console.WriteLine("Id: " + Id);
    }
  }
}