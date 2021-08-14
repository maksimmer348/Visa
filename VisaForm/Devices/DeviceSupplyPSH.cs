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
        public DeviceSupplyPSH() : base(identifier:"?")
        {
        }

        private async void Output()
        {
            var answer = await StartSendCommands(RETURN_OUTPUT);
            if (answer == "0")
            {
                await StartSendCommands(OUTPUT_ON);
            }
            else if (answer == "1")
            {
                await StartSendCommands(OUTPUT_OFF);
            }
        }

        async Task<string> ReturnVoltage()
        {
            return await StartSendCommands(RETURN_VOLTAGE);
        }
        void SetVoltageValues(int voltage)
        {
            StartSendCommands(SET_VOLTAGE).ConfigureAwait(false);
        }

        void SetCurrentValue(int curent)
        {
            StartSendCommands(SET_CURRENT).ConfigureAwait(false); ;
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