using System.Linq;

namespace YetAnotherVendingMachine
{
    /// <summary>
    /// Validate inserted coin
    /// <remarks>
    /// accepts following coins: 5ȼ, 10ȼ, 20ȼ, 50ȼ, 1 € and 2 €
    /// </remarks>
    /// </summary>
    internal class CoinValidator : ICoinValidator
    {
        private readonly Money[] _availableCoins = {
            new Money() {Cents = 5},
            new Money() {Cents = 10},
            new Money() {Cents = 20},
            new Money() {Cents = 50},
            new Money() {Euros = 1},
            new Money() {Euros = 2},
        };
        
        public bool IsValid(Money amount)
        {
            return _availableCoins.Any(x => x.Equals(amount));
        }
    }
}