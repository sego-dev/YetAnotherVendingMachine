using System;
using System.Linq;
using System.Xml.Linq;

namespace YetAnotherVendingMachine
{
    public class VendingMachine : IVendingMachine
    {
        public VendingMachine()
        {
            Amount = new Money();
            Products = new Product[] {};
        }
        public string Manufacturer { get; }
        public Money Amount { get; private set; }
        public Product[] Products { get; set; }

        /// <summary> Inserts the coin into vending machine. </summary>
        /// <param name="amount">Coin amount.</param>
        /// <returns>Amount of inserted money</returns>
        public Money InsertCoin(Money amount)
        {
            if (!CoinValidator.IsValid(amount))
            {
                throw new WrongCoinsException();
            }
            AddMoney(amount);
            return Amount;
        }

        /// <summary>
        /// add instance money
        /// </summary>
        /// <param name="amount"></param>
        private void AddMoney(Money amount)
        {
            Amount = new Money()
            {
                Cents = Amount.Cents + amount.Cents,
                Euros = Amount.Euros + amount.Euros
            };
        }

        /// <summary>
        /// remove instance money
        /// </summary>
        /// <param name="amount"></param>
        private void RemoveMoney(Money amount)
        {
            if (!HaveEnoughMoney(amount))
            {
                throw new InsufficientFundsException();
            }
            Amount = new Money()
            {
                Cents = Amount.Cents - amount.Cents,
                Euros = Amount.Euros - amount.Euros
            };
        }

        private bool HaveEnoughMoney(Money amount)
        {
            return Amount.Euros >= amount.Euros && Amount.Cents >= amount.Cents;
        }

        public Money ReturnMoney()
        {
            var moneyForReturn = Amount;
            Amount = new Money();
            return moneyForReturn;
        }

        public Product Buy(int productNumber)
        {
            var product = FindProduct(productNumber);
            RemoveMoney(product.Price);
            DecreaseAvailableOfProduct(productNumber);
            return product;
        }

        private Product FindProduct(int productNumber)
        {
            Product product;
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
