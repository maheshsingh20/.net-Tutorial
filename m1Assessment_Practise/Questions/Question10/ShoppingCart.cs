namespace m1Assessment_Practise.Questions.Question10;

class ShoppingCart
{
    private readonly List<string> _items = new();
    private decimal _discount = 0;

    public void AddItem(string item)
    {
        _items.Add(item);
        Console.WriteLine($"Added: {item}");
    }

    public void RemoveItem(string item)
    {
        _items.Remove(item);
        Console.WriteLine($"Removed: {item}");
    }

    public void ApplyDiscount(decimal amount)
    {
        _discount += amount;
        Console.WriteLine($"Applied discount: {amount:C}");
    }

    public void RemoveDiscount(decimal amount)
    {
        _discount -= amount;
        Console.WriteLine($"Removed discount: {amount:C}");
    }

    public void Display()
    {
        Console.WriteLine($"\nCart: [{string.Join(", ", _items)}], Discount: {_discount:C}");
    }
}
