﻿using Microsoft.VisualStudio.TestTools.UnitTesting;

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
    }
}
