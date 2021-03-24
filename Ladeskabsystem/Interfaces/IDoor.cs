using System;
using System.Collections.Generic;
using System.Text;

namespace Ladeskabsystem.Interfaces
{
    public interface IDoor
    {
        event EventHandler<DoorStatusEventArgs> DoorStatusEvent;
        bool DoorIsOpen { get; }
        bool DoorIsClosed { get; }
        void LockDoor();
        void UnlockDoor();
    }
}
