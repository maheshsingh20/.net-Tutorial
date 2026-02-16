using System;
using System.Data;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
namespace Feb10.Questions.Problem1
{
  class Helper
  {
    public static void printDetail(int id, int age, string name, string city)
    {
      Console.WriteLine($"id: {id}, name: {name}, age: {age}, city: {city}");
    }
    public static int UpdatedAge(int age)
    {
      return age + 5;
    }
  }
  class ShowDetail
  {
    public static void Main(string[] args)
    {
      Entity entity = new Entity();
      entity.id = 1;
      entity.name = "John";
      entity.age = 30;
      entity.city = "New York";
      Helper.printDetail(entity.id, entity.age, entity.name, entity.city);
      int updatedAge = Helper.UpdatedAge(entity.age);
      Console.WriteLine("After updating age: {0}", updatedAge);
    }
  }
}