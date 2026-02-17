namespace GenericsPractice.Problem1
{
    public interface IProduct
    {
        int Id { get; }
        string Name { get; }
        decimal Price { get; }
        Category Category { get; }
    }

    public enum Category
    {
        Electronics,
        Clothing,
        Books,
        Groceries
    }
}
