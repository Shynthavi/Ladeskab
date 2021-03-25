using Ladeskabsystem;
using Ladeskabsystem.Interfaces;
using NSubstitute;
using NUnit.Framework;

namespace Ladeskabssystem.Test.Unit
{
    class TestStationControl
    {
        private StationControl _uut;
        private IUsbCharger _charger;
        private IRfidReader _reader;
        private IDoor _door;
        private IChargeControl _chargeControl;
        private IDisplay _display;
        private ILogFile _log;

        [SetUp]
        public void Setup()
        {
            _door = Substitute.For<IDoor>();
            _reader = new RfidReaderSimulator();
            _chargeControl = Substitute.For<IChargeControl>();
            _display = Substitute.For<IDisplay>();
            _log = Substitute.For<ILogFile>();
            _uut = new StationControl(_chargeControl, _door, _display, _reader, _log);
        }

        
        [Test]
        public void RfidDetected_Available_ChargerConnected()
        {
            //Act + Arrange
            _chargeControl.IsConnected().Returns(true);
            int id = 5;
            _reader.SimulateReading(id);

            //Assert
            Assert.Multiple(() =>
            {
                _door.Received().LockDoor();
                _chargeControl.Received().StartCharge();
                _log.Received().LogDoorLocked(id);
                _display.Received().ShowMessage("Skabet er låst og din telefon lades. Brug dit RFID tag til at låse op.");
            });
        }

        [Test]
        public void RfidDetected_Available_ChargerNotConnected()
        {
            //Act + Arrange
            _chargeControl.IsConnected().Returns(false);
            int id = 5;
            _reader.SimulateReading(id);

            //Assert
            Assert.Multiple(() =>
            {
                _door.DidNotReceive().LockDoor();
                _chargeControl.DidNotReceive().StartCharge();
                _log.DidNotReceive().LogDoorLocked(id);
                _display.Received().ShowMessage("Din telefon er ikke ordentlig tilsluttet. Prøv igen.");
            });
        }


        [Test]
        public void RfidDetected_Locked_IdMatch()
        {
            //Act + Arrange
            _chargeControl.IsConnected().Returns(true);
            int id = 5;
            _reader.SimulateReading(id);
            _reader.SimulateReading(id);

            //Assert
            Assert.Multiple(() =>
            {
                _door.Received().UnlockDoor();
                _chargeControl.Received().StopCharge();
                _log.Received().LogDoorUnlocked(id);
                _display.Received().ShowMessage("Tag din telefon ud af skabet og luk døren");
            });
        }


        [Test]
        public void RfidDetected_Locked_IdNoMatch()
        {
            //Act + Arrange
            _chargeControl.IsConnected().Returns(true);
            int id = 5;
            int wrongId = 10;
            _reader.SimulateReading(id);
            _reader.SimulateReading(wrongId);

            //Assert
            Assert.Multiple(() =>
            {
                _door.DidNotReceive().UnlockDoor();
                _chargeControl.DidNotReceive().StopCharge();
                _log.DidNotReceive().LogDoorUnlocked(id);
                _display.Received().ShowMessage("Tag din telefon ud af skabet og luk døren");
            });
        }

    }
}
