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
            
        }

        #region пеtля считывания

        public void Return()
        {
            RepeatGetSetValue(RETURN_OUTPUT,RETURN_VOLTAGE, RETURN_CURRENT);
        }

        #endregion

        #region кнопки

        #region кнопка Output

        
        public void Response(Button btn, string output)
        {
            GetSetValue(new CommandImplicits(output, btn.Name));
        }

        #endregion

        public void SetVoltageValues(Button btn,string voltage)
        {
            GetSetValue(new CommandImplicits(SET_VOLTAGE + $" {voltage}", btn.Name));
        }

        public void SetCurrentValue(Button btn, string current)
        {
            GetSetValue(new CommandImplicits(SET_CURRENT + $" {current}", btn.Name));
        }

        #endregion


    }
}