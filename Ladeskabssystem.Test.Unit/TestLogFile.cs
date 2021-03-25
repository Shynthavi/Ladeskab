using Ladeskabsystem;
using Ladeskabsystem.Interfaces;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace Ladeskabssystem.Test.Unit
{
    [TestFixture]
    public class TestLogFile
    {
        private LogFile _uut;
        private string Logfile = "Logfile.txt";

        [SetUp]
        public void Setup()
        {
            _uut = new LogFile();
            
        }

        [Test]
        public void LogDoorIsLocked(int id)
        {
            _uut.LogDoorLocked(id);
            string [] loadfile = File.ReadAllLines(Logfile + "Logfile.txt");
            Assert.That(loadfile[loadfile.Length - 1], Is.EqualTo("Door locked " + id));

        }

        [Test]
        public void LogDoorIsUnlocked(int id)
        {
            _uut.LogDoorUnlocked(id);
        }
    }
}
