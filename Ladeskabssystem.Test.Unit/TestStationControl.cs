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
        private Read

        [SetUp]
        public void Setup()
        {
            _charger = Substitute.For<IUsbCharger>();
            _uut = new ChargeControl(_charger);
        }
    }
}
