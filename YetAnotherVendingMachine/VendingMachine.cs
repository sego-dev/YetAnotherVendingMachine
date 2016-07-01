using System.Collections.Generic;

namespace YetAnotherVendingMachine
{
    public class VendingMachine : IVendingMachine
    {
        private MoneyProvider _moneyProvider;
        private ProductProvider _productProvider;
        /// <summary>
        /// Contains sold products in current session
        /// </summary>
        private List<int> _purchasedProducts;

        public VendingMachine()
        {
            Amount = new Money();
            Products = new Product[] {};
            _purchasedProducts = new List<int>();
            _moneyProvider = new MoneyProvider(this, new CoinValidator());
            _productProvider = new ProductProvider(this);
        }

        /// <summary> Vending machine manufacturer. </summary>
        public string Manufacturer { get; }
        /// <summary> Amount of money inserted into vending machine.  </summary>
        public Money Amount { get; private set; }
        /// <summary> Products that are sold. </summary>
        public Product[] Products { get; set; }

        /// <summary> Inserts the coin into vending machine. </summary>
        /// <param name="amount">Coin amount.</param>
        public Money InsertCoin(Money amount)
        {
            Amount = _moneyProvider.AddCoin(amount);
            return Amount;
        }

        /// <summary> Returns all inserted coins back to user. </summary>
        public Money ReturnMoney()
        {
            var moneyForReturn = Amount;
            Amount = new Money();
            //Reset when money returned
            _purchasedProducts = new List<int>();
            return moneyForReturn;
        }

        /// <summary>
        /// Buys product from list of product.
        /// </summary>
        /// <param name="productNumber">Product number in vending machine product list.</param>
        public Product Buy(int productNumber)
        {
            var product = _productProvider.SellProduct(productNumber, _purchasedProducts);
            Amount = _moneyProvider.RemoveMoney(product.Price);
            
            return product;
        }
    }
}
