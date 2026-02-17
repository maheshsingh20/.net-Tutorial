using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericsPractice.Problem1
{
    public class ProductRepository<T> where T : class, IProduct
    {
        private List<T> _products = new List<T>();

        public void AddProduct(T product)
        {
            if (_products.Any(p => p.Id == product.Id))
            {
                throw new InvalidOperationException($"Product with ID {product.Id} already exists");
            }

            if (product.Price <= 0)
            {
                throw new ArgumentException("Price must be positive");
            }

            if (string.IsNullOrWhiteSpace(product.Name))
            {
                throw new ArgumentException("Name cannot be null or empty");
            }

            _products.Add(product);
            Console.WriteLine($"Added: {product.Name} (ID: {product.Id}, Price: ${product.Price})");
        }

        public IEnumerable<T> FindProducts(Func<T, bool> predicate)
        {
            return _products.Where(predicate);
        }

        public decimal CalculateTotalValue()
        {
            return _products.Sum(p => p.Price);
        }

        public IEnumerable<T> GetAllProducts()
        {
            return _products;
        }

        public int Count => _products.Count;
    }
}
