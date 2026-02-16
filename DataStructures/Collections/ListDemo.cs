using System;
using System.Collections.Generic;
namespace DataStructures.Collections
{
    public class ListDemo
    {
        public static void Run()
        {
            Console.WriteLine("\n=== List Demo ===");
            List<int> numbers = new List<int>();
            numbers.Add(10);
            numbers.Add(20);
            numbers.Add(30);
            numbers.AddRange(new int[] { 40, 50 });
            
            Console.WriteLine("List elements:");
            foreach (int num in numbers)
            {
                Console.Write(num + " ");
            }
            
            Console.WriteLine($"\nElement at index 2: {numbers[2]}");
            
            numbers.Insert(1, 15);
            Console.WriteLine($"After inserting 15 at index 1: {string.Join(", ", numbers)}");
            
            numbers.Remove(30);
            Console.WriteLine($"After removing 30: {string.Join(", ", numbers)}");
            Console.WriteLine($"Contains 20? {numbers.Contains(20)}");
            Console.WriteLine($"Index of 40: {numbers.IndexOf(40)}");
            numbers.Sort();
            Console.WriteLine($"After sorting: {string.Join(", ", numbers)}");
            Console.WriteLine($"Count: {numbers.Count}");
        }
    }
}