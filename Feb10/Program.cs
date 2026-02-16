using System;
using Feb10.Questions.Problem1;
using Feb10.Questions.LINQ;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Feb10 - C# Demonstrations ===\n");
        Console.WriteLine("Choose an option:");
        Console.WriteLine("1. Problem 1 - Entity Demo");
        Console.WriteLine("2. Lambda Expression Demo");
        Console.WriteLine("3. LINQ Comprehensive Demo");
        Console.WriteLine("4. LINQ Practice Exercises");
        Console.WriteLine("5. Exit");
        
        Console.Write("\nEnter your choice: ");
        string choice = Console.ReadLine() ?? "";

        switch (choice)
        {
            case "1":
                ShowDetail.Main(new string[] { });
                break;
            case "2":
                Lambda.LambdaExp.LbExpression();
                break;
            case "3":
                LinqDemo.Main(new string[] { });
                break;
            case "4":
                LinqExercises.RunExercises();
                break;
            case "5":
                Console.WriteLine("Goodbye!");
                break;
            default:
                Console.WriteLine("Invalid choice!");
                break;
        }
    }
}