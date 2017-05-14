using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace InfoHUD
{
    public partial class NETOptions : Form
    {
        public NETOptions()
        {
            InitializeComponent();
            CBInterface.Items.AddRange(new PerformanceCounterCategory("Network Interface").GetInstanceNames());
        }
    }
}
