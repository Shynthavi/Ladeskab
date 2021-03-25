using System;
using System.Timers;
using Ladeskabsystem.Interfaces;

namespace Ladeskabsystem
{

    public class DoorOpenedEventArgs : EventArgs
    {
        public bool OpenDoor { set; get; }
    }
    public class DoorClosedEventArgs : EventArgs
    {
        public bool CloseDoor { set; get; }
    }

    public class DoorSimulator : IDoor
    {
        public event EventHandler<DoorOpenedEventArgs> DoorOpenEvent;
        public event EventHandler<DoorClosedEventArgs> DoorCloseEvent;

        public string DoorSimulatorString { get; private set; }

        public void OpenDoor(bool OpenDoor_)
        {
            OnNewOpenDoorStatus(new DoorOpenedEventArgs() { OpenDoor = OpenDoor_ });
        }

        public void ClosedDoor(bool CloseDoor_)
        {
            OnNewCloseDoorStatus(new DoorClosedEventArgs() { CloseDoor = CloseDoor_ });
        }


        public void LockDoor()
        {
            DoorSimulatorString = "Dør er låst";
            Console.WriteLine(DoorSimulatorString);

        }
        public void UnlockDoor()
        {
            DoorSimulatorString = "Dør er ulåst";
            Console.WriteLine(DoorSimulatorString);
        }

        protected virtual void OnNewOpenDoorStatus(DoorOpenedEventArgs e)
        {
            DoorOpenEvent?.Invoke(this, e);
        }
        protected virtual void OnNewCloseDoorStatus(DoorClosedEventArgs e)
        {
            DoorCloseEvent?.Invoke(this, e);
        }
    }
}
