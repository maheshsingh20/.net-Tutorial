using System;

namespace ECommerceInventory
{
    public class ElectronicProduct : IProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Category Category => Category.Electronics;
        public int WarrantyMonths { get; set; }
        public string Brand { get; set; }

        public override string ToString()
        {
            return $"{Name} - {Brand} (${Price}, {WarrantyMonths} months warranty)";
        }
    }

    public class ClothingProduct : IProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Category Category => Category.Clothing;
        public string Size { get; set; }
        public string Color { get; set; }

        public override string ToString()
        {
            return $"{Name} - {Size}, {Color} (${Price})";
        }
    }

    public class BookProduct : IProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Category Category => Category.Books;
        public string Author { get; set; }
        public string ISBN { get; set; }

        public override string ToString()
        {
            return $"{Name} by {Author} (${Price})";
        }
    }

    public class GroceryProduct : IProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Category Category => Category.Groceries;
        public DateTime ExpiryDate { get; set; }
        public double Weight { get; set; }

        public override string ToString()
        {
            return $"{Name} - {Weight}kg (${Price}, Expires: {ExpiryDate:yyyy-MM-dd})";
        }
    }
}
