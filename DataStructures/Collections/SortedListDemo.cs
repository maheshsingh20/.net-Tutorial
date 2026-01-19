using System;
using System.Collections.Generic;

namespace DataStructures.Collections
{
    public class SortedListDemo
    {
        public static void Run()
        {
            Console.WriteLine("\n=== SortedList Demo (Sorted by Key) ===");
            
            // Creating a SortedList
            SortedList<int, string> students = new SortedList<int, string>();
            
            // Adding elements (automatically sorted by key)
            students.Add(103, "Charlie");
            students.Add(101, "Alice");
            students.Add(105, "Eve");
            students.Add(102, "Bob");
            students.Add(104, "David");
            
            Console.WriteLine("SortedList elements (sorted by key):");
            foreach (KeyValuePair<int, string> kvp in students)
            {
                Console.WriteLine($"ID: {kvp.Key}, Name: {kvp.Value}");
            }
            
            // Accessing by key
            Console.WriteLine($"\nStudent with ID 103: {students[103]}");
            
            // Accessing by index
            Console.WriteLine($"First student: {students.Values[0]}");
            Console.WriteLine($"Last student: {students.Values[students.Count - 1]}");
            
            // Getting keys and values
            Console.WriteLine($"\nAll IDs: {string.Join(", ", students.Keys)}");
            Console.WriteLine($"All Names: {string.Join(", ", students.Values)}");
            
            // Removing element
            students.Remove(102);
            Console.WriteLine($"\nAfter removing ID 102, Count: {students.Count}");
            
            // IndexOfKey and IndexOfValue
            Console.WriteLine($"Index of key 104: {students.IndexOfKey(104)}");
            Console.WriteLine($"Index of value 'Eve': {students.IndexOfValue("Eve")}");
        }
    }
}
