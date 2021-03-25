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
        private string Logfile = "Logfile.txt";
        private RfidReaderSimulator _rfidReader;
        private IDoor _iDoor;
        private IChargeControl _chargeControl;
        private IDisplay _iDisplay;
        private StationControl _stationControl;

        [SetUp]
        public void Setup()
        {
            _uut = new LogFile();
            _rfidReader = new RfidReaderSimulator();
            _iDoor = Substitute.For<IDoor>();
            _chargeControl = Substitute.For<IChargeControl>();
            _iDisplay = Substitute.For<IDisplay>();
            _stationControl = new StationControl(_chargeControl, _iDoor, _iDisplay, _rfidReader);
        }

        [Test]
        public void LogDoorLock()
        {
            int LogLength = File.ReadAllText(@"C:\Users\Lucas\Desktop\Aarhus_Universitet\IKT\4. Semester\SWT\Github\Ladeskab\Ladeskabssystem.Test.Unit\bin\Debug\netcoreapp3.1\logfile.txt").Length;
            int Id = 14;

            _chargeControl.IsConnected().Returns(true);
            _rfidReader.SimulateReading(Id);
            
            int newLogLength = File.ReadAllText(@"C:\Users\Lucas\Desktop\Aarhus_Universitet\IKT\4. Semester\SWT\Github\Ladeskab\Ladeskabssystem.Test.Unit\bin\Debug\netcoreapp3.1\logfile.txt").Length;
            Assert.That(newLogLength,Is.GreaterThan(LogLength));

        }


        [Test]
        public void LogDoorUnlock()
        {
            int Id = 14;

            _chargeControl.IsConnected().Returns(true);
            int LogLength = File.ReadAllText(@"C:\Users\Lucas\Desktop\Aarhus_Universitet\IKT\4. Semester\SWT\Github\Ladeskab\Ladeskabssystem.Test.Unit\bin\Debug\netcoreapp3.1\logfile.txt").Length;
            _rfidReader.SimulateReading(Id);

            int newLogLength = File.ReadAllText(@"C:\Users\Lucas\Desktop\Aarhus_Universitet\IKT\4. Semester\SWT\Github\Ladeskab\Ladeskabssystem.Test.Unit\bin\Debug\netcoreapp3.1\logfile.txt").Length;
            Assert.That(newLogLength, Is.GreaterThan(LogLength));

        }

    }
}
