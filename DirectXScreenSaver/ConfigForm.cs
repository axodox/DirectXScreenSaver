using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DirectXScreenSaver.Properties;

namespace DirectXScreenSaver
{
    public partial class ConfigForm : Form
    {
        public ConfigForm()
        {
            InitializeComponent();
        }

        private void BOk_Click(object sender, EventArgs e)
        {
            Settings.Default.Save();
            Close();
        }

        private void BDefault_Click(object sender, EventArgs e)
        {
            Settings.Default.Reset();
        }

        private void BCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BInfoHUDOptions_Click(object sender, EventArgs e)
        {
            Form OF = new InfoHUD.OptionsForm();
            OF.ShowDialog();
            OF.Dispose();
        }
    }
}
