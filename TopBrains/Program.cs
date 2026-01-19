using System;
using TopBrains.Questions;

namespace TopBrains
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1. Mahirl Problem");
            Console.WriteLine("2. Swap Numbers");
            Console.Write("Choose question (1 or 2): ");
            
            string choice = Console.ReadLine();
            
            if (choice == "1")
            {
                Question1.Test();
            }
            else if (choice == "2")
            {
                Question2.Test();
            }
        }
    }
}