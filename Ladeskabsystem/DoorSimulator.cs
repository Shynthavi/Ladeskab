using System;
using System.Timers;
using Ladeskabsystem.Interfaces;

namespace Ladeskabsystem
{
    public class DoorStatusEventArgs : EventArgs
    {
        public bool Doors { set; get; }
    }
    public class DoorSimulator : IDoor
    {
        public event EventHandler<DoorStatusEventArgs> DoorStatusEvent;
        public bool DoorIsOpen
        {
            get;
            private set;
        }
        public bool DoorIsClosed
        { 
            get; 
            private set; 
        }

        public DoorSimulator()
        {
            DoorIsOpen = false;
            DoorIsClosed = false;
        }

        public void OpenDoor()
        {
            if (DoorIsOpen == true)
                return;
            DoorIsOpen = true;
            OnNewDoorStatus(new DoorStatusEventArgs() { Doors = DoorIsOpen });
        }
        public void CloseDoor()
        {
            if (DoorIsClosed == true)
                return;
            DoorIsClosed = true;
            OnNewDoorStatus(new DoorStatusEventArgs() { Doors = DoorIsClosed });
        }

        public void LockDoor()
        {
            if (DoorIsOpen == true || DoorIsClosed == true)
                return;
            DoorIsClosed = true;
        
        }
        public void UnlockDoor()
        {
            if (DoorIsOpen == true || DoorIsClosed == false)
                return;
            DoorIsClosed = false;
        }

        private void OnNewDoorStatus(DoorStatusEventArgs e)
        {
            DoorStatusEvent?.Invoke(this, e);
        }

    }
}
