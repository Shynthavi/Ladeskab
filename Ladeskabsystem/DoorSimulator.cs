using System;
using System.Timers;
using Ladeskabsystem.Interfaces;

namespace Ladeskabsystem
{

    public class DoorStatusEventArgs:EventArgs
    {
        public bool DoorLocked { set; get; }
    }

    public class DoorSimulator : IDoor
    {
        public event EventHandler<DoorStatusEventArgs> DoorOpenEvent;
        public event EventHandler<DoorStatusEventArgs> DoorCloseEvent;


        public void LockDoor()
        {
            OnNewCloseDoorStatus(new DoorStatusEventArgs() { DoorLocked = true });
        }
        public void UnlockDoor()
        {
            OnNewOpenDoorStatus(new DoorStatusEventArgs() { DoorLocked = false});
        }


        protected virtual void OnNewOpenDoorStatus(DoorStatusEventArgs d)
        {
            DoorOpenEvent?.Invoke(this, d);
        }
        protected virtual void OnNewCloseDoorStatus(DoorStatusEventArgs d)
        {
            DoorCloseEvent?.Invoke(this, d);
        }

    }
}
