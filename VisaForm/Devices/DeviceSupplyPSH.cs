using System;
using System.Threading;
using System.Threading.Tasks;
using VisaForm.ComPort;
using VisaForm.Devices.Libraries;
using static VisaForm.Devices.Libraries.CommandsSupplyPSH;

namespace VisaForm.Devices
{
    public class DeviceSupplyPSH : Device
    {
        public DeviceSupplyPSH(ConfigDevice cfg) : base(cfg, "?")
        {
            ResponseSpecMessage += REsponse;
        }

        private void REsponse(string response, string cmd)
        {
            if (cmd == RETURN_OUTPUT)
            {
                if (response == "1")
                {
                    SetValue(OUTPUT_OFF);
                }
                else if (response == "0")
                {
                    SetValue(OUTPUT_ON);
                }
            }
        }

        public void Output()
        {
            SetValue(RETURN_OUTPUT);
        }

        public void Return()
        {
            GetValue(RETURN_OUTPUT, RETURN_VOLTAGE, RETURN_CURRENT);
        }

        public void SetVoltageValues(string voltage)
        {
            SetValue(SET_VOLTAGE + $" {voltage}");
        }

        public void SetCurrentValue(string current)
        {
            SetValue(SET_CURRENT + $" {current}");
        }

    }
}