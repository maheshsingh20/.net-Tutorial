using System;
using System.Collections.Generic;
namespace Itgenie
{
  public class Entity
  {
    public Dictionary<string, int> dict { get; private set; }
    public Entity()
    {
      dict = new Dictionary<string, int>();
    }
  }
}