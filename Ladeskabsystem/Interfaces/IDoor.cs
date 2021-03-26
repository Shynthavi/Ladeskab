using System;
using System.Collections.Generic;
using System.Text;

namespace Ladeskabsystem.Interfaces
{
    public interface IDoor
    {
        //public event EventHandler<DoorOpenedEventArgs> DoorOpenEvent;
        //public event EventHandler<DoorClosedEventArgs> DoorCloseEvent;

        public event EventHandler<DoorStatusEventArgs> DoorOpenEvent;
        public event EventHandler<DoorStatusEventArgs> DoorCloseEvent;
        void LockDoor();
        void UnlockDoor();
    }
}
