using System;
using System.Collections.Generic;

namespace DataStructures.Collections
{
    public class SortedDictionaryDemo
    {
        public static void Run()
        {
            Console.WriteLine("\n=== SortedDictionary Demo ===");
            
            // Creating a SortedDictionary
            SortedDictionary<string, double> products = new SortedDictionary<string, double>();
            
            // Adding elements (automatically sorted by key)
            products.Add("Laptop", 999.99);
            products.Add("Mouse", 25.50);
            products.Add("Keyboard", 75.00);
            products.Add("Monitor", 299.99);
            products.Add("Headphones", 150.00);
            
            Console.WriteLine("SortedDictionary elements (sorted alphabetically by key):");
            foreach (KeyValuePair<string, double> kvp in products)
            {
                Console.WriteLine($"{kvp.Key}: ${kvp.Value}");
            }
            
            // Accessing values
            Console.WriteLine($"\nLaptop price: ${products["Laptop"]}");
            
            // TryGetValue
            if (products.TryGetValue("Mouse", out double mousePrice))
            {
                Console.WriteLine($"Mouse price: ${mousePrice}");
            }
            
            // Updating value
            products["Keyboard"] = 79.99;
            Console.WriteLine($"Updated Keyboard price: ${products["Keyboard"]}");
            
            // Keys and Values
            Console.WriteLine($"\nAll products: {string.Join(", ", products.Keys)}");
            
            Console.WriteLine($"Count: {products.Count}");
        }
    }
}
