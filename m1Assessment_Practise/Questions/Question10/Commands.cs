namespace m1Assessment_Practise.Questions.Question10;

class AddItemCommand : ICommand
{
    private readonly ShoppingCart _cart;
    private readonly string _item;

    public AddItemCommand(ShoppingCart cart, string item)
    {
        _cart = cart;
        _item = item;
    }

    public void Execute() => _cart.AddItem(_item);
    public void Undo() => _cart.RemoveItem(_item);
}

class RemoveItemCommand : ICommand
{
    private readonly ShoppingCart _cart;
    private readonly string _item;

    public RemoveItemCommand(ShoppingCart cart, string item)
    {
        _cart = cart;
        _item = item;
    }

    public void Execute() => _cart.RemoveItem(_item);
    public void Undo() => _cart.AddItem(_item);
}

class ApplyDiscountCommand : ICommand
{
    private readonly ShoppingCart _cart;
    private readonly decimal _amount;

    public ApplyDiscountCommand(ShoppingCart cart, decimal amount)
    {
        _cart = cart;
        _amount = amount;
    }

    public void Execute() => _cart.ApplyDiscount(_amount);
    public void Undo() => _cart.RemoveDiscount(_amount);
}
