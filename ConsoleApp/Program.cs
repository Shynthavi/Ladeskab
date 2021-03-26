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
        ChargeControl charger = new ChargeControl(UsbCharger,display);
        RfidReaderSimulator rfidReader = new RfidReaderSimulator();
        LogFile log = new LogFile();
        StationControl station = new StationControl(charger, door, display, rfidReader, log);




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
                    System.Console.WriteLine("Indtast RFID id:            (Fungerer kun hvis tilstand = Available)");
                    string idString = System.Console.ReadLine();

                    try
                    { 
                        int id = Convert.ToInt32(idString);
                        rfidReader.SimulateReading(id);
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Vil du venligst indtaste et tal?");
                    }

                    break;

                default:
                    break;
            }

        } while (!finish);
        
    }

}
