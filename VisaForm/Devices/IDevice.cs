using System;
using System.IO.Ports;
using System.Runtime.CompilerServices;

namespace VisaForm.Devices
{
    public interface IDevice
    {
        event EventHandler<string> Received;
        void SetConfig(ConfigDevice cfg);
        string SendCommands(params string[] commands);
        void Check();
    }
}