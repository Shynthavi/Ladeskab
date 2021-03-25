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
            _reader = Substitute.For<IRfidReader>();
            _chargeControl = Substitute.For<IChargeControl>();
            _display = Substitute.For<IDisplay>();
            _log = Substitute.For<ILogFile>();
            _uut = new StationControl(_chargeControl, _door, _display, _reader, _log);
        }

        //***************************************************************************
        //Method under test: RfidDetected()
        //State: Available
        [Test]
        public void RfidDetected_Available_ChargerConnected()
        {
            //Act + Arrange
            _chargeControl.IsConnected().Returns(true);
            const int id = 5;
            _reader.RfidEvent += Raise.EventWith(new RfidEventArgs() {Id = id});

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
            const int id = 5;
            _reader.RfidEvent += Raise.EventWith(new RfidEventArgs() { Id = id });

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
            const int id = 5;
            _reader.RfidEvent += Raise.EventWith(new RfidEventArgs() { Id = id });
            _reader.RfidEvent += Raise.EventWith(new RfidEventArgs() { Id = id });

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
            const int id = 5;
            const int wrongId = 10;
            _reader.RfidEvent += Raise.EventWith(new RfidEventArgs() { Id = id });
            _reader.RfidEvent += Raise.EventWith(new RfidEventArgs() { Id = wrongId });

            //Assert
            Assert.Multiple(() =>
            {
                _door.DidNotReceive().UnlockDoor();
                _chargeControl.DidNotReceive().StopCharge();
                _log.DidNotReceive().LogDoorUnlocked(id);
                _display.Received().ShowMessage("Forkert RFID tag");
            });
        }


        //***************************************************************************
        //Method under test: RfidDetected()
        //State: DoorOpen
        [Test]
        public void RfidDetected_DoorOpen()
        {
            //Act + Arrange
            //Changing state: Available --> DoorOpen
            const bool openDoor = true;
            _door.DoorOpenEvent += Raise.EventWith(new DoorOpenedEventArgs() { OpenDoor = openDoor });
            _chargeControl.IsConnected().Returns(false);
            const int id = 5;
            _reader.RfidEvent += Raise.EventWith(new RfidEventArgs() { Id = id });

            //Assert
            Assert.Multiple(() =>
            {
                _door.DidNotReceive().LockDoor();
                _chargeControl.DidNotReceive().StartCharge();
                _log.DidNotReceive().LogDoorLocked(id);
                _display.DidNotReceive().ShowMessage("Skabet er låst og din telefon lades. Brug dit RFID tag til at låse op.");
            });
        }


        //***************************************************************************
        //Method under test: DoorOpen()
        //State: Available
        [Test]
        public void DoorOpened_Available_OpenDoor()
        {
            //Act + Arrange
            const bool openDoor= true;
            _door.DoorOpenEvent += Raise.EventWith(new DoorOpenedEventArgs() { OpenDoor = openDoor });

            //Assert
            _display.Received().ShowMessage("Tilslut telefon");
        }

        [Test]
        public void DoorOpened_Available_NoOpenDoor()
        {
            //Act + Arrange
            const bool openDoor = false;
            _door.DoorOpenEvent += Raise.EventWith(new DoorOpenedEventArgs() { OpenDoor = openDoor });

            //Assert
            _display.DidNotReceive().ShowMessage("Tilslut telefon");
        }


        //***************************************************************************
        //Method under test: DoorClosed()
        //State: DoorOpen
        [Test]
        public void DoorClosed_DoorOpen_NoCloseDoor()
        {
            //Act + Arrange
            const bool openDoor = true;
            //Changing state: Available --> DoorOpen
            _door.DoorOpenEvent += Raise.EventWith(new DoorOpenedEventArgs() { OpenDoor = openDoor });

            const bool closeDoor = false;
            _door.DoorCloseEvent += Raise.EventWith(new DoorClosedEventArgs() { CloseDoor = closeDoor });

            //Assert
            _display.Received().ShowMessage("Indlæs RFID");
        }

        [Test]
        public void DoorClosed_DoorOpen_CloseDoor()
        {
            //Act + Arrange
            const bool openDoor = true;
            //Changing state: Available --> DoorOpen
            _door.DoorOpenEvent += Raise.EventWith(new DoorOpenedEventArgs() { OpenDoor = openDoor });

            const bool closeDoor = true;
            _door.DoorCloseEvent += Raise.EventWith(new DoorClosedEventArgs() { CloseDoor = closeDoor });

            //Assert
            _display.DidNotReceive().ShowMessage("Indlæs RFID");
        }


        //***************************************************************************
        //Method under test: DoorClosed()
        //State: Available
        [Test]
        public void DoorClosed_Available_CloseDoor()
        {
            //Act + Arrange
            const bool closeDoor = true;
            _door.DoorCloseEvent += Raise.EventWith(new DoorClosedEventArgs() { CloseDoor = closeDoor });

            //Assert
            _display.DidNotReceive().ShowMessage("Indlæs RFID");
        }
    }
}
