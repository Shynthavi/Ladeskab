using NUnit.Framework;

namespace Ladeskabsystem.Test.Unit
{
    public class Tests
    {
        //private LogFile _uut;
        ////private string Logfile = "Logfile.txt";
        //private RfidReaderSimulator _rfidReader;
        //private IDoor _iDoor;
        //private IChargeControl _chargeControl;
        //private IDisplay _iDisplay;
        //private StationControl _stationControl;

        //[SetUp]
        //public void Setup()
        //{
        //    _uut = new LogFile();
        //    _rfidReader = new RfidReaderSimulator();
        //    _iDoor = Substitute.For<IDoor>();
        //    _chargeControl = Substitute.For<IChargeControl>();
        //    _iDisplay = Substitute.For<IDisplay>();
        //    _stationControl = new StationControl(_chargeControl, _iDoor, _iDisplay, _rfidReader, _uut);
        //}

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        //[Test]
        //public void LogDoorLock()
        //{
        //    int Id = 14;
        //    _rfidReader.SimulateReading(Id);
        //    string path = Directory.GetCurrentDirectory();
        //    int LogLength = File.ReadAllText(path + @"\logfile.txt").Length;


        //    _chargeControl.IsConnected().Returns(true);
        //    _rfidReader.SimulateReading(Id);

        //    int newLogLength = File.ReadAllText(path + @"\logfile.txt").Length;
        //    Assert.That(newLogLength, Is.GreaterThan(LogLength));

        //}


        //[Test]
        //public void LogDoorUnlock()
        //{
        //    int Id = 14;
        //    _rfidReader.SimulateReading(Id);
        //    string path = Directory.GetCurrentDirectory();


        //    _chargeControl.IsConnected().Returns(true);

        //    _rfidReader.SimulateReading(Id);
        //    int LogLength = File.ReadAllText(path + @"\logfile.txt").Length;
        //    _rfidReader.SimulateReading(Id);
        //    int newLogLength = File.ReadAllText(path + @"\logfile.txt").Length;
        //    Assert.That(newLogLength, Is.GreaterThan(LogLength));

        //}
    }
}