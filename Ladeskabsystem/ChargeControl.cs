using System.Globalization;
using Ladeskabsystem.Interfaces;

namespace Ladeskabsystem
{
    public class ChargeControl : IChargeControl
    {
        private IUsbCharger charger_;

        public ChargeControl(IUsbCharger charger)
        {
            charger_ = charger;
        }

        public bool IsConnected()
        {
            return charger_.Connected;
        }

        public void StartCharge()
        {
            charger_.StartCharge();
        }

        public void StopCharge()
        {
            charger_.StopCharge();
        }
    }
}