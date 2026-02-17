using System;

namespace GenericsPractice.Problem1
{
    public class DiscountedProduct<T> where T : IProduct
    {
        private T _product;
        private decimal _discountPercentage;

        public DiscountedProduct(T product, decimal discountPercentage)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product), "Product cannot be null");
            }

            if (discountPercentage < 0 || discountPercentage > 100)
            {
                throw new ArgumentException("Discount must be between 0 and 100");
            }

            _product = product;
            _discountPercentage = discountPercentage;
        }

        public T Product => _product;
        public decimal OriginalPrice => _product.Price;
        public decimal DiscountedPrice => _product.Price * (1 - _discountPercentage / 100);
        public decimal DiscountAmount => _product.Price * (_discountPercentage / 100);
        public decimal DiscountPercentage => _discountPercentage;

        public override string ToString()
        {
            return $"{_product.Name} - Original: ${OriginalPrice:F2}, " +
                   $"Discount: {_discountPercentage}%, " +
                   $"Final: ${DiscountedPrice:F2} (Save ${DiscountAmount:F2})";
        }
    }
}
