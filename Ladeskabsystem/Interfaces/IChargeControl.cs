namespace Ladeskabsystem.Interfaces
{
    public interface IChargeControl
    {
        bool IsConnected();
        void StartCharge();
        void StopCharge();
    }
}