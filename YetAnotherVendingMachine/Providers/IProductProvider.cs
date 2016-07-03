using System.Collections.Generic;

namespace YetAnotherVendingMachine
{
    public interface IProductProvider
    {
        /// <summary>
        /// Give product
        /// </summary>
        Product GiveProduct(int productNumber);

        /// <summary>
        /// Reset information about the purchased products
        /// </summary>
        void ResetState();
    }
}