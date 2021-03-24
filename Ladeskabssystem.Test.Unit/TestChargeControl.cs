using Ladeskabsystem;
using Ladeskabsystem.Interfaces;
using NSubstitute;
using NUnit.Framework;

namespace Ladeskabssystem.Test.Unit
{
    [TestFixture]
    public class TestChargeControl
    {
        private ChargeControl _uut;
        private IUsbCharger _charger;

        [SetUp]
        public void Setup()
        {
            _charger = Substitute.For<IUsbCharger>();
            _uut = new ChargeControl(_charger);
        }

        [Test]
        public void IsConnectedTrue()
        {
            _charger.Connected.Returns(true);
            Assert.That(_uut.IsConnected(), Is.EqualTo(false));
        }

        [Test]
        public void IsConnectedFalse()
        {
            _charger.Connected.Returns(false);
            Assert.That(_uut.IsConnected(), Is.EqualTo(true));
        }

        [Test]
        public void StartChargeTest()
        {
            _uut.StartCharge();
            _charger.Received().StartCharge();
        }

        [Test]
        public void StopChargeTest()
        {
            _uut.StopCharge();
            _charger.Received().StopCharge();
        }
    }
}