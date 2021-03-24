using System;
using System.Collections.Generic;
using System.Text;

namespace Ladeskabsystem.Interfaces
{
    public interface IRfidReader
    {
        void checkId(int Id);
        event EventHandler<RfidEventArgs> RfidEvent;
    }
}
