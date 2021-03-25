using System;
using System.Collections.Generic;
using System.Text;
using Ladeskabsystem.Interfaces;

namespace Ladeskabsystem
{
    public class Display : IDisplay
    {
        public void ShowMessage(string s)
        {
            Console.WriteLine(s);
        }
    }
}
