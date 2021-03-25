using Ladeskabsystem;
using Ladeskabsystem.Interfaces;
using NSubstitute;
using NUnit.Framework;

namespace Ladeskabsystem.Test.Unit
{
    [TestFixture]
    public class TestDoorSimulator
    {
        private DoorSimulator _uut;
        private DoorOpenedEventArgs _receivedEventArgsOpened;
        private DoorClosedEventArgs _receivedEventArgsClosed;
        private string testString;

        [SetUp]
        public void Setup()
        {
            _receivedEventArgsOpened = null;
            _receivedEventArgsClosed = null;

            _uut = new DoorSimulator();
            _uut.OpenDoor(true);
            _uut.DoorOpenEvent += ((o, args) => { _receivedEventArgsOpened = args; });

            _uut.ClosedDoor(true);
            _uut.DoorCloseEvent += ((o, args) => { _receivedEventArgsClosed = args; });
        }



        [Test]
        public void DoorOpenNewValueReceived__EventFired()
        {
            _uut.OpenDoor(false);
            Assert.That(_receivedEventArgsOpened.OpenDoor, Is.Not.Null);
        }

        [Test]
        public void DoorOpenSetToNewValue_CorrectValueReceived()
        {
            _uut.OpenDoor(false);
            Assert.That(_receivedEventArgsOpened.OpenDoor, Is.EqualTo(false));
        }

        [Test]
        public void DoorCloseNewValueReceived__EventFired()
        {
            _uut.ClosedDoor(false);
            Assert.That(_receivedEventArgsClosed.CloseDoor, Is.Not.Null);
        }

        [Test]
        public void DoorClosedSetToNewValue_CorrectValueReceived()
        {
            _uut.ClosedDoor(false);
            Assert.That(_receivedEventArgsClosed.CloseDoor, Is.EqualTo(false));
        }

        [Test]
        public void LockDoorOutput()
        {
            testString = "Dør er låst";
            _uut.LockDoor();

            Assert.That(_uut.DoorSimulatorString, Is.EqualTo(testString));

        }

        [Test]
        public void UnlockDoorOutput()
        {
            testString = "Dør er ulåst";
            _uut.UnlockDoor();

            Assert.That(_uut.DoorSimulatorString, Is.EqualTo(testString));

        }


    }
}
