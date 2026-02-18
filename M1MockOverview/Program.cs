// using System;
// using System.Collections.Generic;
// using System.Net.Http.Headers;
// using Itgenie;

// public class Program
// {
//   public static void Main(string[] args)
//   {
//     Console.WriteLine("Welcome to the Product Stock Finder!");
//     Entity et = new Entity();
//     for (int i = 0; i < 3; i++)
//     {
//       Console.WriteLine("Enter Product name: ");
//       string productName = Console.ReadLine();
//       Console.WriteLine("Enter the Product Quantity: ");
//       int proDuctNumber = Convert.ToInt32(Console.ReadLine());
//       Product.addProduct(et, proDuctNumber, productName);
//     }
//     Product.DisplayProducts(et);
//     UpdateExistingKey.updateProduct(et, 16, "LP");
//     Product.DisplayProducts(et);
//   }
// }


using System;
using System.Collections.Generic;
using Attendance;
public class Program
{
  public static void Main(string[] args)
  {
    // List<int> lt = new List<int>();
    // lt.Add(1);
    // lt.Add(3);
    // lt.Add(2);
    // lt.Add(3);
    // lt.Add(1);
    // lt.Add(1);
    // Dictionary<string, int> curr = AttendanceCounter.GetAttendanceCount(lt);
    // foreach(var i in curr)
    // {

    //   Console.WriteLine("Key is: " + i.Key);
    //   Console.WriteLine("Value is: " + i.Value);

    // }
    List<string> lt = new List<string>();
    lt.Add("John");
    lt.Add("Jane");
    lt.Add("John");
    lt.Add("John");
    lt.Add("Jane");
    lt.Add("John");
    AttendanceCounter ac = new AttendanceCounter();
    ac.getFailedLoginAttempt(lt);
  }
}