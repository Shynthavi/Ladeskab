using System;
using System.Collections.Generic;
using System.Text;

namespace Ladeskabsystem.Interfaces
{
    public interface IDoor
    {
        event EventHandler<DoorStatusEventArgs> DoorStatusEvent;
        void LockDoor();
        void UnlockDoor();
    }
}
