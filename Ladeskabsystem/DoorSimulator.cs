using System;
using System.Timers;
using Ladeskabsystem.Interfaces;

namespace Ladeskabsystem
{
    public class DoorStatusEventArgs : EventArgs
    {
        public bool OpenDoor { set; get; }
    }
    public class DoorSimulator : IDoor
    {
        public event EventHandler<DoorStatusEventArgs> DoorStatusEvent;
        


        public void OpenLockedDoor(bool OpenDoor_)
        {
            OnNewDoorStatus(new DoorStatusEventArgs() { OpenDoor = OpenDoor_ });
        }
        

        public void LockDoor()
        {
            Console.WriteLine("Dør er låst");
        
        }
        public void UnlockDoor()
        {
            Console.WriteLine("Dør er ulåst");
        }

        protected virtual void OnNewDoorStatus(DoorStatusEventArgs e)
        {
            DoorStatusEvent?.Invoke(this, e);
        }

    }
}
