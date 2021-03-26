using System.Runtime.CompilerServices;
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
        private DoorStatusEventArgs _receivedEventArgsOpened;
        private DoorStatusEventArgs _receivedEventArgsClosed;

        [SetUp]
        public void Setup()
        {
            _receivedEventArgsOpened = null;
            _receivedEventArgsClosed = null;

            _uut = new DoorSimulator();
            _uut.DoorOpenEvent += ((o, args) => { _receivedEventArgsOpened = args; });
            _uut.DoorCloseEvent += ((o, args) => { _receivedEventArgsClosed = args; });
        }



        [Test]
        public void LockDoor_ChangesState_EventFired()
        {
            _uut.UnlockDoor();
            _uut.LockDoor();
            Assert.That(_receivedEventArgsClosed, Is.Not.Null);
        }

        [Test]
        public void UnlockDoor_ChangesState_EventFired()
        {
            _uut.UnlockDoor();
            Assert.That(_receivedEventArgsOpened, Is.Not.Null);
        }

    }
}
