using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GWhub.Tests
{
    [TestClass()]
    public class CurrencyVertexTests
    {
        [TestMethod()]
        public void ToStringTest()
        {
            // arrange
            CurrencyVertex curr = new CurrencyVertex("PLN");
            // act
            string symbol = curr.ToString();
            // assert
            Assert.AreEqual(curr.Symbol, symbol);
        }

        [TestMethod()]
        public void DefaultValuesTest()
        {
            // arrange
            CurrencyVertex curr = new CurrencyVertex("PLN");
            // assert
            Assert.AreEqual(curr.MoneyAt, 0);
            Assert.AreEqual(curr.ArbMoneyAt, 0);
            Assert.AreEqual(curr.MinDistance, int.MaxValue);
            Assert.AreEqual(curr.ArbitrageMinDistance, int.MaxValue);
        }
    }
}