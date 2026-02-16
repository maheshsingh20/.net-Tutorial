using System;
using System.Collections.Generic;

namespace DataStructures.Collections
{
    public class DictionaryDemo
    {
        public static void Run()
        {
            Console.WriteLine("\n=== Dictionary Demo ===");
            
            Dictionary<string, int> ages = new Dictionary<string, int>();
            ages.Add("Alice", 25);
            ages.Add("Bob", 30);
            ages.Add("Charlie", 35);
            ages["David"] = 28;
            
            Console.WriteLine("Dictionary elements:");
            foreach (KeyValuePair<string, int> kvp in ages)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }
            
            Console.WriteLine($"\nBob's age: {ages["Bob"]}");
            
            if (ages.TryGetValue("Alice", out int aliceAge))
            {
                Console.WriteLine($"Alice's age: {aliceAge}");
            }
            
            Console.WriteLine($"Contains 'Eve'? {ages.ContainsKey("Eve")}");
            Console.WriteLine($"Contains value 30? {ages.ContainsValue(30)}");
            
            ages["Bob"] = 31;
            Console.WriteLine($"Bob's updated age: {ages["Bob"]}");
            
            ages.Remove("Charlie");
            Console.WriteLine($"After removing Charlie, Count: {ages.Count}");
        }
    }
}
