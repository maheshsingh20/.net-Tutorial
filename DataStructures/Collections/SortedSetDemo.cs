using System;
using System.Collections.Generic;

namespace DataStructures.Collections
{
    public class SortedSetDemo
    {
        public static void Run()
        {
            Console.WriteLine("\n=== SortedSet Demo (Unique & Sorted) ===");
            
            // Creating a SortedSet
            SortedSet<int> numbers = new SortedSet<int>();
            
            // Adding elements (automatically sorted and unique)
            numbers.Add(50);
            numbers.Add(20);
            numbers.Add(80);
            numbers.Add(10);
            numbers.Add(20); // Duplicate - won't be added
            numbers.Add(30);
            
            Console.WriteLine("SortedSet elements (sorted):");
            foreach (int num in numbers)
            {
                Console.Write(num + " ");
            }
            
            Console.WriteLine($"\nCount: {numbers.Count}");
            
            // Min and Max
            Console.WriteLine($"Min: {numbers.Min}");
            Console.WriteLine($"Max: {numbers.Max}");
            
            // GetViewBetween (subset within range)
            var subset = numbers.GetViewBetween(20, 60);
            Console.WriteLine($"Elements between 20 and 60: {string.Join(", ", subset)}");
            
            // Set operations
            SortedSet<int> set1 = new SortedSet<int> { 1, 3, 5, 7, 9 };
            SortedSet<int> set2 = new SortedSet<int> { 5, 6, 7, 8, 9 };
            
            // Union
            SortedSet<int> union = new SortedSet<int>(set1);
            union.UnionWith(set2);
            Console.WriteLine($"\nUnion: {string.Join(", ", union)}");
            
            // Intersection
            SortedSet<int> intersection = new SortedSet<int>(set1);
            intersection.IntersectWith(set2);
            Console.WriteLine($"Intersection: {string.Join(", ", intersection)}");
            
            // Remove
            numbers.Remove(50);
            Console.WriteLine($"\nAfter removing 50: {string.Join(", ", numbers)}");
        }
    }
}
