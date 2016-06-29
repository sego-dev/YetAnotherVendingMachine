namespace YetAnotherVendingMachine
{
    public class VendingMachine : IVendingMachine
    {
        public VendingMachine()
        {
            Amount = new Money();
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
                Euros = Amount.Euros + amount.Cents
            };
        }

        public Money ReturnMoney()
        {
            throw new System.NotImplementedException();
        }

        public Product Buy(int productNumber)
        {
            throw new System.NotImplementedException();
        }
    }
}
