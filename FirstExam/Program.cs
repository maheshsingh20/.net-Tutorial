using System;

namespace FirstExam
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("╔════════════════════════════════════════════╗");
                Console.WriteLine("║         First Exam - Practice Problems      ║");
                Console.WriteLine("╚════════════════════════════════════════════╝\n");

                Console.WriteLine("Select a problem to run:\n");
                Console.WriteLine("1. Problem 1: QuickMart Traders (Sales Transaction System)");
                Console.WriteLine("2. Problem 2: MediSure Clinic (Patient Billing System)");
                Console.WriteLine("0. Exit\n");

                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Clear();
                        RunProblem1();
                        break;
                    case "2":
                        Console.Clear();
                        RunProblem2();
                        break;
                    case "0":
                        Console.WriteLine("\nThank you!");
                        return;
                    default:
                        Console.WriteLine("\nInvalid choice. Press any key to continue...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void RunProblem1()
        {
            // Run QuickMart Traders
            QuickMartTraders.Program.Main(null);
        }

        static void RunProblem2()
        {
            // Run MediSure Clinic
            MediSureClinic.Program.Main(null);
        }
    }
}
