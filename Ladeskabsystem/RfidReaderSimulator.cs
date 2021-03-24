using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Ladeskabsystem
{
    public class RfidReaderSimulator : IRfidReader
    {
        public event EventHandler<RfidEventArgs> RfidEvent;
        public void OnNewRfid(RfidEventArgs e)
        {
            RfidEvent?.Invoke(this, e);
        }

    }
}
