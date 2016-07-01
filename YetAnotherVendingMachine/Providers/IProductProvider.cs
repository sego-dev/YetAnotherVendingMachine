using System.Collections.Generic;

namespace YetAnotherVendingMachine
{
    internal interface IProductProvider
    {
        void DecreaseAvailabledProduct(int productNumber);
        Product GetProduct(int productNumber);
        Product SellProduct(int productNumber, List<int> purchasedProducts);
    }
}