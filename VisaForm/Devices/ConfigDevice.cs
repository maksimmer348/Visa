using System.Windows.Forms;
using VisaForm.ComPort;

namespace VisaForm.Devices
{
    public struct ConfigDevice
    {
        public string DeviceName;
        public int CannelNum;
        public int BaudRate;
        public int ParityBit;
    }
}