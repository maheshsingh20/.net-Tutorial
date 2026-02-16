using System;
namespace ATutorial.Topics
{
  public class Level1Main
  {
    public void Level1MainMethod()
    {
      Console.WriteLine("Enter the Name:");
      String name = Console.ReadLine();
      Console.WriteLine("Enter the Age:");
      int age = Convert.ToInt32(Console.ReadLine());
      Level1 l1 = new Level1(name, age);
      l1.Display();
    }     
    public void UpdateAge()
    {
      Console.WriteLine("Enter the new Age:");
      int newAge = Convert.ToInt32(Console.ReadLine());
      Level1 l2 = new Level1();
      l2.age = newAge;
      Console.WriteLine("Age updated successfully.");
      Console.WriteLine("Updated Age: " + l2.age);
      Console.WriteLine("Name: "+ l2.name);
    }
  }
}