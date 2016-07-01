namespace YetAnotherVendingMachine
{
    internal interface ICoinValidator
    {
        bool IsValid(Money coin);
    }
}