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

        [Test]
        public void ChargingCurrentValue_NoConnection()
        {
            //Act + Arrange
            double current = 0.00;
            _charger.CurrentValueEvent += Raise.EventWith(new CurrentEventArgs() { Current = current });

            //Assert
            _display.Received().ShowMessage("Din telefon er ikke ordentlig tilsluttet. Prøv igen.");
            
        }


        [Test]
        public void ChargingCurrentValue_Charging()
        {
            //Act + Arrange
            double current = 500;
            _charger.Connected.Equals(true);
            _charger.CurrentValueEvent += Raise.EventWith(new CurrentEventArgs() { Current = current });

            //Assert
            _display.Received().ShowMessage("Din telefon oplades.");

        }

        [Test]
        public void ChargingCurrentValue_ChargingError()
        {
            //Act + Arrange
            double current = 600;
            _charger.Connected.Equals(true);
            _charger.CurrentValueEvent += Raise.EventWith(new CurrentEventArgs() { Current = current });

            //Assert
            _display.Received().ShowMessage("Error: Prøv igen.");

        }

        [Test]
        public void ChargingCurrentValue_FullyCharged()
        {
            //Act + Arrange
            double current = 2;
            _charger.Connected.Equals(true);
            _charger.CurrentValueEvent += Raise.EventWith(new CurrentEventArgs() { Current = current });

            //Assert
            _display.Received().ShowMessage("Din telefon er fuldt opladt.");

        }



    }
}