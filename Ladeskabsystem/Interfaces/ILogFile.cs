using System;
using System.Collections.Generic;
using System.Text;

namespace Ladeskabsystem.Interfaces
{
    public interface ILogFile
    {
        void LogDoorLocked(int id);
        void LogDoorUnlocked(int id);
    }
}
