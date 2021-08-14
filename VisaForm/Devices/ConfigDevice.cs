using System.Windows.Forms;
using VisaForm.ComPort;

namespace VisaForm.Devices
{
    public struct ConfigDevice
    {
        public int ChannelNumber;
        public int BaudRate;
        public int ParityBit;
    }
}