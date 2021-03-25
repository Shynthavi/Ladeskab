using System;
using Ladeskabsystem;
using Ladeskabsystem.Interfaces;

class Program
{

    static void Main(string[] args)
    {
        // Assemble your system here from all the classes
        DoorSimulator door = new DoorSimulator();
        Display display = new Display();
        UsbChargerSimulator UsbCharger = new UsbChargerSimulator();
        ChargeControl charger = new ChargeControl(UsbCharger);
        RfidReaderSimulator rfidReader = new RfidReaderSimulator();
        StationControl station = new StationControl(charger, door, display, rfidReader);
        LogFile log = new LogFile();



        bool finish = false;
        do
        {
            string input;
            System.Console.WriteLine("Indtast E, O, C, R: ");
            input = Console.ReadLine();
            if (string.IsNullOrEmpty(input)) continue;

            switch (input[0])
            {
                case 'E':
                    finish = true;
                    break;

                case 'O':
                    door.UnlockDoor();
                    break;

                case 'C':
                    door.LockDoor();
                    break;

                case 'R':
                    System.Console.WriteLine("Indtast RFID id: ");
                    string idString = System.Console.ReadLine();

                    int id = Convert.ToInt32(idString);
                    rfidReader.SimulateReading(id);
                    break;

                default:
                    break;
            }

        } while (!finish);
        
    }

}
