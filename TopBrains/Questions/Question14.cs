using System;
using System.IO;

namespace TopBrains.Questions
{
    public class Question14
    {
        public static void FilterErrorLogs(string inputFile, string outputFile)
        {
            try
            {
                string[] lines = File.ReadAllLines(inputFile);
                
                using (StreamWriter writer = new StreamWriter(outputFile))
                {
                    foreach (string line in lines)
                    {
                        if (line.Contains("ERROR"))
                        {
                            writer.WriteLine(line);
                        }
                    }
                }
                
                Console.WriteLine($"ERROR logs extracted to {outputFile}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
        
        public static void CreateSampleLogFile()
        {
            string[] sampleLogs = {
                "2024-01-01 10:00:00 INFO Application started",
                "2024-01-01 10:01:00 ERROR Database connection failed",
                "2024-01-01 10:02:00 WARN Memory usage high",
                "2024-01-01 10:03:00 INFO User logged in",
                "2024-01-01 10:04:00 ERROR File not found",
                "2024-01-01 10:05:00 INFO Processing complete"
            };
            
            File.WriteAllLines("log.txt", sampleLogs);
            Console.WriteLine("Sample log.txt created");
        }
        
        public static void Main(string[] args)
        {
            CreateSampleLogFile();
            
            Console.Write("Enter input file name (default: log.txt): ");
            string inputFile = Console.ReadLine();
            if (string.IsNullOrEmpty(inputFile))
                inputFile = "log.txt";
            
            Console.Write("Enter output file name (default: error.txt): ");
            string outputFile = Console.ReadLine();
            if (string.IsNullOrEmpty(outputFile))
                outputFile = "error.txt";
            
            FilterErrorLogs(inputFile, outputFile);
            
            if (File.Exists(outputFile))
            {
                Console.WriteLine("\nFiltered ERROR logs:");
                string[] errorLogs = File.ReadAllLines(outputFile);
                foreach (string log in errorLogs)
                {
                    Console.WriteLine(log);
                }
            }
        }
    }
}