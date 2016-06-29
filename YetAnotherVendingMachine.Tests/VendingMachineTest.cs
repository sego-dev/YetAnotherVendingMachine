using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace YetAnotherVendingMachine.Tests
{
    [TestClass]
    public class VendingMachineTest
    {
        [TestMethod]
        [ExpectedException(typeof (WrongCoinsException))]
        public void ShouldThrowExceptionWhenWrongCoins()
        {
            var vendingMachine = new VendingMachine();
            var coin = new Money()
            {
                Cents = 25
            };
            vendingMachine.InsertCoin(coin);
        }

        [TestMethod]
        public void ShouldAddToMoneyWhenInsertCoin()
        {
            var vendingMachine = new VendingMachine();
            var coin = new Money()
            {
                Cents = 20
            };
            var insertedMoney = vendingMachine.InsertCoin(coin);
            Assert.AreEqual(20, insertedMoney.Cents);
        }

        [TestMethod]
        public void ShouldAddToMoneyWhenInsertCoinTwice()
        {
            var vendingMachine = new VendingMachine();
            var coin = new Money()
            {
                Cents = 20
            };
            vendingMachine.InsertCoin(coin);
            var insertedMoney = vendingMachine.InsertCoin(coin);
            Assert.AreEqual(40, insertedMoney.Cents);
        }

        [TestMethod]
        public void ShouldResetMoneyWhenReturn()
        {
            var vendingMachine = new VendingMachine();
            var coin = new Money()
            {
                Cents = 20
            };
            vendingMachine.InsertCoin(coin);
            vendingMachine.ReturnMoney();
            Assert.AreEqual(0, vendingMachine.Amount.Cents);
        }

        [TestMethod]
        public void ShouldReturnExistingMoneyWhenReturn()
        {
            var vendingMachine = new VendingMachine();
            var coin = new Money()
            {
                Cents = 20
            };
            vendingMachine.InsertCoin(coin);
            var moneyForReturn = vendingMachine.ReturnMoney();
            Assert.AreEqual(20, moneyForReturn.Cents);
        }

        [TestMethod]
        [ExpectedException(typeof (ProductNotFoundException))]
        public void ShouldThrowExceptionWhenProductNotFound()
        {
            var vendingMachine = new VendingMachine();
            int notExistingProduct = 1;
            vendingMachine.Buy(notExistingProduct);
        }

        [TestMethod]
        [ExpectedException(typeof (ProductNotAvailableException))]
        public void ShouldThrowExceptionWhenProductNotAvailable()
        {
            var vendingMachine = new VendingMachine();
            vendingMachine.Products = new[]
            {
                new Product()
                {
                    Available = 0,
                    Price = new Money() {Cents = 10},
                    Name = "Test Product"
                }
            };

            int notAvailableProduct = 0;
            vendingMachine.Buy(notAvailableProduct);
        }

        [TestMethod]
        [ExpectedException(typeof (InsufficientFundsException))]
        public void ShouldThrowExceptionWhenInsufficientFunds()
        {
            var vendingMachine = new VendingMachine();
            vendingMachine.Products = new[]
            {
                new Product()
                {
                    Available = 1,
                    Price = new Money() {Cents = 10},
                    Name = "Test Product"
                }
            };

            int availableProduct = 0;
            vendingMachine.Buy(availableProduct);
        }

        [TestMethod]
        public void ShouldRemoveMoneyWhenBuySuccess()
        {
            var vendingMachine = new VendingMachine();
            vendingMachine.InsertCoin(new Money() {Cents = 20});
            vendingMachine.Products = new[]
            {
                new Product()
                {
                    Available = 1,
                    Price = new Money() {Cents = 10},
                    Name = "Test Product"
                }
            };

            int availableProduct = 0;
            vendingMachine.Buy(availableProduct);
            Assert.AreEqual(10, vendingMachine.Amount.Cents);
        }
    }
}
