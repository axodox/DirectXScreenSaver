using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using InfoHUD.Properties;
using InfoCore;

namespace InfoHUD
{
    public partial class OptionsForm : Form
    {
        StringDictionary AddIns;
        public OptionsForm()
        {
            InitializeComponent();
            AddIns = new StringDictionary();
            AddIns.Add("Logo", "Logo");
            AddIns.Add("CPU and RAM meters", "CPURAM");
            AddIns.Add("Public IP address", "IP");
            AddIns.Add("Network traffic", "NET");
            AddIns.Add("Username", "User");
            AddIns.Add("Calendar", "Date");
            AddIns.Add("Clock", "Clock");
            foreach (string key in AddIns.Keys)
            {
                LBAddIns.Items.Add(key);
            }
        }

        private void BOk_Click(object sender, EventArgs e)
        {
            Settings.Default.Save();
            Close();
        }

        private void BCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BDefault_Click(object sender, EventArgs e)
        {
            Settings.Default.Reset();
        }

        private void BAddInSettings_Click(object sender, EventArgs e)
        {
            InfoObject IO = InfoHUD.LoadInfoObject(AddIns[(string)LBAddIns.SelectedItem]);
            try
            {
                IO.ShowOptions();
            }
            catch (NotImplementedException)
            {
                MessageBox.Show("No options available!", IO.Name, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            IO.Dispose();
        }

        private void LBAddIns_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LBAddIns.SelectedIndex != null) BAddInSettings.Enabled = true;
        }
    }
}
