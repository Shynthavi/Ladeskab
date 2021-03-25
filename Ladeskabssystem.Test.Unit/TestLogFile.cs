using System;
using System.Collections.Generic;
using System.Text;
using Ladeskabsystem;
using Ladeskabsystem.Interfaces;
using NSubstitute;
using NUnit.Framework;

namespace Ladeskabssystem.Test.Unit
{
    [TestFixture]
    public class TestLogFile
    {
        private LogFile _uut;
        private ILogFile _ilogfile;

        [SetUp]
        public void Setup()
        {
            _uut = new LogFile();
            
        }

        [Test]
        public void IdSavedInLog_true()
        {
            Assert.That(()=>_uut.LogDoorLocked(7),Is.Not.Null);
        }

        [Test]
        public void IdSavedInLog_false()
        {
            Assert.That(()=>_uut.LogDoorUnlocked(7),Is.Not.Null);
        }

    }
}
