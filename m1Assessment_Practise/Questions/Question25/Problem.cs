// Question 25: End-to-End Mini Order System
namespace m1Assessment_Practise.Questions.Question25;

class Problem
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Question 25: Mini Order System ===\n");

        var system = new OrderSystem();

        system.AddProduct(new Product { ProductId = "P001", Name = "Laptop", Price = 1000, Stock = 5 });
        system.AddProduct(new Product { ProductId = "P002", Name = "Mouse", Price = 25, Stock = 10 });

        var customer = new Customer { CustomerId = "C001", Name = "John Doe" };

        try
        {
            system.AddToCart("P001", 2);
            system.AddToCart("P002", 3);

            var order = system.PlaceOrder(customer, "SAVE10");

            Console.WriteLine($"\n=== Order Placed ===");
            Console.WriteLine($"Order ID: {order.OrderId}");
            Console.WriteLine($"Invoice: {order.InvoiceNumber}");
            Console.WriteLine($"Customer: {order.Customer.Name}");
            Console.WriteLine($"Items:");
            foreach (var item in order.Items)
            {
                Console.WriteLine($"  {item.Quantity}x {item.Product.Name} @ {item.Product.Price:C} = {item.Subtotal:C}");
            }
            Console.WriteLine($"Discount: {order.Discount:C}");
            Console.WriteLine($"Total: {order.Total:C}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
