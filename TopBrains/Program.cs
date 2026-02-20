using System;

namespace TopBrains
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("╔════════════════════════════════════════════╗");
            Console.WriteLine("║       TopBrains - Coding Challenges        ║");
            Console.WriteLine("╚════════════════════════════════════════════╝\n");
            
            Console.WriteLine("This project contains 28 coding challenge solutions.");
            Console.WriteLine("Each question is implemented in its own file in the Questions/ folder.\n");
            
            Console.WriteLine("To run a specific question:");
            Console.WriteLine("1. Open the question file (e.g., Question1.cs)");
            Console.WriteLine("2. Uncomment the Main method in that file");
            Console.WriteLine("3. Comment out this Main method");
            Console.WriteLine("4. Run the project\n");
            
            Console.WriteLine("Available Questions:");
            Console.WriteLine("  Questions 1-26:  Various coding challenges");
            Console.WriteLine("  Questions 56-57: Advanced problems\n");
            
            Console.WriteLine("See README.md for detailed information about each question.");
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
