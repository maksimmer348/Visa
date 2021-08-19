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
            ResponseButtonMessage += Response;
        }

        #region пеtля считывания

        public void Return()
        {
            RepeatGetSetValue(RETURN_OUTPUT, RETURN_VOLTAGE, RETURN_CURRENT);
        }



        #endregion


        #region кнопки

        #region кнопка Output

        public void Output(Button btn)
        {
            GetSetValue(new CommandImplicits(RETURN_OUTPUT, btn.Name));
        }
        private void Response(string response, CommandImplicits cmd)
        {
            if (cmd.Btn == "StartTheSupplyPSH")
            {
                if (response == "1")
                {
                    GetSetValue(OUTPUT_OFF);
                }
                else if (response == "0")
                {
                    GetSetValue(OUTPUT_ON);
                }
            }
        }

        //public void Output()
        //{
        //    SetValue(RETURN_OUTPUT);
        //}

        //private void Response(string response, string cmd)
        //{
        //    if (cmd == "StartTheSupplyPSH")
        //    {
        //        if (response == "1")
        //        {
        //            SetValue(OUTPUT_OFF);
        //        }
        //        else if (response == "0")
        //        {
        //            SetValue(OUTPUT_ON);
        //        }
        //    }
        //}

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