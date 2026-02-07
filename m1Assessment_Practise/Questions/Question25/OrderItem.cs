namespace m1Assessment_Practise.Questions.Question25;

class OrderItem
{
    public Product Product { get; set; } = null!;
    public int Quantity { get; set; }
    public decimal Subtotal => Product.Price * Quantity;
}
