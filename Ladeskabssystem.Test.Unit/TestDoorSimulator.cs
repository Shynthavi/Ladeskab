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
            Assert.That(_uut.OpenDoor, Is.True);
        }

        [Test]
        public void DoorIsClosed_Test()
        {
            Assert.That(_uut.OpenDoor, Is.False);
        }
    }
}
