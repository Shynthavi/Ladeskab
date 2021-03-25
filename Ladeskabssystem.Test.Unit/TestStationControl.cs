using Ladeskabsystem;
using Ladeskabsystem.Interfaces;
using NSubstitute;
using NUnit.Framework;

namespace Ladeskabssystem.Test.Unit
{
    class TestStationControl
    {
        private StationControl _uut;
        private IUsbCharger _charger;
        private IRfidReader _reader;
        private IDoor _door;
        private IChargeControl _chargeControl;
        private IDisplay _display;
        private ILogFile _log;

        [SetUp]
        public void Setup()
        {
            _door = Substitute.For<IDoor>();
            _reader = Substitute.For<IRfidReader>();
            _chargeControl = Substitute.For<IChargeControl>();
            _display = Substitute.For<IDisplay>();
            _log = Substitute.For<ILogFile>();
            _uut = new StationControl(_chargeControl, _door, _display, _reader, _log);
        }



    }
}
