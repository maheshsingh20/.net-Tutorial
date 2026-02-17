using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericsPractice.Problem1
{
    public class InventoryDemo
    {
        public static void Run()
        {
            Console.WriteLine("Problem 1: E-Commerce Inventory System\n");

            try
            {
                var electronicRepo = new ProductRepository<ElectronicProduct>();
                var clothingRepo = new ProductRepository<ClothingProduct>();
                var bookRepo = new ProductRepository<BookProduct>();
                var groceryRepo = new ProductRepository<GroceryProduct>();
                var manager = new InventoryManager();

                Console.WriteLine("STEP 1: Adding Products with Validation\n");

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

                clothingRepo.AddProduct(new ClothingProduct
                {
                    Id = 101,
                    Name = "Cotton T-Shirt",
                    Price = 19.99m,
                    Size = "M",
                    Color = "Blue"
                });

                bookRepo.AddProduct(new BookProduct
                {
                    Id = 201,
                    Name = "Clean Code",
                    Price = 39.99m,
                    Author = "Robert C. Martin",
                    ISBN = "978-0132350884"
                });

                groceryRepo.AddProduct(new GroceryProduct
                {
                    Id = 301,
                    Name = "Organic Apples",
                    Price = 4.99m,
                    Weight = 1.5,
                    ExpiryDate = DateTime.Now.AddDays(7)
                });

                Console.WriteLine("\nTesting Validation - Duplicate ID:");
                try
                {
                    electronicRepo.AddProduct(new ElectronicProduct
                    {
                        Id = 1,
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

                Console.WriteLine("\n\nSTEP 2: Finding Products by Brand (Apple)\n");
                var appleProducts = electronicRepo.FindProducts(p => p.Brand == "Apple");
                foreach (var product in appleProducts)
                {
                    Console.WriteLine($"  - {product}");
                }

                Console.WriteLine("\n\nSTEP 3: Applying Discounts\n");
                Console.WriteLine("20% Discount on All Electronics:");
                var discountedElectronics = manager.ApplyDiscounts(
                    electronicRepo.GetAllProducts(),
                    p => true,
                    20
                );
                foreach (var item in discountedElectronics)
                {
                    Console.WriteLine($"  - {item}");
                }

                Console.WriteLine("\n\nSTEP 4: Total Value Calculation\n");
                decimal totalBefore = electronicRepo.CalculateTotalValue() +
                                     clothingRepo.CalculateTotalValue() +
                                     bookRepo.CalculateTotalValue() +
                                     groceryRepo.CalculateTotalValue();

                Console.WriteLine($"Total Inventory Value: ${totalBefore:F2}");

                Console.WriteLine("\n\nSTEP 5: Processing Mixed Collection\n");
                var mixedProducts = new List<IProduct>();
                mixedProducts.AddRange(electronicRepo.GetAllProducts());
                mixedProducts.AddRange(clothingRepo.GetAllProducts());
                mixedProducts.AddRange(bookRepo.GetAllProducts());
                mixedProducts.AddRange(groceryRepo.GetAllProducts());

                manager.ProcessProducts(mixedProducts);

                Console.WriteLine("\n\nProgram completed successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError: {ex.Message}");
            }
        }
    }
}
