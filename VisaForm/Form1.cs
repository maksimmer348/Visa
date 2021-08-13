using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VisaForm
{
    public partial class Form1 : Form
    {
        private event Action SetValuesToSupplyPSHCommand;
        private event Action StartTheSupplyPSHCommand;
        private event Action StartTheMeterGDMCommand;

        public Form1()
        {
            InitializeComponent();
        }

        private void SetValuesToSupplyPSH_Click(object sender, EventArgs e)
        {
            SetValuesToSupplyPSHCommand?.Invoke();
        }

        private void StartTheSupplyPSH_Click(object sender, EventArgs e)
        {
            StartTheSupplyPSHCommand?.Invoke();
           

        }

        private void StartTheMeterGDM_Click(object sender, EventArgs e)
        {
            StartTheMeterGDMCommand?.Invoke();
        }

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
            tb.Invoke(new Action(() => tb.Text = data));
        }
    }

    
}
