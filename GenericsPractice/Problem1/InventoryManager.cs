using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericsPractice.Problem1
{
    public class InventoryManager
    {
        public void ProcessProducts<T>(IEnumerable<T> products) where T : IProduct
        {
            Console.WriteLine("\nProcessing Products:");

            var productList = products.ToList();

            Console.WriteLine("\nAll Products:");
            foreach (var product in productList)
            {
                Console.WriteLine($"  - {product.Name}: ${product.Price:F2}");
            }

            if (productList.Any())
            {
                var mostExpensive = productList.OrderByDescending(p => p.Price).First();
                Console.WriteLine($"\nMost Expensive: {mostExpensive.Name} (${mostExpensive.Price:F2})");
            }

            Console.WriteLine("\nProducts by Category:");
            var grouped = productList.GroupBy(p => p.Category);
            foreach (var group in grouped)
            {
                Console.WriteLine($"\n  {group.Key}:");
                foreach (var product in group)
                {
                    Console.WriteLine($"    - {product.Name} (${product.Price:F2})");
                }
            }

            Console.WriteLine("\nElectronics Over $500 (with 10% discount):");
            var expensiveElectronics = productList
                .Where(p => p.Category == Category.Electronics && p.Price > 500);

            foreach (var product in expensiveElectronics)
            {
                var discounted = new DiscountedProduct<T>(product, 10);
                Console.WriteLine($"  - {discounted}");
            }
        }

        public void UpdatePrices<T>(List<T> products, Func<T, decimal> priceAdjuster) where T : IProduct
        {
            Console.WriteLine("\nUpdating Prices:");

            try
            {
                foreach (var product in products)
                {
                    decimal oldPrice = product.Price;
                    decimal newPrice = priceAdjuster(product);

                    if (newPrice <= 0)
                    {
                        Console.WriteLine($"  Warning: Invalid price for {product.Name}, skipping");
                        continue;
                    }

                    Console.WriteLine($"  {product.Name}: ${oldPrice:F2} → ${newPrice:F2}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"  Error updating prices: {ex.Message}");
            }
        }

        public List<DiscountedProduct<T>> ApplyDiscounts<T>(IEnumerable<T> products, 
                                                            Func<T, bool> predicate, 
                                                            decimal discountPercentage) where T : IProduct
        {
            var discountedProducts = new List<DiscountedProduct<T>>();

            foreach (var product in products.Where(predicate))
            {
                try
                {
                    var discounted = new DiscountedProduct<T>(product, discountPercentage);
                    discountedProducts.Add(discounted);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error applying discount to {product.Name}: {ex.Message}");
                }
            }

            return discountedProducts;
        }

        public void DisplayInventorySummary<T>(ProductRepository<T> repository) where T : class, IProduct
        {
            Console.WriteLine("\nInventory Summary:");
            Console.WriteLine($"Total Products: {repository.Count}");
            Console.WriteLine($"Total Value: ${repository.CalculateTotalValue():F2}");

            var products = repository.GetAllProducts().ToList();
            var byCategory = products.GroupBy(p => p.Category);

            Console.WriteLine("\nBreakdown by Category:");
            foreach (var group in byCategory)
            {
                var count = group.Count();
                var value = group.Sum(p => p.Price);
                Console.WriteLine($"  {group.Key}: {count} items, ${value:F2}");
            }
        }
    }
}
