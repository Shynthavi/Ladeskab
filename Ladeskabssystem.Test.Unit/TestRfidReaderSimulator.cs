using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Ladeskabsystem;
using Ladeskabsystem.Interfaces;
using NUnit.Framework.Constraints;

namespace Ladeskabssystem.Test.Unit
{
    [TestFixture]
    public class TestRfidReaderSimulator
    {
        private RfidReaderSimulator _uut;
        private RfidEventArgs _receivedEventArgs;

        public void Setup()
        {
            _uut = new RfidReaderSimulator();
        }

        [Test]
        public void IsDetected_true()
        {
            _uut.Id = 2;
            Assert.That(_receivedEventArgs.isDetected, Is.True);
        }

        [Test]
        public void IsDetected_false()
        {
            _uut.Id = -10;
            Assert.That(_receivedEventArgs.isDetected, Is.False);
        }

        [Test]
        public void IdIsReceived() { }
    }
}
