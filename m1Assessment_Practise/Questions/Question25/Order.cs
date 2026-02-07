namespace m1Assessment_Practise.Questions.Question25;

class Order
{
    public string OrderId { get; set; } = "";
    public Customer Customer { get; set; } = null!;
    public List<OrderItem> Items { get; set; } = new();
    public decimal Discount { get; set; }
    public decimal Total => Items.Sum(i => i.Subtotal) - Discount;
    public string InvoiceNumber { get; set; } = "";
}
