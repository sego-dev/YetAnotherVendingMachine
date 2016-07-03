using System.Collections.Generic;

namespace YetAnotherVendingMachine
{
    public interface IProductProvider
    {
        /// <summary>
        /// Give available product
        /// </summary>
        Product GiveProduct(int productNumber);

        /// <summary>
        /// Find product by product number
        /// </summary>
        Product GetProduct(int productNumber);

        /// <summary>
        /// Reset information about the purchased products
        /// </summary>
        void ResetState();
    }
}