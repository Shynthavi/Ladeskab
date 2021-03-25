using System.Globalization;
using Ladeskabsystem.Interfaces;

namespace Ladeskabsystem
{
    public class ChargeControl : IChargeControl
    {
        private IUsbCharger charger_;
        private bool _fullyCharged = false;
        private ChargingState  _state;
        private IDisplay _display;

        private enum ChargingState
        {
            NoConnection,
            Charging,
            FullyCharged,
            ChargingError
        };


        public ChargeControl(IUsbCharger charger, IDisplay display)
        {
            charger_ = charger;
            _display = display;
            charger_.CurrentValueEvent += ChargingCurrentValue;
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

        private void ChargingCurrentValue(object sender, CurrentEventArgs e)
        {
            if (e.Current == 0)
                _state = ChargingState.NoConnection;
            else if (e.Current <= 5)
                _state = ChargingState.FullyCharged;
            else if (e.Current>5 && e.Current  <= 500)
                _state = ChargingState.Charging;
            else if (e.Current > 500)
                _state = ChargingState.ChargingError;

            switch (_state)
            {
                case ChargingState.NoConnection:
                    _display.ShowMessage("Din telefon er ikke ordentlig tilsluttet. Prøv igen.");

                    break;

                case ChargingState.Charging:
                    _display.ShowMessage("Din telefon oplades.");

                    break;

                case ChargingState.FullyCharged:
                    _display.ShowMessage("Din telefon er fuldt opladt.");

                    break;

                case ChargingState.ChargingError:
                    _display.ShowMessage("Error: Prøv igen.");

                    break;
            }

        }

    }
}