using System;
using System.Timers;
using Ladeskabsystem.Interfaces;

namespace Ladeskabsystem
{
    public class DoorSimulator : IDoor
    {
        public event EventHandler<DoorStatusEventArgs> DoorStatusEvent;

        bool DoorIsOpen;

        public void LockDoor()
        { }

        public void UnlockDoor()
        { }

        private void OnNewDoorStatus()
        {
            DoorStatusEvent?.Invoke(this, new DoorStatusEventArgs() { Door = this.DoorIsOpen });
        }

    }
}
