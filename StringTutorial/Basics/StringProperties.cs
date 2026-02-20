using System;

namespace StringTutorial.Basics
{
    public class StringProperties
    {
        public static void Run()
        {
            Console.WriteLine("=== String Properties ===\n");

            string text = "Hello, World!";

            // Length property
            Console.WriteLine($"String: '{text}'");
            Console.WriteLine($"Length: {text.Length}");
            Console.WriteLine($"Is Empty: {string.IsNullOrEmpty(text)}");
            Console.WriteLine($"Is Null or WhiteSpace: {string.IsNullOrWhiteSpace(text)}");

            // Indexer (accessing individual characters)
            Console.WriteLine($"\nFirst Character: {text[0]}");
            Console.WriteLine($"Last Character: {text[text.Length - 1]}");
            Console.WriteLine($"Character at index 7: {text[7]}");

            // Iterating through characters
            Console.WriteLine("\nAll Characters:");
            for (int i = 0; i < text.Length; i++)
            {
                Console.Write($"{text[i]} ");
            }
            Console.WriteLine();

            // Using foreach
            Console.WriteLine("\nUsing foreach:");
            foreach (char c in text)
            {
                Console.Write($"{c} ");
            }
            Console.WriteLine();

            // Empty and null checks
            Console.WriteLine("\n=== Empty and Null Checks ===");
            string empty = "";
            string whitespace = "   ";
            string nullStr = null;

            Console.WriteLine($"Empty string - IsNullOrEmpty: {string.IsNullOrEmpty(empty)}");
            Console.WriteLine($"Whitespace - IsNullOrEmpty: {string.IsNullOrEmpty(whitespace)}");
            Console.WriteLine($"Whitespace - IsNullOrWhiteSpace: {string.IsNullOrWhiteSpace(whitespace)}");
            Console.WriteLine($"Null string - IsNullOrEmpty: {string.IsNullOrEmpty(nullStr)}");
        }
    }
}
