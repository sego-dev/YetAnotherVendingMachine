using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace YetAnotherVendingMachine
{
    public class VendingMachine : IVendingMachine
    {
        private MoneyProvider _moneyProvider;
        public VendingMachine()
        {
            Amount = new Money();
            Products = new Product[] {};
            _purchasedProducts = new List<int>();
            _moneyProvider = new MoneyProvider(this, new CoinValidator());
        }
        public string Manufacturer { get; }
        public Money Amount { get; private set; }
        public Product[] Products { get; set; }

        private List<int> _purchasedProducts;

        /// <summary> Inserts the coin into vending machine. </summary>
        /// <param name="amount">Coin amount.</param>
        /// <returns>Amount of inserted money</returns>
        public Money InsertCoin(Money amount)
        {
            Amount = _moneyProvider.AddCoin(amount);
            return Amount;
        }

        public Money ReturnMoney()
        {
            var moneyForReturn = Amount;
            Amount = new Money();
            //Reset when money returned
            _purchasedProducts = new List<int>();
            return moneyForReturn;
        }

        public Product Buy(int productNumber)
        {
            var product = FindProduct(productNumber);
            Amount = _moneyProvider.RemoveMoney(product.Price);
            DecreaseAvailableOfProduct(productNumber);
            _purchasedProducts.Add(productNumber);
            return product;
        }

        private Product FindProduct(int productNumber)
        {
            Product product;
            if (_purchasedProducts.Contains(productNumber))
            {
                throw new ProductNotMoreOneException();
            }
            try
            {
                product = Products[productNumber];
            }
            catch (IndexOutOfRangeException)
            {
                throw new ProductNotFoundException();
            }
            if (product.Available == 0)
            {
                throw new ProductNotAvailableException();
            }
            return product;
        }

        private void DecreaseAvailableOfProduct(int productNumber)
        {
            Products[productNumber] = new Product()
            {
                Available = Products[productNumber].Available - 1,
                Price = Products[productNumber].Price,
                Name = Products[productNumber].Name
            };
        }
    }
}
