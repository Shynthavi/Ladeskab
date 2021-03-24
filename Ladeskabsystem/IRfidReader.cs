using System;
using System.Collections.Generic;
using System.Text;

namespace Ladeskabsystem
{
    public class RfidEventArgs : EventArgs
    {
        public bool isDetected { get; set; }
    }

    public interface IRfidReader
    {
        event EventHandler<RfidEventArgs> RfidEvent;
    }
}
