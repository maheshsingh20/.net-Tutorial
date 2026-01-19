using System;
using System.Collections.Generic;

namespace TopBrains.Questions
{
    public static class StringArrayExtensions
    {
        public static string[] DistinctBy(this string[] items, Func<string, string> keySelector)
        {
            HashSet<string> seenKeys = new HashSet<string>();
            List<string> result = new List<string>();
            
            foreach (string item in items)
            {
                string key = keySelector(item);
                if (seenKeys.Add(key))
                {
                    result.Add(item);
                }
            }
            
            return result.ToArray();
        }
    }
    
    public class Question26
    {
        public static string[] GetDistinctNames(string[] items)
        {
            HashSet<string> seenIds = new HashSet<string>();
            List<string> distinctNames = new List<string>();
            
            foreach (string item in items)
            {
                string[] parts = item.Split(':');
                if (parts.Length == 2)
                {
                    string id = parts[0];
                    string name = parts[1];
                    
                    if (seenIds.Add(id))
                    {
                        distinctNames.Add(name);
                    }
                }
            }
            
            return distinctNames.ToArray();
        }
        
        public static void Main(string[] args)
        {
            Console.Write("Enter number of items: ");
            int count = int.Parse(Console.ReadLine());
            
            string[] items = new string[count];
            Console.WriteLine("Enter items in format 'id:name':");
            
            for (int i = 0; i < count; i++)
            {
                Console.Write($"Item {i + 1}: ");
                items[i] = Console.ReadLine();
            }
            
            string[] distinctNames = GetDistinctNames(items);
            
            Console.WriteLine("\nDistinct names (first occurrence of each ID):");
            foreach (string name in distinctNames)
            {
                Console.WriteLine(name);
            }
            
            // Demonstrate extension method usage
            Console.WriteLine("\nUsing extension method:");
            string[] distinctItems = items.DistinctBy(item => item.Split(':')[0]);
            foreach (string item in distinctItems)
            {
                Console.WriteLine(item.Split(':')[1]);
            }
        }
    }
}