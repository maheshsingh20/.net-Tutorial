using System;
using System.Collections.Generic;
using System.Linq;

namespace TopBrains.Questions
{
    public class Question18
    {
        public static SortedDictionary<string, long> itemDetails = new SortedDictionary<string, long>
        {
            {"Laptop", 150},
            {"Mouse", 300},
            {"Keyboard", 200},
            {"Monitor", 100},
            {"Headphones", 250}
        };
        
        public static SortedDictionary<string, long> FindItemDetails(long soldCount)
        {
            SortedDictionary<string, long> result = new SortedDictionary<string, long>();
            
            foreach (var item in itemDetails)
            {
                if (item.Value == soldCount)
                {
                    result.Add(item.Key, item.Value);
                }
            }
            
            return result;
        }
        
        public static List<string> FindMinandMaxSoldItems()
        {
            List<string> result = new List<string>();
            
            if (itemDetails.Count == 0)
                return result;
            
            long minCount = itemDetails.Values.Min();
            long maxCount = itemDetails.Values.Max();
            
            string minItem = itemDetails.First(x => x.Value == minCount).Key;
            string maxItem = itemDetails.First(x => x.Value == maxCount).Key;
            
            result.Add(minItem);
            result.Add(maxItem);
            
            return result;
        }
        
        public static Dictionary<string, long> SortByCount()
        {
            return itemDetails.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
        }
        
        public static void Main(string[] args)
        {
            Console.WriteLine("Item Details:");
            foreach (var item in itemDetails)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
            
            Console.Write("\nEnter sold count to search: ");
            long soldCount = long.Parse(Console.ReadLine());
            
            var foundItems = FindItemDetails(soldCount);
            if (foundItems.Count == 0)
            {
                Console.WriteLine("Invalid sold count");
            }
            else
            {
                Console.WriteLine("Found items:");
                foreach (var item in foundItems)
                {
                    Console.WriteLine($"{item.Key}: {item.Value}");
                }
            }
            
            var minMaxItems = FindMinandMaxSoldItems();
            Console.WriteLine($"\nMin sold item: {minMaxItems[0]}");
            Console.WriteLine($"Max sold item: {minMaxItems[1]}");
            
            Console.WriteLine("\nItems sorted by count:");
            var sortedItems = SortByCount();
            foreach (var item in sortedItems)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}