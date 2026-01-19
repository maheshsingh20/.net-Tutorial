using System;
using System.Collections.Generic;

namespace DataStructures.Collections
{
    public class DictionaryDemo
    {
        public static void Run()
        {
            Console.WriteLine("\n=== Dictionary Demo ===");
            
            // Creating a Dictionary
            Dictionary<string, int> ages = new Dictionary<string, int>();
            
            // Adding key-value pairs
            ages.Add("Alice", 25);
            ages.Add("Bob", 30);
            ages.Add("Charlie", 35);
            ages["David"] = 28; // Alternative way to add
            
            Console.WriteLine("Dictionary elements:");
            foreach (KeyValuePair<string, int> kvp in ages)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }
            
            // Accessing values
            Console.WriteLine($"\nBob's age: {ages["Bob"]}");
            
            // TryGetValue (safe access)
            if (ages.TryGetValue("Alice", out int aliceAge))
            {
                Console.WriteLine($"Alice's age: {aliceAge}");
            }
            
            // Checking if key exists
            Console.WriteLine($"Contains 'Eve'? {ages.ContainsKey("Eve")}");
            Console.WriteLine($"Contains value 30? {ages.ContainsValue(30)}");
            
            // Updating value
            ages["Bob"] = 31;
            Console.WriteLine($"Bob's updated age: {ages["Bob"]}");
            
            // Removing element
            ages.Remove("Charlie");
            Console.WriteLine($"After removing Charlie, Count: {ages.Count}");
        }
    }
}
