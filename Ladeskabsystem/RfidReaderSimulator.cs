using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using Ladeskabsystem.Interfaces;

namespace Ladeskabsystem
{
    public class RfidReaderSimulator : IRfidReader
    {
        public event EventHandler<RfidEventArgs> RfidEvent;

        private int _id;

        public int Id
        {
            get { return _id; }
            set
            {
                if (value > 0)
                {
                    OnNewRfid(new RfidEventArgs{isDetected = true});
                    _id = value;
                }
                else
                {
                    OnNewRfid(new RfidEventArgs { isDetected = false });
                }
            }
        }

        public void OnNewRfid(RfidEventArgs e)
        {
            RfidEvent?.Invoke(this, e);
        }
    }
}
