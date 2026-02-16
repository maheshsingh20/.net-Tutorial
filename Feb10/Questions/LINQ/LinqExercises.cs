using System;
using System.Collections.Generic;
using System.Linq;

namespace Feb10.Questions.LINQ
{
    class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; } = "";
        public string Category { get; set; } = "";
        public decimal Price { get; set; }
        public int Stock { get; set; }
    }

    class LinqExercises
    {
        public static void RunExercises()
        {
            Console.WriteLine("=== LINQ Practice Exercises ===\n");

            var products = GetProducts();

            // Exercise 1: Find all products with price > 500
            Console.WriteLine("Exercise 1: Products with Price > 500");
            var expensiveProducts = products.Where(p => p.Price > 500);
            foreach (var p in expensiveProducts)
            {
                Console.WriteLine($"  {p.Name} - {p.Price:C}");
            }

            // Exercise 2: Get product names in Electronics category
            Console.WriteLine("\nExercise 2: Electronics Product Names");
            var electronics = products
                .Where(p => p.Category == "Electronics")
                .Select(p => p.Name);
            foreach (var name in electronics)
            {
                Console.WriteLine($"  {name}");
            }

            // Exercise 3: Count products by category
            Console.WriteLine("\nExercise 3: Product Count by Category");
            var categoryCount = products
                .GroupBy(p => p.Category)
                .Select(g => new { Category = g.Key, Count = g.Count() });
            foreach (var item in categoryCount)
            {
                Console.WriteLine($"  {item.Category}: {item.Count}");
            }

            // Exercise 4: Find most expensive product
            Console.WriteLine("\nExercise 4: Most Expensive Product");
            var mostExpensive = products.OrderByDescending(p => p.Price).First();
            Console.WriteLine($"  {mostExpensive.Name} - {mostExpensive.Price:C}");

            // Exercise 5: Calculate total inventory value
            Console.WriteLine("\nExercise 5: Total Inventory Value");
            var totalValue = products.Sum(p => p.Price * p.Stock);
            Console.WriteLine($"  {totalValue:C}");

            // Exercise 6: Products with low stock (< 20)
            Console.WriteLine("\nExercise 6: Low Stock Products (< 20)");
            var lowStock = products.Where(p => p.Stock < 20);
            foreach (var p in lowStock)
            {
                Console.WriteLine($"  {p.Name} - Stock: {p.Stock}");
            }

            // Exercise 7: Average price by category
            Console.WriteLine("\nExercise 7: Average Price by Category");
            var avgPriceByCategory = products
                .GroupBy(p => p.Category)
                .Select(g => new { Category = g.Key, AvgPrice = g.Average(p => p.Price) });
            foreach (var item in avgPriceByCategory)
            {
                Console.WriteLine($"  {item.Category}: {item.AvgPrice:C}");
            }

            // Exercise 8: Top 3 most stocked products
            Console.WriteLine("\nExercise 8: Top 3 Most Stocked Products");
            var topStocked = products.OrderByDescending(p => p.Stock).Take(3);
            foreach (var p in topStocked)
            {
                Console.WriteLine($"  {p.Name} - Stock: {p.Stock}");
            }

            // Exercise 9: Products sorted by category, then by price
            Console.WriteLine("\nExercise 9: Products Sorted by Category, then Price");
            var sorted = products.OrderBy(p => p.Category).ThenBy(p => p.Price);
            foreach (var p in sorted)
            {
                Console.WriteLine($"  {p.Category} - {p.Name} ({p.Price:C})");
            }

            // Exercise 10: Check if any product is out of stock
            Console.WriteLine("\nExercise 10: Any Product Out of Stock?");
            bool anyOutOfStock = products.Any(p => p.Stock == 0);
            Console.WriteLine($"  {anyOutOfStock}");

            // Exercise 11: Get distinct categories
            Console.WriteLine("\nExercise 11: Distinct Categories");
            var categories = products.Select(p => p.Category).Distinct();
            foreach (var cat in categories)
            {
                Console.WriteLine($"  {cat}");
            }

            // Exercise 12: Products with name containing "Pro"
            Console.WriteLine("\nExercise 12: Products with 'Pro' in Name");
            var proProducts = products.Where(p => p.Name.Contains("Pro"));
            foreach (var p in proProducts)
            {
                Console.WriteLine($"  {p.Name}");
            }

            // Exercise 13: Total stock by category
            Console.WriteLine("\nExercise 13: Total Stock by Category");
            var stockByCategory = products
                .GroupBy(p => p.Category)
                .Select(g => new { Category = g.Key, TotalStock = g.Sum(p => p.Stock) });
            foreach (var item in stockByCategory)
            {
                Console.WriteLine($"  {item.Category}: {item.TotalStock} units");
            }

            // Exercise 14: Products in price range 300-700
            Console.WriteLine("\nExercise 14: Products in Price Range 300-700");
            var priceRange = products.Where(p => p.Price >= 300 && p.Price <= 700);
            foreach (var p in priceRange)
            {
                Console.WriteLine($"  {p.Name} - {p.Price:C}");
            }

            // Exercise 15: Create anonymous type with discount
            Console.WriteLine("\nExercise 15: Products with 10% Discount");
            var discounted = products.Select(p => new
            {
                p.Name,
                OriginalPrice = p.Price,
                DiscountedPrice = p.Price * 0.9m
            });
            foreach (var p in discounted.Take(3))
            {
                Console.WriteLine($"  {p.Name}: {p.OriginalPrice:C} -> {p.DiscountedPrice:C}");
            }

            Console.WriteLine("\n=== End of Exercises ===");
        }

        static List<Product> GetProducts()
        {
            return new List<Product>
            {
                new Product { ProductId = 1, Name = "Laptop Pro", Category = "Electronics", Price = 1200, Stock = 15 },
                new Product { ProductId = 2, Name = "Mouse", Category = "Electronics", Price = 25, Stock = 50 },
                new Product { ProductId = 3, Name = "Keyboard", Category = "Electronics", Price = 75, Stock = 30 },
                new Product { ProductId = 4, Name = "Monitor", Category = "Electronics", Price = 300, Stock = 20 },
                new Product { ProductId = 5, Name = "Desk Chair", Category = "Furniture", Price = 250, Stock = 10 },
                new Product { ProductId = 6, Name = "Desk", Category = "Furniture", Price = 400, Stock = 8 },
                new Product { ProductId = 7, Name = "Notebook", Category = "Stationery", Price = 5, Stock = 100 },
                new Product { ProductId = 8, Name = "Pen Set", Category = "Stationery", Price = 15, Stock = 75 },
                new Product { ProductId = 9, Name = "Tablet Pro", Category = "Electronics", Price = 600, Stock = 12 },
                new Product { ProductId = 10, Name = "Headphones", Category = "Electronics", Price = 150, Stock = 25 }
            };
        }
    }
}
