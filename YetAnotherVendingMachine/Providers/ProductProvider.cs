using System;
using System.Collections.Generic;

namespace YetAnotherVendingMachine
{
    internal class ProductProvider : IProductProvider
    {
        private readonly IVendingMachine _vendingMachine;
        /// <summary>
        /// Contains sold products in current session
        /// </summary>
        private List<int> _purchasedProducts;

        public ProductProvider(IVendingMachine vendingMachine)
        {
            _vendingMachine = vendingMachine;
            _purchasedProducts = new List<int>();
        }

        /// <summary>
        /// Give product
        /// </summary>
        public Product GiveProduct(int productNumber)
        {
            if (_purchasedProducts.Contains(productNumber))
            {
                throw new ProductNotMoreOneException();
            }
            var product = GetProduct(productNumber);
            if (product.Available == 0)
            {
                throw new ProductNotAvailableException();
            }
            DecreaseAvailabledProduct(productNumber);
            _purchasedProducts.Add(productNumber);
            return product;
        }

        /// <summary>
        /// Reset information about the purchased products
        /// </summary>
        public void ResetState()
        {
            _purchasedProducts = new List<int>();
        }

        /// <summary>
        /// Decrease available amount of product  
        /// </summary>
        /// <param name="productNumber"></param>
        private void DecreaseAvailabledProduct(int productNumber)
        {
            var product = GetProduct(productNumber);
            _vendingMachine.Products[productNumber] = new Product()
            {
                Available = product.Available - 1,
                Price = product.Price,
                Name = product.Name
            };
        }

        /// <summary>
        /// Get product from product list
        /// </summary>
        /// <param name="productNumber"></param>
        /// <returns><see cref="Product"/></returns>
        /// <exception cref="ProductNotFoundException"></exception>
        private Product GetProduct(int productNumber)
        {
            Product product;
            try
            {
                product = _vendingMachine.Products[productNumber];
            }
            catch (IndexOutOfRangeException)
            {
                throw new ProductNotFoundException();
            }
            return product;
        }
    }
}
