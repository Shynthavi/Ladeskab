using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Ladeskabsystem;
using Ladeskabsystem.Interfaces;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using NSubstitute;
using NSubstitute.ReceivedExtensions;
using NUnit.Framework;

namespace Ladeskabssystem.Test.Unit
{
    public class TestDisplay
    {
        private Display _uut;

        [SetUp]
        public void Setup()
        {
            _uut = new Display();
        }

        [Test]
        public void StringToDisplay()
        {
            string _message = "Tests if Display works";
            StringWriter output = new StringWriter();
            Console.SetOut(output);

            _uut.ShowMessage(_message);

            var expected = _message+"\r\n";
            Assert.That(output.ToString(),Is.EqualTo(expected));
        }
    }
}
