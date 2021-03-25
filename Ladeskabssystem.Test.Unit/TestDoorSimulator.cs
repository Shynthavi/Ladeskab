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
        private DoorStatusEventArgs _receivedEvent;

        [SetUp]
        public void Setup()
        {
            _uut = new DoorSimulator();
            _uut.OpenLockedDoor(true);
            _uut.DoorStatusEvent += ((o, args) => { _receivedEvent = args; });
        }

        [Test]
        public void LockDoorOutput_Test()
        {
            _uut.OpenLockedDoor(false);
            Assert.That(_uut.LockDoor, Is.EqualTo("Dør er låst"));
        }

        [Test]
        public void UnLockDoorOutput_Test()
        {
            _uut.OpenLockedDoor(false);
            Assert.That(_uut.UnlockDoor, Is.EqualTo("Dør er ulåst"));
        }

        [Test]
        public void DoorIsUnlocked_Test()
        {
            _uut.OpenLockedDoor(true);
            Assert.That(_uut.UnlockDoor, Is.True);
        }

        [Test]
        public void DoorIsLocked_Test()
        {
            _uut.OpenLockedDoor(true);
            Assert.That(_uut.LockDoor, Is.True);
        }

    }
}
