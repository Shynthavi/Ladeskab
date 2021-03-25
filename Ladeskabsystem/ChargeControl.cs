using System.Globalization;
using Ladeskabsystem.Interfaces;

namespace Ladeskabsystem
{
    public class ChargeControl : IChargeControl
    {
        private IUsbCharger charger_;
        private bool _fullyCharged = false;
        private ChargingState  _state;

        private enum ChargingState
        {
            NoConnection,
            Charging,
            FullyCharged,
            ChargingError
        };


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

        private void ChargingCurrentValue(object sender, RfidEventArgs e)
        {
            switch (_state)
            {
                case ChargingState.NoConnection
                {

                }
            }

        }

    }
}