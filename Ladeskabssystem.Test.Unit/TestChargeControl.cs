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
        private IDisplay _display;

        [SetUp]
        public void Setup()
        {
            _charger = Substitute.For<IUsbCharger>();
            _display = Substitute.For<IDisplay>();
            _uut = new ChargeControl(_charger,_display);
        }

        [Test]
        public void IsConnectedTrue()
        {
            _charger.Connected.Returns(true);
            Assert.That(_uut.IsConnected(), Is.EqualTo(true));
        }

        [Test]
        public void IsConnectedFalse()
        {
            _charger.Connected.Returns(false);
            Assert.That(_uut.IsConnected(), Is.EqualTo(false));
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

        // *** Testing BVA for chargingCurrentValue NoConnection *** 

        [TestCase( -1.00)]
        [TestCase(-0.50)]
        [TestCase(0.00)]
        public void ChargingCurrentValue_NoConnection(double TestCurrent)
        {
            //Act + Arrange
            double current = TestCurrent;
            _charger.CurrentValueEvent += Raise.EventWith(new CurrentEventArgs() { Current = current });

            //Assert
            _display.Received().ShowMessage("Din telefon er ikke ordentlig tilsluttet. Prøv igen.");
            
        }


        [TestCase(6)]
        [TestCase(499)]
        [TestCase(500)]
        public void ChargingCurrentValue_Charging(double TestCurrent)
        {
            //Act + Arrange
            double current = TestCurrent;
            _charger.Connected.Equals(true);
            _charger.CurrentValueEvent += Raise.EventWith(new CurrentEventArgs() { Current = current });

            //Assert
            _display.Received().ShowMessage("Din telefon oplades.");

        }

        [TestCase(501)]
        [TestCase(600)]
        [TestCase(1000)]
        public void ChargingCurrentValue_ChargingError(double TestCurrent)
        {
            //Act + Arrange
            double current = TestCurrent;
            _charger.Connected.Equals(true);
            _charger.CurrentValueEvent += Raise.EventWith(new CurrentEventArgs() { Current = current });

            //Assert
            _display.Received().ShowMessage("Error: Prøv igen.");

        }

        [TestCase(0.50)]
        [TestCase(1.00)]
        [TestCase(4.00)]
        [TestCase(5.00)]
        public void ChargingCurrentValue_FullyCharged(double TestCurrent)
        {
            //Act + Arrange
            double current = TestCurrent;
            _charger.Connected.Equals(true);
            _charger.CurrentValueEvent += Raise.EventWith(new CurrentEventArgs() { Current = current });

            //Assert
            _display.Received().ShowMessage("Din telefon er fuldt opladt.");

        }



    }
}