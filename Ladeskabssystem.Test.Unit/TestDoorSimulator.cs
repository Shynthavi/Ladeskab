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
        private DoorOpenedEventArgs _receivedEventArgs;
        public int numberOfEvents { get; set; }

        [SetUp]
        public void Setup()
        {
            _receivedEventArgs = null;
            _uut = new DoorSimulator();
            _uut.OpenDoor(true);
            _uut.DoorOpenEvent += ((o, args) => { _receivedEventArgs = args; });
            numberOfEvents = 0;
        }

        private void Door_DoorOpenEvent(object sender, DoorOpenedEventArgs e)
        {
            numberOfEvents++;
        }
        private void Door_DoorCloseEvent(object sender, DoorClosedEventArgs e)
        {
            numberOfEvents++;
        }



        [Test]
        public void DoorNewValueReceived__EventFired()
        {
            _uut.OpenDoor(false);
            Assert.That(_receivedEventArgs.OpenDoor, Is.Not.Null);
        }

        [Test]
        public void DoorSetToNewValue_CorrectValueReceived()
        {
            _uut.OpenDoor(false);
            Assert.That(_receivedEventArgs.OpenDoor, Is.EqualTo(false));
        }



    }
}
