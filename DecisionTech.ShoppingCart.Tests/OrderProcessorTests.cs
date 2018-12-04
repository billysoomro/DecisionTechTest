using DecisionTech.ShoppingCart.Domain;
using DecisionTech.ShoppingCart.Interfaces;
using Moq;
using NUnit.Framework;

namespace DecisionTech.ShoppingCart.Tests
{
    [TestFixture]
    public class OrderProcessorTests
    {
        private decimal _breadPrice;
        private decimal _butterPrice;
        private decimal _milkPrice;

        [SetUp]
        public void SetUp()
        {
            _breadPrice = 1.00M;
            _butterPrice = 0.80M;
            _milkPrice = 1.15M;
        }

        [TestCase("bread butter milk", 2.95)] 
        public void ShouldPassGivenTheFollowingUsingMocks(string orders, decimal expectedTotal)
        {
            var breadMock = new Mock<IBread>();
            breadMock.Setup(x => x.AddBread(orders, 0)).Returns(_breadPrice);
            breadMock.Setup(x => x.Count).Returns(1);

            var butterMock = new Mock<IButter>();
            butterMock.Setup(x => x.AddButter(orders, _breadPrice)).Returns(_breadPrice + _butterPrice);
            butterMock.Setup(x => x.Count).Returns(1);

            var milkMock = new Mock<IMilk>();
            milkMock.Setup(x => x.AddMilk(orders, _breadPrice + _butterPrice)).Returns(_breadPrice + _butterPrice + _milkPrice);
            milkMock.Setup(x => x.Count).Returns(1);

            var orderProcessor = new OrderProcessor(breadMock.Object, butterMock.Object, milkMock.Object);

            orderProcessor.ProcessOrders(orders);
            var actualTotal = orderProcessor.Total;

            Assert.AreEqual(actualTotal, expectedTotal);
        }

        [TestCase("bread butter milk", 2.95)]
        [TestCase("butter butter bread bread", 3.10)]
        [TestCase("milk milk milk milk", 3.45)]
        [TestCase("butter butter bread milk milk milk milk milk milk milk milk", 9.00)]
        public void ShouldPassGivenTheFollowingUsingConcreteImplementations(string orders, decimal expectedTotal)
        {
            var classUnderTest = new OrderProcessor(new Bread(), new Butter(), new Milk());
            classUnderTest.ProcessOrders(orders);
            var actualTotal = classUnderTest.Total;

            Assert.AreEqual(actualTotal, expectedTotal);
        }
    }
}
