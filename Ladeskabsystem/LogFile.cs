using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Ladeskabsystem.Interfaces;

namespace Ladeskabsystem
{
    public class LogFile : ILogFile
    {
        private string Logfile = "Logfile.txt";
        public void LogDoorLocked(int id)
        {

            using (var writer = File.AppendText(Logfile))
            {
                writer.WriteLine(DateTime.Now + ": Skab låst med RFID: {0}", id);
            }
        }

        public void LogDoorUnLocked(int id)
        {
            using (var writer = File.AppendText(Logfile))
            {
                writer.WriteLine(DateTime.Now + ": Skab låst op med RFID: {0}", id);
            }
        }
    }
    
}
