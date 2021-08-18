using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using VisaForm.ComPort;
using VisaForm.Devices.Libraries;
using static VisaForm.Devices.Libraries.CommandsSupplyPSH;

namespace VisaForm.Devices
{
    public class DeviceSupplyPSH : Device
    {
        public DeviceSupplyPSH(ConfigDevice cfg) : base(cfg, "?")
        {
            ResponseSpecMessage += Response;
        }

        private void Response(string response, CommandImplicits cmd)
        {
            if (cmd.Btn == "StartTheSupplyPSH")
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

        public void Output(Button btn)
        {
            SetValue(new CommandImplicits(RETURN_OUTPUT, btn.Name));
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

    public class CommandImplicits
    {
        public string Command;
        public string Btn;

        public CommandImplicits(string command, string btnName)
        {
            Command = command;
            Btn = btnName;
        }

        public static implicit operator CommandImplicits(string command)
        {
            CommandImplicits c = new CommandImplicits(command, null);
            return c;
        }
    }
}