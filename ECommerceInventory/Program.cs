using System;
using System.Collections.Generic;
using System.Linq;

namespace ECommerceInventory
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("E-Commerce Inventory System with Generics\n");

            try
            {
                // Create repositories for different product types
                var electronicRepo = new ProductRepository<ElectronicProduct>();
                var clothingRepo = new ProductRepository<ClothingProduct>();
                var bookRepo = new ProductRepository<BookProduct>();
                var groceryRepo = new ProductRepository<GroceryProduct>();

                // Create inventory manager
                var manager = new InventoryManager();

                Console.WriteLine("STEP 1: Adding Products with Validation\n");

                // Add Electronic Products
                electronicRepo.AddProduct(new ElectronicProduct
                {
                    Id = 1,
                    Name = "iPhone 15 Pro",
                    Price = 999.99m,
                    Brand = "Apple",
                    WarrantyMonths = 12
                });

                electronicRepo.AddProduct(new ElectronicProduct
                {
                    Id = 2,
                    Name = "Samsung Galaxy S24",
                    Price = 849.99m,
                    Brand = "Samsung",
                    WarrantyMonths = 24
                });

                electronicRepo.AddProduct(new ElectronicProduct
                {
                    Id = 3,
                    Name = "MacBook Pro",
                    Price = 1999.99m,
                    Brand = "Apple",
                    WarrantyMonths = 12
                });

                electronicRepo.AddProduct(new ElectronicProduct
                {
                    Id = 4,
                    Name = "Wireless Mouse",
                    Price = 29.99m,
                    Brand = "Logitech",
                    WarrantyMonths = 6
                });

                // Add Clothing Products
                clothingRepo.AddProduct(new ClothingProduct
                {
                    Id = 101,
                    Name = "Cotton T-Shirt",
                    Price = 19.99m,
                    Size = "M",
                    Color = "Blue"
                });

                clothingRepo.AddProduct(new ClothingProduct
                {
                    Id = 102,
                    Name = "Denim Jeans",
                    Price = 49.99m,
                    Size = "32",
                    Color = "Dark Blue"
                });

                // Add Book Products
                bookRepo.AddProduct(new BookProduct
                {
                    Id = 201,
                    Name = "Clean Code",
                    Price = 39.99m,
                    Author = "Robert C. Martin",
                    ISBN = "978-0132350884"
                });

                bookRepo.AddProduct(new BookProduct
                {
                    Id = 202,
                    Name = "Design Patterns",
                    Price = 54.99m,
                    Author = "Gang of Four",
                    ISBN = "978-0201633610"
                });

                // Add Grocery Products
                groceryRepo.AddProduct(new GroceryProduct
                {
                    Id = 301,
                    Name = "Organic Apples",
                    Price = 4.99m,
                    Weight = 1.5,
                    ExpiryDate = DateTime.Now.AddDays(7)
                });

                groceryRepo.AddProduct(new GroceryProduct
                {
                    Id = 302,
                    Name = "Whole Wheat Bread",
                    Price = 3.49m,
                    Weight = 0.5,
                    ExpiryDate = DateTime.Now.AddDays(3)
                });

                // Test validation - duplicate ID
                Console.WriteLine("\nTesting Validation - Duplicate ID:");
                try
                {
                    electronicRepo.AddProduct(new ElectronicProduct
                    {
                        Id = 1, // Duplicate
                        Name = "Test Product",
                        Price = 100,
                        Brand = "Test",
                        WarrantyMonths = 12
                    });
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"  Caught: {ex.Message}");
                }

                // Test validation - negative price
                Console.WriteLine("\nTesting Validation - Negative Price:");
                try
                {
                    electronicRepo.AddProduct(new ElectronicProduct
                    {
                        Id = 99,
                        Name = "Invalid Product",
                        Price = -50, // Invalid
                        Brand = "Test",
                        WarrantyMonths = 12
                    });
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"  Caught: {ex.Message}");
                }

                // STEP 2: Finding Products by Brand
                Console.WriteLine("\n\nSTEP 2: Finding Products by Brand (Apple)\n");
                var appleProducts = electronicRepo.FindProducts(p => p.Brand == "Apple");
                foreach (var product in appleProducts)
                {
                    Console.WriteLine($"  - {product}");
                }

                // STEP 3: Applying Discounts
                Console.WriteLine("\n\nSTEP 3: Applying Discounts\n");

                // 20% discount on all electronics
                Console.WriteLine("\n20% Discount on All Electronics:");
                var discountedElectronics = manager.ApplyDiscounts(
                    electronicRepo.GetAllProducts(),
                    p => true,
                    20
                );
                foreach (var item in discountedElectronics)
                {
                    Console.WriteLine($"  - {item}");
                }

                // 15% discount on books over $40
                Console.WriteLine("\n15% Discount on Books Over $40:");
                var discountedBooks = manager.ApplyDiscounts(
                    bookRepo.GetAllProducts(),
                    p => p.Price > 40,
                    15
                );
                foreach (var item in discountedBooks)
                {
                    Console.WriteLine($"  - {item}");
                }

                // STEP 4: Calculate Total Value Before/After Discount
                Console.WriteLine("\n\nSTEP 4: Total Value Calculation\n");

                decimal totalBefore = electronicRepo.CalculateTotalValue() +
                                     clothingRepo.CalculateTotalValue() +
                                     bookRepo.CalculateTotalValue() +
                                     groceryRepo.CalculateTotalValue();

                Console.WriteLine($"Total Inventory Value (Before Discount): ${totalBefore:F2}");

                // Calculate after 10% discount on electronics over $500
                var expensiveElectronics = electronicRepo.FindProducts(p => p.Price > 500);
                decimal electronicsDiscount = expensiveElectronics.Sum(p => p.Price * 0.10m);
                decimal totalAfter = totalBefore - electronicsDiscount;

                Console.WriteLine($"Discount on Electronics Over $500 (10%): -${electronicsDiscount:F2}");
                Console.WriteLine($"Total Inventory Value (After Discount): ${totalAfter:F2}");
                Console.WriteLine($"Total Savings: ${electronicsDiscount:F2}");

                // STEP 5: Handling Mixed Collection
                Console.WriteLine("\n\nSTEP 5: Processing Mixed Collection\n");

                // Create a mixed collection using IProduct interface
                var mixedProducts = new List<IProduct>();
                mixedProducts.AddRange(electronicRepo.GetAllProducts());
                mixedProducts.AddRange(clothingRepo.GetAllProducts());
                mixedProducts.AddRange(bookRepo.GetAllProducts());
                mixedProducts.AddRange(groceryRepo.GetAllProducts());

                manager.ProcessProducts(mixedProducts);

                // STEP 6: Display Individual Repository Summaries
                Console.WriteLine("\n\nSTEP 6: Repository Summaries\n");

                Console.WriteLine("\nElectronics Repository:");
                manager.DisplayInventorySummary(electronicRepo);

                Console.WriteLine("\nClothing Repository:");
                manager.DisplayInventorySummary(clothingRepo);

                Console.WriteLine("\nBooks Repository:");
                manager.DisplayInventorySummary(bookRepo);

                Console.WriteLine("\nGroceries Repository:");
                manager.DisplayInventorySummary(groceryRepo);

                // STEP 7: Bulk Price Update Demonstration
                Console.WriteLine("\n\nSTEP 7: Bulk Price Update (10% increase on all electronics)\n");

                var electronicsList = electronicRepo.GetAllProducts().ToList();
                manager.UpdatePrices(electronicsList, product => product.Price * 1.10m);

                // STEP 8: Advanced Queries
                Console.WriteLine("\n\nSTEP 8: Advanced Queries\n");

                // Find products in specific price range
                Console.WriteLine("\nProducts Between $30 and $100:");
                var midRangeProducts = mixedProducts.Where(p => p.Price >= 30 && p.Price <= 100);
                foreach (var product in midRangeProducts)
                {
                    Console.WriteLine($"  - {product.Name}: ${product.Price:F2} ({product.Category})");
                }

                // Find cheapest product in each category
                Console.WriteLine("\nCheapest Product in Each Category:");
                var cheapestByCategory = mixedProducts
                    .GroupBy(p => p.Category)
                    .Select(g => g.OrderBy(p => p.Price).First());
                foreach (var product in cheapestByCategory)
                {
                    Console.WriteLine($"  - {product.Category}: {product.Name} (${product.Price:F2})");
                }

                Console.WriteLine("\n\nProgram completed successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError: {ex.Message}");
                Console.WriteLine($"Stack Trace: {ex.StackTrace}");
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
