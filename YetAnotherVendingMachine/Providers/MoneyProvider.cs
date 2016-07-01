namespace YetAnotherVendingMachine
{
    internal class MoneyProvider : IMoneyProvider
    {
        private readonly ICoinValidator _coinValidator;
        private readonly IVendingMachine _vendingMachine;

        public MoneyProvider(IVendingMachine vendingMachine)
        {
            _vendingMachine = vendingMachine;
            _coinValidator = new CoinValidator();
        }

        public MoneyProvider(IVendingMachine vendingMachine, ICoinValidator coinValidator)
        {
            _vendingMachine = vendingMachine;
            _coinValidator = coinValidator;
        }

        /// <summary>
        /// Add money with vending machine status
        /// </summary>
        /// <param name="coin">inserted coin</param>
        /// <exception cref="WrongCoinsException"></exception>
        /// <returns>amount after insert</returns>
        public Money AddCoin(Money coin)
        {
            if (!_coinValidator.IsValid(coin))
            {
                throw new WrongCoinsException();
            }
            return new Money()
            {
                Cents = _vendingMachine.Amount.Cents + coin.Cents,
                Euros = _vendingMachine.Amount.Euros + coin.Euros
            };
        }

        /// <summary>
        /// Check for money status
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        public bool HaveEnoughMoney(Money amount)
        {
            return _vendingMachine.Amount.Euros >= amount.Euros && _vendingMachine.Amount.Cents >= amount.Cents;
        }

        /// <summary>
        /// Remove money from current account
        /// </summary>
        /// <param name="amount"></param>
        /// <returns>new money state</returns>
        public Money RemoveMoney(Money amount)
        {
            if (!HaveEnoughMoney(amount))
            {
                throw new InsufficientFundsException();
            }
            return new Money()
            {
                Cents = _vendingMachine.Amount.Cents - amount.Cents,
                Euros = _vendingMachine.Amount.Euros - amount.Euros
            };
        }
    }
}
