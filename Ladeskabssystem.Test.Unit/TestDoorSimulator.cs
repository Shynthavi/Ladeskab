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
        [SetUp]
        public void Setup()
        {
            _uut = new DoorSimulator();
        }

        [Test]
        public void DoorIsOpen_Test()
        {
            //_uut.(true);
            Assert.That(_uut.LockDoor, Is.False);
        }

        [Test]
        public void DoorIsClosed_Test()
        {
            //_uut.UnlockDoor(false);
            Assert.That(_uut.LockDoor, Is.True);
        }
    }
}
