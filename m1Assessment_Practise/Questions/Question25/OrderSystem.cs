namespace m1Assessment_Practise.Questions.Question25;

class OrderSystem
{
    private readonly Dictionary<string, Product> _products = new();
    private readonly List<OrderItem> _cart = new();
    private int _invoiceCounter = 1000;
    private readonly object _lock = new();

    public void AddProduct(Product product)
    {
        _products[product.ProductId] = product;
    }

    public void AddToCart(string productId, int quantity)
    {
        if (!_products.ContainsKey(productId))
            throw new ArgumentException($"Product {productId} not found");

        var product = _products[productId];
        _cart.Add(new OrderItem { Product = product, Quantity = quantity });
        Console.WriteLine($"Added {quantity}x {product.Name} to cart");
    }

    public Order PlaceOrder(Customer customer, string? couponCode = null)
    {
        lock (_lock)
        {
            if (_cart.Count == 0)
                throw new InvalidOperationException("Cart is empty");

            foreach (var item in _cart)
            {
                if (item.Product.Stock < item.Quantity)
                {
                    throw new InsufficientStockException(
                        $"Insufficient stock for {item.Product.Name}. Available: {item.Product.Stock}, Requested: {item.Quantity}");
                }
            }

            var order = new Order
            {
                OrderId = Guid.NewGuid().ToString().Substring(0, 8),
                Customer = customer,
                Items = new List<OrderItem>(_cart)
            };

            if (!string.IsNullOrWhiteSpace(couponCode))
            {
                order.Discount = ApplyCoupon(couponCode, order);
            }

            foreach (var item in order.Items)
            {
                item.Product.Stock -= item.Quantity;
            }

            order.InvoiceNumber = $"INV-{++_invoiceCounter}";

            _cart.Clear();
            return order;
        }
    }

    private decimal ApplyCoupon(string couponCode, Order order)
    {
        return couponCode.ToUpper() switch
        {
            "SAVE10" => order.Items.Sum(i => i.Subtotal) * 0.10m,
            "SAVE20" => order.Items.Sum(i => i.Subtotal) * 0.20m,
            _ => throw new InvalidCouponException($"Invalid coupon code: {couponCode}")
        };
    }
}
