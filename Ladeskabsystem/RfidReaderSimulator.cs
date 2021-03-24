using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using Ladeskabsystem.Interfaces;

namespace Ladeskabsystem
{
    public class RfidReaderSimulator : IRfidReader
    {
        private IStationControl _stationControl;
        public RfidReaderSimulator(IStationControl StationControl)
        {
            _stationControl = StationControl;
        }
        public event EventHandler<RfidEventArgs> RfidEvent;

        private int _id;


        public void SimulateIdReading(int id)
        {
            _stationControl.RFidConnected(_id);
        }

        public void OnNewRfid(RfidEventArgs e)
        {
            RfidEvent?.Invoke(this, e);
        }
    }
}
