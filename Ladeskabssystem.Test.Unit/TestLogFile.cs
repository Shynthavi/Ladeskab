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
using NSubstitute.ReceivedExtensions;


namespace Ladeskabssystem.Test.Unit
{
     

    [TestFixture]
    public class TestLogFile
    {
        private LogFile _uut;

        [SetUp]
        public void Setup()
        {
            _uut = new LogFile();
        }

        [Test]
        public void LogDoorLock()
        {
            int id = 5;
            string path = Directory.GetCurrentDirectory();
            int LogLength = File.ReadAllText(path+@"\logfile.txt").Length;
            
            _uut.LogDoorLocked(5);

            int newLogLength = File.ReadAllText(path + @"\logfile.txt").Length;
            Assert.That(newLogLength, Is.GreaterThan(LogLength));

        }

        [Test]
        public void LogDoorUnlock()
        {
            int id = 14;
            string path = Directory.GetCurrentDirectory();
            
            int LogLength = File.ReadAllText(path+@"\logfile.txt").Length;

            _uut.LogDoorUnlocked(id);

            int newLogLength = File.ReadAllText(path + @"\logfile.txt").Length;
            Assert.That(newLogLength, Is.GreaterThan(LogLength));
        }

    }
}
