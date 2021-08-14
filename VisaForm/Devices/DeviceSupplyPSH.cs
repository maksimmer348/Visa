using System;
using System.Threading;
using VisaForm.ComPort;
using VisaForm.Devices.Libraries;
using static VisaForm.Devices.Libraries.CommandsSupplyPSH;

namespace VisaForm.Devices
{
    public class DeviceSupplyPSH : Device
    {
       
        private void Output()
        {
            Start(() =>
            {
                SendCommands(RETURN_OUTPUT);
                if (Answer == "0")
                {
                    SendCommands(OUTPUT_ON);
                }
                else if (Answer == "1")
                {
                    SendCommands(OUTPUT_OFF);
                }
            });
        }
        void SetVoltageValues(int voltage)
        {
            SendCommands(SET_VOLTAGE);
        }

        void SetCurrentValue(int curent)
        {
            SendCommands(SET_CURRENT);
        }

        public override void Check()
        {
            try
            {
                Serial.Write(RETURN_VOLTAGE);
            }
            catch (Exception e)
            {

            }
        }
    }
}