using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using Ladeskabsystem.Interfaces;

namespace Ladeskabsystem
{
    public class RfidEventArgs : EventArgs
    {
        public int Id { get; set; }
    }


    public class RfidReaderSimulator : IRfidReader
    {
  
        public event EventHandler<RfidEventArgs> RfidEvent;

        public void SimulateReading(int id)
        {
            if (0 < id)
            {
                OnNewRfid(new RfidEventArgs(){ Id = id });
            }
            else
            {
                throw new ArgumentOutOfRangeException("Id is out of range");
            }
        }

        private void OnNewRfid(RfidEventArgs e)
        {
            RfidEvent?.Invoke(this, e);
        }
    }
}
