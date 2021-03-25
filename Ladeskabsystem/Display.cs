using System;
using System.Collections.Generic;
using System.Text;
using Ladeskabsystem.Interfaces;

namespace Ladeskabsystem
{
    class Display : IDisplay
    {
        public void ShowMessage(string s)
        {
            Console.WriteLine(s);
        }
    }
}
