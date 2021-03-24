using Ladeskabsystem;
using Ladeskabsystem.Interfaces;
using NSubstitute;
using NUnit.Framework;

namespace Ladeskabssystem.Test.Unit
{
    [TestFixture]
    public class TestChargeControl
    {
        private ChargeControl uut;
        private IUsbCharger _charger;

        [SetUp]
        public void Setup()
        {
            _charger = Substitute.For<IUsbCharger>();
            uut = new ChargeControl(_charger);
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}