using System.Linq;

namespace YetAnotherVendingMachine
{
    internal class ProductValidator : IProductValidator
    {
        public void Validate(Product[] products)
        {
            if (products.Any(product => product.Available < 0))
            {
                throw new ProductValidateException("Amount available of product cannot be less than zero.");
            }
        }
    }
}