using System;
namespace Assignment2Part1Question13
{
  class MenuSystem
  {
    public static void ShowMenu()
    {
      int choice;
      
      do
      {
        Console.WriteLine("\n=== MENU SYSTEM ===");
        Console.WriteLine("1. Display Hello World");
        Console.WriteLine("2. Calculate Square of a Number");
        Console.WriteLine("3. Check Even or Odd");
        Console.WriteLine("4. Display Current Date");
        Console.WriteLine("5. Exit");
        Console.Write("Enter your choice (1-5): ");
        
        choice = Convert.ToInt32(Console.ReadLine());
        
        switch (choice)
        {
          case 1:
            Console.WriteLine("Hello, World!");
            break;
          case 2:
            Console.Write("Enter a number: ");
            int num = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Square of {num} is: {num * num}");
            break;
          case 3:
            Console.Write("Enter a number: ");
            int number = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"{number} is {(number % 2 == 0 ? "Even" : "Odd")}");
            break;
          case 4:
            Console.WriteLine($"Current Date: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
            break;
          case 5:
            Console.WriteLine("Goodbye!");
            break;
          default:
            Console.WriteLine("Invalid choice! Please try again.");
            break;
        }
        
      } while (choice != 5);
    }
  }
}