using System;
using System.Collections.Generic;

namespace YetAnotherVendingMachine
{
    internal class ProductProvider : IProductProvider
    {
        private readonly IVendingMachine _vendingMachine;

        public ProductProvider(IVendingMachine vendingMachine)
        {
            _vendingMachine = vendingMachine;
        }

        public Product SellProduct(int productNumber, List<int> purchasedProducts)
        {
            if (purchasedProducts.Contains(productNumber))
            {
                throw new ProductNotMoreOneException();
            }
            var product = GetProduct(productNumber);
            if (product.Available == 0)
            {
                throw new ProductNotAvailableException();
            }
            DecreaseAvailabledProduct(productNumber);
            //todo: unexpected behavior, move to more related method
            purchasedProducts.Add(productNumber);
            return product;
        }

        /// <summary>
        /// Decrease available amount of product  
        /// </summary>
        /// <param name="productNumber"></param>
        public void DecreaseAvailabledProduct(int productNumber)
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
        public Product GetProduct(int productNumber)
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
