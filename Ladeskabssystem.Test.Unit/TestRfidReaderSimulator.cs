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

        public void Setup()
        {
            _uut = new RfidReaderSimulator();
        }

        [Test]
        public void IsDetected_true()
        {
            _uut.checkId(5);
        }

    
    }
}
