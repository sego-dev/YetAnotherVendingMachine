using System.Collections.Generic;
using System.Linq;

namespace YetAnotherVendingMachine
{
    public class VendingMachine : IVendingMachine
    {
        private IMoneyProvider _moneyProvider;
        private IProductProvider _productProvider;
        private IProductValidator _productValidator;
        private Product[] _products;
        

        public VendingMachine() : this("ACME")
        {
        }

        public VendingMachine(string manufacturer) 
        {
            Manufacturer = manufacturer;
            Amount = new Money();
            //should be initialized before set products
            _productValidator = new ProductValidator();
            Products = new Product[] { };
            _moneyProvider = new MoneyProvider(this, new CoinValidator());
            _productProvider = new ProductProvider(this);
        }

        public IMoneyProvider MoneyProvider
        {
            get { return _moneyProvider; }
            set { _moneyProvider = value; }
        }

        public IProductProvider ProductProvider
        {
            get { return _productProvider; }
            set { _productProvider = value; }
        }

        /// <summary> Vending machine manufacturer. </summary>
        public string Manufacturer { get; }
        /// <summary> Amount of money inserted into vending machine.  </summary>
        public Money Amount { get; private set; }
        /// <summary> Products that are sold. </summary>
        public Product[] Products {
            get { return _products; }
            set
            {
                _productValidator.Validate(value);
                _products = value;
            }
        }

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
            _productProvider.ResetState();
            return moneyForReturn;
        }

        /// <summary>
        /// Buys product from list of product.
        /// </summary>
        /// <param name="productNumber">Product number in vending machine product list.</param>
        public Product Buy(int productNumber)
        {
            var product = _productProvider.GetProduct(productNumber);
            if (!_moneyProvider.HaveEnoughMoney(product.Price))
            {
                throw new InsufficientFundsException();
            }
            product = _productProvider.GiveProduct(productNumber);
            Amount = _moneyProvider.RemoveMoney(product.Price);
            
            return product;
        }
    }
}
