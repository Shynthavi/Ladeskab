using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ladeskabsystem.Interfaces;

namespace Ladeskabsystem
{
    public class StationControl
    {
        // Enum med tilstande ("states") svarende til tilstandsdiagrammet for klassen
        private enum LadeskabState
        {
            Available,
            Locked,
            DoorOpen
        };

        // Her mangler flere member variable
        private LadeskabState _state;
        private IChargeControl _charger;
        private int _oldId;
        private IDoor _door;
        private IDisplay _display;
        private IRfidReader _reader;
        private ILogFile _log;

        //private string logFile = "logfile.txt"; // Navnet på systemets log-fil

        // Her mangler constructor
        public StationControl(IChargeControl charger, IDoor door, IDisplay display, IRfidReader reader, ILogFile log)
        {
            _charger = charger;
            _door = door;
            _display = display;
            _reader = reader;
            _log = log;

            _door.DoorOpenEvent += DoorOpened;
            _door.DoorCloseEvent += DoorClosed;
            _reader.RfidEvent += RfidDetected;
        }

        // Eksempel på event handler for eventet "RFID Detected" fra tilstandsdiagrammet for klassen
        private void RfidDetected(object sender, RfidEventArgs e)
        {
            switch (_state)
            {
                case LadeskabState.Available:
                    // Check for ladeforbindelse
                    if (_charger.IsConnected())
                    {
                        _door.LockDoor();
                        _charger.StartCharge();
                        _oldId = e.Id;
                        
                        _log.LogDoorLocked(e.Id);

                        _display.ShowMessage("Skabet er låst og din telefon lades. Brug dit RFID tag til at låse op.");
                        _state = LadeskabState.Locked;
                    }
                    else
                    {
                        _display.ShowMessage("Din telefon er ikke ordentlig tilsluttet. Prøv igen.");
                    }

                    break;

                case LadeskabState.DoorOpen:
                    // Ignore
                    break;

                case LadeskabState.Locked:
                    // Check for correct ID
                    if (e.Id == _oldId)
                    {
                        _charger.StopCharge();
                        _door.UnlockDoor();

                        _log.LogDoorUnlocked(e.Id);

                        _display.ShowMessage("Tag din telefon ud af skabet og luk døren");
                        _state = LadeskabState.Available;
                    }
                    else
                    {
                        _display.ShowMessage("Forkert RFID tag");
                    }

                    break;
            }
        }

        // Her mangler de andre trigger handlere
        private void DoorOpened(object sender, DoorOpenedEventArgs e)
        {
            if (_state == LadeskabState.Available)
            {
                if (e.OpenDoor)
                {
                    _state = LadeskabState.DoorOpen;
                    _display.ShowMessage("Tilslut telefon");
                }
            }
        }


        private void DoorClosed(object sender, DoorClosedEventArgs e)
        {
            if (_state == LadeskabState.DoorOpen)
            {
                if (!e.CloseDoor)
                {
                    _state = LadeskabState.Available;
                    _display.ShowMessage("Indlæs RFID");
                }
            }
        }
    }
    
}
