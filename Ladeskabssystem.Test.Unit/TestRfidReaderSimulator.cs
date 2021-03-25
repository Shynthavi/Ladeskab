using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Ladeskabsystem;
using Ladeskabsystem.Interfaces;
using NSubstitute;
using NSubstitute.ReceivedExtensions;
using NUnit.Framework.Constraints;

namespace Ladeskabssystem.Test.Unit
{
    [TestFixture]
    public class TestRfidReaderSimulator
    {
        private RfidReaderSimulator _uut;

        private RfidEventArgs _RfidEventArgs;

        public void Setup()
        {
            _uut = new RfidReaderSimulator();
            _uut.RfidEvent +=
                (o, args) =>
                {
                    _RfidEventArgs = args;
                };
        }

        [Test]
        public void IsDetected_true(int Id)
        {
            _uut.checkId(5);
            Assert.That(_RfidEventArgs,Is.Not.Null);

           
        }

    
    }
}
