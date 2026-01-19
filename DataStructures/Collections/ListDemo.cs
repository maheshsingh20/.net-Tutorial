using System;
using System.Collections.Generic;

namespace DataStructures.Collections
{
    public class ListDemo
    {
        public static void Run()
        {
            Console.WriteLine("\n=== List Demo ===");
            
            // Creating a List
            List<int> numbers = new List<int>();
            
            // Adding elements
            numbers.Add(10);
            numbers.Add(20);
            numbers.Add(30);
            numbers.AddRange(new int[] { 40, 50 });
            
            Console.WriteLine("List elements:");
            foreach (int num in numbers)
            {
                Console.Write(num + " ");
            }
            
            // Accessing elements
            Console.WriteLine($"\nElement at index 2: {numbers[2]}");
            
            // Inserting element
            numbers.Insert(1, 15);
            Console.WriteLine($"After inserting 15 at index 1: {string.Join(", ", numbers)}");
            
            // Removing elements
            numbers.Remove(30);
            Console.WriteLine($"After removing 30: {string.Join(", ", numbers)}");
            
            // Searching
            Console.WriteLine($"Contains 20? {numbers.Contains(20)}");
            Console.WriteLine($"Index of 40: {numbers.IndexOf(40)}");
            
            // Sorting
            numbers.Sort();
            Console.WriteLine($"After sorting: {string.Join(", ", numbers)}");
            
            Console.WriteLine($"Count: {numbers.Count}");
        }
    }
}
