using System;
using GenericsPractice.Problem1;
using GenericsPractice.Problem2;

namespace GenericsPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Generics Practice - Real-World Scenarios\n");
                Console.WriteLine("1. Problem 1: E-Commerce Inventory System");
                Console.WriteLine("2. Problem 2: Course Registration System");
                Console.WriteLine("0. Exit");
                Console.Write("\nSelect a problem: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Clear();
                        InventoryDemo.Run();
                        break;
                    case "2":
                        Console.Clear();
                        CourseRegistrationDemo.Run();
                        break;
                    case "0":
                        Console.WriteLine("\nThank you!");
                        return;
                    default:
                        Console.WriteLine("\nInvalid option.");
                        break;
                }

                if (choice != "0")
                {
                    Console.WriteLine("\n\nPress any key to return to menu...");
                    Console.ReadKey();
                }
            }
        }
    }
}
