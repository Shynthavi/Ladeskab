using System;
using System.Collections.Generic;
using System.Text;

namespace Ladeskabsystem.Interfaces
{
    public class DoorStatusEventArgs : EventArgs
    {
        public bool Door { set; get; }
    }

    public interface IDoor
    {

        event EventHandler<DoorStatusEventArgs> DoorStatusEvent;

        void LockDoor();

        void UnlockDoor();

    }
}
