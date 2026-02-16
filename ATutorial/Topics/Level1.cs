using System;
namespace ATutorial.Topics
{
  public class Level1
  {
    public string name { get; set; } = "";
    public int age { get; set; }
    public Level1()
    {
    }
    public Level1(string name, int age)
    {
      this.name = name;
      this.age = age;
    }
    public void Display()
    {
      Console.WriteLine("Name: " + name);
      Console.WriteLine("Age: " + age);
    }
  }
}
