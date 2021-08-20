using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VisaForm.Devices;
using VisaForm.Devices.Libraries;
using static VisaForm.Devices.Libraries.CommandsSupplyPSH;
namespace VisaForm
{
    public partial class Form1 : Form
    {
        DeviceSupplyPSH Psh = new DeviceSupplyPSH(new ConfigDevice { ChannelNumber = 4, BaudRate = 9600, ParityBit = 0 });
        public Form1()
        {
            InitializeComponent();
            Psh.ResponseSpecMessage += Update;
            Psh.Return();
        }

        private void Update(string response, CommandImplicits cmd)
        {
            if (cmd.Btn != null)
            {
                return;
            }
            if (cmd.Command == RETURN_VOLTAGE)
            {
                UpdateBox(GetVoltageToSupplyPSH, response);
            }
            else if (cmd.Command == RETURN_CURRENT)
            {
                UpdateBox(GetCurrentToSupplyPSH, response);
            }
            else if (cmd.Command == RETURN_OUTPUT)
            {
                UpdateIndicator(CheckIndicatorPSH, response);
            }
        }

        private void SetValuesToSupplyPSH_Click(object sender, EventArgs e)
        {
            
            Psh.SetVoltageValues((Button)sender,SetVoltageToSupplyPSH.Text.Replace(",", "."));
            Psh.SetCurrentValue((Button)sender,SetCurrentToSupplyPSH.Text.Replace(",", "."));

        }

        private void StartTheSupplyPSH_Click(object sender, EventArgs e)
        {
            StartTheSupplyPSH.Enabled = false;
            Psh.GetSetSpecValue(RETURN_OUTPUT,new RequestAndResponse{CommandApply1 = OUTPUT_OFF,CommandApply2 = OUTPUT_ON, ResponseCommandTrue = "1", ResponseCommandFalse = "0"}, (Button)sender);
            StartTheSupplyPSH.Enabled = true;
        }

        private void StartTheMeterGDM_Click(object sender, EventArgs e)
        {
            
        }

        #region работа с пользовательским интерфейсом

        private void FineTuning_CheckedChanged(object sender, EventArgs e)
        {
            SwitchPrecisionModes();
        }

        void SwitchPrecisionModes()
        {
            if (FineTuning.Checked)
            {
                SetVoltageToSupplyPSH.Increment = 0.01m;
                SetCurrentToSupplyPSH.Increment = 0.01m;
            }
            else
            {
                SetVoltageToSupplyPSH.Increment = 1;
                SetCurrentToSupplyPSH.Increment = 1;
            }
        }

        void UpdateBox(TextBox tb, string data)
        {
            tb.Invoke(new Action(() => tb.Text = data));//попробовать без этого
        }

        void UpdateIndicator(Button btn, string enable)
        {
            if (enable == "1")
            {
                btn.BackColor = Color.Green;
            }
            else if (enable == "0")
            {
                btn.BackColor = Color.Red;
            }
        }


        #endregion

        private void CheckDevice_Click(object sender, EventArgs e)
        {
            Psh.Response((Button)sender, OUTPUT_OFF);//(Button)sender отправка индентификатора кнопки
        }
    }


}
