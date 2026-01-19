using System;
using System.Collections.Generic;

namespace DataStructures.Collections
{
    public class StackDemo
    {
        public static void Run()
        {
            Console.WriteLine("\n=== Stack Demo (LIFO - Last In First Out) ===");
            
            // Creating a Stack
            Stack<string> books = new Stack<string>();
            
            // Pushing elements
            books.Push("Book 1");
            books.Push("Book 2");
            books.Push("Book 3");
            books.Push("Book 4");
            
            Console.WriteLine($"Stack Count: {books.Count}");
            
            // Peek (view top element without removing)
            Console.WriteLine($"Top book (Peek): {books.Peek()}");
            
            // Pop (remove and return top element)
            Console.WriteLine($"Popped: {books.Pop()}");
            Console.WriteLine($"Popped: {books.Pop()}");
            
            Console.WriteLine($"\nRemaining books in stack:");
            foreach (string book in books)
            {
                Console.WriteLine(book);
            }
            
            // Check if stack contains element
            Console.WriteLine($"\nContains 'Book 1'? {books.Contains("Book 1")}");
            
            // Clear stack
            Console.WriteLine($"Count before clear: {books.Count}");
            books.Clear();
            Console.WriteLine($"Count after clear: {books.Count}");
        }
    }
}
