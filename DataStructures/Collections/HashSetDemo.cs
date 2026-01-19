using System;
using System.Collections.Generic;

namespace DataStructures.Collections
{
    public class HashSetDemo
    {
        public static void Run()
        {
            Console.WriteLine("\n=== HashSet Demo (Unique Elements) ===");
            
            // Creating a HashSet
            HashSet<int> numbers = new HashSet<int>();
            
            // Adding elements
            numbers.Add(10);
            numbers.Add(20);
            numbers.Add(30);
            numbers.Add(20); // Duplicate - won't be added
            numbers.Add(40);
            
            Console.WriteLine("HashSet elements:");
            foreach (int num in numbers)
            {
                Console.Write(num + " ");
            }
            
            Console.WriteLine($"\nCount: {numbers.Count}");
            
            // Set operations
            HashSet<int> set1 = new HashSet<int> { 1, 2, 3, 4, 5 };
            HashSet<int> set2 = new HashSet<int> { 4, 5, 6, 7, 8 };
            
            // Union
            HashSet<int> union = new HashSet<int>(set1);
            union.UnionWith(set2);
            Console.WriteLine($"\nUnion: {string.Join(", ", union)}");
            
            // Intersection
            HashSet<int> intersection = new HashSet<int>(set1);
            intersection.IntersectWith(set2);
            Console.WriteLine($"Intersection: {string.Join(", ", intersection)}");
            
            // Difference
            HashSet<int> difference = new HashSet<int>(set1);
            difference.ExceptWith(set2);
            Console.WriteLine($"Difference (set1 - set2): {string.Join(", ", difference)}");
            
            // Subset check
            HashSet<int> subset = new HashSet<int> { 1, 2 };
            Console.WriteLine($"Is {string.Join(", ", subset)} subset of set1? {subset.IsSubsetOf(set1)}");
        }
    }
}
