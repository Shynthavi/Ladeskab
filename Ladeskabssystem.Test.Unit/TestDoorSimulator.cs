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
        private DoorOpenedEventArgs _receivedEvent;

        [SetUp]
        public void Setup()
        {
            _receivedEvent = null;
            _uut = new DoorSimulator();
            _uut.OpenDoor(true);
            _uut.DoorOpenEvent += ((o, args) => { _receivedEvent = args; });
            
        }

        [Test]
        public void DoorNewValueReceived_Test()
        {
            _uut.OpenDoor(false);
            Assert.That(_receivedEvent.OpenDoor, Is.EqualTo(false));
        }

        [Test]
        public void LockDoorOutput_Test()
        {
            _uut.LockDoor();
            Assert.That(_uut.UnlockDoor, Is.EqualTo("Dør er ulåst"));
        }

        [Test]
        public void UnLockDoorOutput_Test()
        {
            _uut.UnlockDoor();
            Assert.That(_uut.UnlockDoor, Is.EqualTo("Dør er ulåst"));
        }
    }
}
