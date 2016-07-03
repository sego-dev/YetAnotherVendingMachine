namespace YetAnotherVendingMachine
{
    public interface ICoinValidator
    {
        bool IsValid(Money coin);
    }
}