// Question 10: Command Pattern Mini Framework (Undo/Redo)
namespace m1Assessment_Practise.Questions.Question10;

class Problem
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Question 10: Command Pattern (Undo/Redo) ===\n");

        var cart = new ShoppingCart();
        var manager = new CommandManager();

        manager.ExecuteCommand(new AddItemCommand(cart, "Laptop"));
        manager.ExecuteCommand(new AddItemCommand(cart, "Mouse"));
        manager.ExecuteCommand(new ApplyDiscountCommand(cart, 50));
        cart.Display();

        Console.WriteLine("\n--- Undo last action ---");
        manager.Undo();
        cart.Display();

        Console.WriteLine("\n--- Undo again ---");
        manager.Undo();
        cart.Display();

        Console.WriteLine("\n--- Redo ---");
        manager.Redo();
        cart.Display();
    }
}
