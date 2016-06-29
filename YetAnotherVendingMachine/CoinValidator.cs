namespace YetAnotherVendingMachine
{
    public class CoinValidator
    {
        /// <summary>
        /// Validate inserted coin
        /// <remarks>
        /// accepts following coins: 5ȼ, 10ȼ, 20ȼ, 50ȼ, 1 € and 2 €
        /// </remarks>
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        public static bool IsValid(Money amount)
        {
            return (amount.Cents == 5 && amount.Euros == 0)
                   || (amount.Cents == 10 && amount.Euros == 0)
                   || (amount.Cents == 20 && amount.Euros == 0)
                   || (amount.Cents == 50 && amount.Euros == 0)
                   || (amount.Cents == 0 && amount.Euros == 1)
                   || (amount.Cents == 0 && amount.Euros == 2);
        }
    }
}
