using System;
using StringTutorial.Basics;
using StringTutorial.Methods;
using StringTutorial.Advanced;
using StringTutorial.Immutability;
using StringTutorial.RegularExpressions;
using StringTutorial.Performance;
using StringTutorial.EncodingDemo;
using StringTutorial.Exercises;

namespace StringTutorial
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("STRING TUTORIAL - COMPREHENSIVE GUIDE");
                Console.WriteLine("=====================================\n");
                
                Console.WriteLine("BASICS:");
                Console.WriteLine("  1. String Creation Methods");
                Console.WriteLine("  2. String Properties and Indexing");
                
                Console.WriteLine("\nMETHODS:");
                Console.WriteLine("  3. String Comparison");
                Console.WriteLine("  4. String Manipulation");
                Console.WriteLine("  5. String Searching");
                
                Console.WriteLine("\nADVANCED:");
                Console.WriteLine("  6. StringBuilder");
                Console.WriteLine("  7. String Formatting");
                Console.WriteLine("  8. String Split and Join");
                
                Console.WriteLine("\nCONCEPTS:");
                Console.WriteLine("  9. String Immutability");
                Console.WriteLine(" 10. String Encoding");
                Console.WriteLine(" 11. Performance Comparison");
                
                Console.WriteLine("\nREGULAR EXPRESSIONS:");
                Console.WriteLine(" 12. Regex Basics");
                Console.WriteLine(" 13. Regex Validation");
                
                Console.WriteLine("\nEXERCISES:");
                Console.WriteLine(" 14. Common String Problems");
                Console.WriteLine(" 15. Practice Problems");
                
                Console.WriteLine("\n 0. Exit");
                
                Console.Write("\nEnter your choice: ");
                string choice = Console.ReadLine();
                
                Console.Clear();
                
                try
                {
                    switch (choice)
                    {
                        case "1":
                            StringCreation.Run();
                            break;
                        case "2":
                            StringProperties.Run();
                            break;
                        case "3":
                            StringComparisonDemo.Run();
                            break;
                        case "4":
                            StringManipulation.Run();
                            break;
                        case "5":
                            StringSearching.Run();
                            break;
                        case "6":
                            StringBuilderDemo.Run();
                            break;
                        case "7":
                            StringFormatting.Run();
                            break;
                        case "8":
                            StringSplitJoin.Run();
                            break;
                        case "9":
                            ImmutabilityDemo.Run();
                            break;
                        case "10":
                            EncodingOperations.Run();
                            break;
                        case "11":
                            PerformanceComparison.Run();
                            break;
                        case "12":
                            RegexBasics.Run();
                            break;
                        case "13":
                            RegexValidation.Run();
                            break;
                        case "14":
                            CommonProblems.Run();
                            break;
                        case "15":
                            PracticeProblems.Run();
                            break;
                        case "0":
                            Console.WriteLine("Thank you for using String Tutorial!");
                            return;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\nError: {ex.Message}");
                }
                
                Console.WriteLine("\n\nPress any key to continue...");
                Console.ReadKey();
            }
        }
    }
}
