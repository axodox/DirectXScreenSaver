namespace InfoHUD
{
    partial class NETOptions
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
            System.Windows.Forms.Label LInterface;
            this.CBInterface = new System.Windows.Forms.ComboBox();
            this.BOk = new System.Windows.Forms.Button();
            LInterface = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // CBInterface
            // 
            this.CBInterface.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::InfoHUD.Properties.Settings.Default, "IONETInterface", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.CBInterface.DisplayMember = "Intel[R] Wireless WiFi Link 4965AGN";
            this.CBInterface.FormattingEnabled = true;
            this.CBInterface.Location = new System.Drawing.Point(15, 25);
            this.CBInterface.Name = "CBInterface";
            this.CBInterface.Size = new System.Drawing.Size(307, 21);
            this.CBInterface.TabIndex = 0;
            this.CBInterface.Text = global::InfoHUD.Properties.Settings.Default.IONETInterface;
            this.CBInterface.ValueMember = "Intel[R] Wireless WiFi Link 4965AGN";
            // 
            // BOk
            // 
            this.BOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.BOk.Location = new System.Drawing.Point(328, 23);
            this.BOk.Name = "BOk";
            this.BOk.Size = new System.Drawing.Size(75, 23);
            this.BOk.TabIndex = 1;
            this.BOk.Text = "Ok";
            this.BOk.UseVisualStyleBackColor = true;
            // 
            // LInterface
            // 
            LInterface.AutoSize = true;
            LInterface.Location = new System.Drawing.Point(12, 9);
            LInterface.Name = "LInterface";
            LInterface.Size = new System.Drawing.Size(94, 13);
            LInterface.TabIndex = 2;
            LInterface.Text = "Network interface:";
            // 
            // NETOptions
            // 
            this.AcceptButton = this.BOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 57);
            this.Controls.Add(LInterface);
            this.Controls.Add(this.BOk);
            this.Controls.Add(this.CBInterface);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NETOptions";
            this.Text = "Network traffic options";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox CBInterface;
        private System.Windows.Forms.Button BOk;
    }
}