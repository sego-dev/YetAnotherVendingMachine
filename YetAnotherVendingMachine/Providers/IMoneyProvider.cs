namespace YetAnotherVendingMachine
{
    internal interface IMoneyProvider
    {
        Money AddCoin(Money coin);
        bool HaveEnoughMoney(Money amount);
        Money RemoveMoney(Money amount);
    }
}