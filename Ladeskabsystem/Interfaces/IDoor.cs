using System;
using System.Collections.Generic;
using System.Text;

namespace Ladeskabsystem.Interfaces
{
    public interface IDoor
    {
        public event EventHandler<DoorOpenedEventArgs> DoorOpenEvent;
        public event EventHandler<DoorClosedEventArgs> DoorCloseEvent;
        void LockDoor();
        void UnlockDoor();
    }
}
