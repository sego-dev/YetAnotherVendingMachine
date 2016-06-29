namespace YetAnotherVendingMachine
{
    public class VendingMachine : IVendingMachine
    {
        public string Manufacturer { get; }
        public Money Amount { get; }
        public Product[] Products { get; set; }

        public Money InsertCoin(Money amount)
        {
            throw new System.NotImplementedException();
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