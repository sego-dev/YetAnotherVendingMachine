using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace YetAnotherVendingMachine.Tests
{
    [TestClass]
    public class VendingMachineTest
    {
        [TestMethod]
        [ExpectedException(typeof(WrongCoinsException))]
        public void ShouldThrowExceptionWhenWrongCoins()
        {
            var vendingMachine = new VendingMachine();
            var coin = new Money()
            {
                Cents = 25
            };
            vendingMachine.InsertCoin(coin);
        }
    }
}
