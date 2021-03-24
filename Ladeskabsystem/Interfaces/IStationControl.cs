namespace Ladeskabsystem.Interfaces
{
    public interface IStationControl
    {
        public void RfidDetected(int id);
        public void DoorOpened();
        public void DoorClosed();
    }
}