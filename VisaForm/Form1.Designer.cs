
namespace VisaForm
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SetValuesToSupplyPSH = new System.Windows.Forms.Button();
            this.StartTheSupplyPSH = new System.Windows.Forms.Button();
            this.SetCurrentToSupplyPSH = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.SetVoltageToSupplyPSH = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.GetCurrentToSupplyPSH = new System.Windows.Forms.TextBox();
            this.GetVoltageToSupplyPSH = new System.Windows.Forms.TextBox();
            this.GroupSupplyPSH = new System.Windows.Forms.GroupBox();
            this.GroupMeterGDM = new System.Windows.Forms.GroupBox();
            this.StartTheMeterGDM = new System.Windows.Forms.Button();
            this.GetVoltageToMeterGDM = new System.Windows.Forms.TextBox();
            this.GetCurrentToMeterGDM = new System.Windows.Forms.TextBox();
            this.GetPowerToMeterGDM = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.FineTuning = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.SetCurrentToSupplyPSH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SetVoltageToSupplyPSH)).BeginInit();
            this.GroupSupplyPSH.SuspendLayout();
            this.GroupMeterGDM.SuspendLayout();
            this.SuspendLayout();
            // 
            // SetValuesToSupplyPSH
            // 
            this.SetValuesToSupplyPSH.Location = new System.Drawing.Point(6, 113);
            this.SetValuesToSupplyPSH.Name = "SetValuesToSupplyPSH";
            this.SetValuesToSupplyPSH.Size = new System.Drawing.Size(99, 23);
            this.SetValuesToSupplyPSH.TabIndex = 0;
            this.SetValuesToSupplyPSH.Text = "установить бп";
            this.SetValuesToSupplyPSH.UseVisualStyleBackColor = true;
            this.SetValuesToSupplyPSH.Click += new System.EventHandler(this.SetValuesToSupplyPSH_Click);
            // 
            // StartTheSupplyPSH
            // 
            this.StartTheSupplyPSH.Location = new System.Drawing.Point(116, 113);
            this.StartTheSupplyPSH.Name = "StartTheSupplyPSH";
            this.StartTheSupplyPSH.Size = new System.Drawing.Size(100, 23);
            this.StartTheSupplyPSH.TabIndex = 1;
            this.StartTheSupplyPSH.Text = "запустить бп";
            this.StartTheSupplyPSH.UseVisualStyleBackColor = true;
            this.StartTheSupplyPSH.Click += new System.EventHandler(this.StartTheSupplyPSH_Click);
            // 
            // SetCurrentToSupplyPSH
            // 
            this.SetCurrentToSupplyPSH.DecimalPlaces = 2;
            this.SetCurrentToSupplyPSH.Location = new System.Drawing.Point(54, 55);
            this.SetCurrentToSupplyPSH.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.SetCurrentToSupplyPSH.Name = "SetCurrentToSupplyPSH";
            this.SetCurrentToSupplyPSH.Size = new System.Drawing.Size(75, 20);
            this.SetCurrentToSupplyPSH.TabIndex = 4;
            this.SetCurrentToSupplyPSH.ThousandsSeparator = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "амперы";
            // 
            // SetVoltageToSupplyPSH
            // 
            this.SetVoltageToSupplyPSH.DecimalPlaces = 2;
            this.SetVoltageToSupplyPSH.Location = new System.Drawing.Point(54, 29);
            this.SetVoltageToSupplyPSH.Maximum = new decimal(new int[] {
            36,
            0,
            0,
            0});
            this.SetVoltageToSupplyPSH.Name = "SetVoltageToSupplyPSH";
            this.SetVoltageToSupplyPSH.Size = new System.Drawing.Size(75, 20);
            this.SetVoltageToSupplyPSH.TabIndex = 6;
            this.SetVoltageToSupplyPSH.ThousandsSeparator = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "вольты";
            // 
            // GetCurrentToSupplyPSH
            // 
            this.GetCurrentToSupplyPSH.Location = new System.Drawing.Point(141, 55);
            this.GetCurrentToSupplyPSH.Name = "GetCurrentToSupplyPSH";
            this.GetCurrentToSupplyPSH.ReadOnly = true;
            this.GetCurrentToSupplyPSH.Size = new System.Drawing.Size(75, 20);
            this.GetCurrentToSupplyPSH.TabIndex = 10;
            // 
            // GetVoltageToSupplyPSH
            // 
            this.GetVoltageToSupplyPSH.Location = new System.Drawing.Point(141, 28);
            this.GetVoltageToSupplyPSH.Name = "GetVoltageToSupplyPSH";
            this.GetVoltageToSupplyPSH.ReadOnly = true;
            this.GetVoltageToSupplyPSH.Size = new System.Drawing.Size(75, 20);
            this.GetVoltageToSupplyPSH.TabIndex = 12;
            // 
            // GroupSupplyPSH
            // 
            this.GroupSupplyPSH.Controls.Add(this.FineTuning);
            this.GroupSupplyPSH.Controls.Add(this.GetCurrentToSupplyPSH);
            this.GroupSupplyPSH.Controls.Add(this.GetVoltageToSupplyPSH);
            this.GroupSupplyPSH.Controls.Add(this.SetValuesToSupplyPSH);
            this.GroupSupplyPSH.Controls.Add(this.StartTheSupplyPSH);
            this.GroupSupplyPSH.Controls.Add(this.label3);
            this.GroupSupplyPSH.Controls.Add(this.SetCurrentToSupplyPSH);
            this.GroupSupplyPSH.Controls.Add(this.SetVoltageToSupplyPSH);
            this.GroupSupplyPSH.Controls.Add(this.label2);
            this.GroupSupplyPSH.Location = new System.Drawing.Point(12, 12);
            this.GroupSupplyPSH.Name = "GroupSupplyPSH";
            this.GroupSupplyPSH.Size = new System.Drawing.Size(226, 150);
            this.GroupSupplyPSH.TabIndex = 13;
            this.GroupSupplyPSH.TabStop = false;
            this.GroupSupplyPSH.Text = "Supply PSH";
            // 
            // GroupMeterGDM
            // 
            this.GroupMeterGDM.Controls.Add(this.label5);
            this.GroupMeterGDM.Controls.Add(this.label1);
            this.GroupMeterGDM.Controls.Add(this.label4);
            this.GroupMeterGDM.Controls.Add(this.GetPowerToMeterGDM);
            this.GroupMeterGDM.Controls.Add(this.GetCurrentToMeterGDM);
            this.GroupMeterGDM.Controls.Add(this.GetVoltageToMeterGDM);
            this.GroupMeterGDM.Controls.Add(this.StartTheMeterGDM);
            this.GroupMeterGDM.Location = new System.Drawing.Point(259, 12);
            this.GroupMeterGDM.Name = "GroupMeterGDM";
            this.GroupMeterGDM.Size = new System.Drawing.Size(183, 150);
            this.GroupMeterGDM.TabIndex = 15;
            this.GroupMeterGDM.TabStop = false;
            this.GroupMeterGDM.Text = "Meter GDM";
            // 
            // StartTheMeterGDM
            // 
            this.StartTheMeterGDM.Location = new System.Drawing.Point(6, 113);
            this.StartTheMeterGDM.Name = "StartTheMeterGDM";
            this.StartTheMeterGDM.Size = new System.Drawing.Size(171, 23);
            this.StartTheMeterGDM.TabIndex = 13;
            this.StartTheMeterGDM.Text = "запустить измерения";
            this.StartTheMeterGDM.UseVisualStyleBackColor = true;
            this.StartTheMeterGDM.Click += new System.EventHandler(this.StartTheMeterGDM_Click);
            // 
            // GetVoltageToMeterGDM
            // 
            this.GetVoltageToMeterGDM.Location = new System.Drawing.Point(64, 28);
            this.GetVoltageToMeterGDM.Name = "GetVoltageToMeterGDM";
            this.GetVoltageToMeterGDM.ReadOnly = true;
            this.GetVoltageToMeterGDM.Size = new System.Drawing.Size(100, 20);
            this.GetVoltageToMeterGDM.TabIndex = 13;
            // 
            // GetCurrentToMeterGDM
            // 
            this.GetCurrentToMeterGDM.Location = new System.Drawing.Point(64, 55);
            this.GetCurrentToMeterGDM.Name = "GetCurrentToMeterGDM";
            this.GetCurrentToMeterGDM.ReadOnly = true;
            this.GetCurrentToMeterGDM.Size = new System.Drawing.Size(100, 20);
            this.GetCurrentToMeterGDM.TabIndex = 14;
            // 
            // GetPowerToMeterGDM
            // 
            this.GetPowerToMeterGDM.Location = new System.Drawing.Point(64, 81);
            this.GetPowerToMeterGDM.Name = "GetPowerToMeterGDM";
            this.GetPowerToMeterGDM.ReadOnly = true;
            this.GetPowerToMeterGDM.Size = new System.Drawing.Size(100, 20);
            this.GetPowerToMeterGDM.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "вольты";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "амперы";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 84);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "ватты";
            // 
            // FineTuning
            // 
            this.FineTuning.AutoSize = true;
            this.FineTuning.Location = new System.Drawing.Point(6, 84);
            this.FineTuning.Name = "FineTuning";
            this.FineTuning.Size = new System.Drawing.Size(54, 17);
            this.FineTuning.TabIndex = 13;
            this.FineTuning.Text = "точно";
            this.FineTuning.UseVisualStyleBackColor = true;
            this.FineTuning.CheckedChanged += new System.EventHandler(this.FineTuning_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 165);
            this.Controls.Add(this.GroupMeterGDM);
            this.Controls.Add(this.GroupSupplyPSH);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.SetCurrentToSupplyPSH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SetVoltageToSupplyPSH)).EndInit();
            this.GroupSupplyPSH.ResumeLayout(false);
            this.GroupSupplyPSH.PerformLayout();
            this.GroupMeterGDM.ResumeLayout(false);
            this.GroupMeterGDM.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button SetValuesToSupplyPSH;
        private System.Windows.Forms.Button StartTheSupplyPSH;
        private System.Windows.Forms.NumericUpDown SetCurrentToSupplyPSH;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown SetVoltageToSupplyPSH;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox GetCurrentToSupplyPSH;
        private System.Windows.Forms.TextBox GetVoltageToSupplyPSH;
        private System.Windows.Forms.GroupBox GroupSupplyPSH;
        private System.Windows.Forms.GroupBox GroupMeterGDM;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox GetPowerToMeterGDM;
        private System.Windows.Forms.TextBox GetCurrentToMeterGDM;
        private System.Windows.Forms.TextBox GetVoltageToMeterGDM;
        private System.Windows.Forms.Button StartTheMeterGDM;
        private System.Windows.Forms.CheckBox FineTuning;
    }
}

