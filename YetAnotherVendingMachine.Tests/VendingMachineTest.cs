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
        public void ShouldConvertToEurosWhenCentsOver100()
        {
            var vendingMachine = new VendingMachine();
            var coin = new Money()
            {
                Cents = 50
            };
            var expectedMoney = new Money() { Cents = 50, Euros = 1 };

            vendingMachine.InsertCoin(coin);
            vendingMachine.InsertCoin(coin);
            var insertedMoney = vendingMachine.InsertCoin(coin);

            Assert.AreEqual(expectedMoney, insertedMoney);
        }

        [TestMethod]
        public void ShouldConvertToEurosWhenCentsEqual100()
        {
            var vendingMachine = new VendingMachine();
            var coin = new Money()
            {
                Cents = 50
            };
            var expectedMoney = new Money() { Euros = 1};

            vendingMachine.InsertCoin(coin);
            var insertedMoney = vendingMachine.InsertCoin(coin);

            Assert.AreEqual(expectedMoney, insertedMoney);
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
        [ExpectedException(typeof(ProductNotFoundException))]
        public void ShouldThrowExceptionWhenProductNumberIsNegotive()
        {
            var vendingMachine = new VendingMachine();
            int negativeProductNumber = -1;
            vendingMachine.Buy(negativeProductNumber);
        }

        [TestMethod]
        [ExpectedException(typeof(ProductValidateException))]
        public void ShouldThrowExceptionWhenProductAvailableLessZero()
        {
            var vendingMachine = new VendingMachine();
            vendingMachine.Products = new[]
            {
                new Product()
                {
                    Available = -1,
                    Price = new Money() {Cents = 10},
                    Name = "Test Product"
                }
            };
        }

        [TestMethod]
        [ExpectedException(typeof (ProductNotAvailableException))]
        public void ShouldThrowExceptionWhenProductNotAvailable()
        {
            var vendingMachine = new VendingMachine();
            vendingMachine.InsertCoin(new Money() {Cents = 20});
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

        [TestMethod]
        public void ShouldDecreaseAvailableWhenBuySuccess()
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
            Assert.AreEqual(0, vendingMachine.Products[0].Available);
        }

        [TestMethod]
        [ExpectedException(typeof (ProductNotMoreOneException))]
        public void ShouldThrowExceptionWhenSecondProductForInsertedCoins()
        {
            var vendingMachine = new VendingMachine();
            vendingMachine.InsertCoin(new Money() {Cents = 20});

            vendingMachine.Products = new[]
            {
                new Product()
                {
                    Available = 2,
                    Price = new Money() {Cents = 10},
                    Name = "Test Product"
                }
            };

            int availableProduct = 0;
            vendingMachine.Buy(availableProduct);
            vendingMachine.Buy(availableProduct);
        }

        [TestMethod]
        public void ShouldNotDecreaseAvailableWhenNotMoney()
        {
            var vendingMachine = new VendingMachine();
            vendingMachine.InsertCoin(new Money() {Cents = 5});
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
            try
            {
                vendingMachine.Buy(availableProduct);
            }
            catch
            {
                // ignored
            }

            Assert.AreEqual(1, vendingMachine.Products[0].Available);
        }
    }
}
