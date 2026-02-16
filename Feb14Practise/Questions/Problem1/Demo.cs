using System;

namespace Problem1.SmartWarehouse
{
    public class Demo
    {
        public static void Run()
        {
            Console.WriteLine("\nProblem 1: Smart Warehouse Inventory System\n");
            WarehouseManager warehouse = new WarehouseManager();

            try
            {
                warehouse.AddProduct(1, new Electronics("E001", "Laptop", 50, 10, 24));
                warehouse.AddProduct(1, new Electronics("E002", "Phone", 100, 20, 12));
                warehouse.AddProduct(5, new Perishable("P001", "Milk", 200, 50, DateTime.Now.AddDays(7)));
                warehouse.AddProduct(3, new FragileItem("F001", "Glass Vase", 30, 5, "Handle with care"));

                warehouse.DisplayInventory();

                Console.WriteLine("\nHighest Priority Products:");
                var highPriority = warehouse.GetHighestPriorityProducts();
                foreach (var p in highPriority)
                    Console.WriteLine($"  {p.Name}");

                Console.WriteLine("\nUpdating Stock:");
                warehouse.UpdateStock("E001", 8);

                Console.WriteLine("\nTesting Low Stock Exception:");
                warehouse.UpdateStock("E001", 5);
            }
            catch (LowStockException ex)
            {
                Console.WriteLine($"LOW STOCK ALERT: {ex.Message}");
            }
            catch (DuplicateSKUException ex)
            {
                Console.WriteLine($"DUPLICATE ERROR: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR: {ex.Message}");
            }
        }
    }
}
