namespace InfoHUD
{
    partial class OptionsForm
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
            System.Windows.Forms.TabControl TCMain;
            System.Windows.Forms.TabPage TPAddIns;
            System.Windows.Forms.Label LAboutTitle;
            System.Windows.Forms.Label LAboutSubTitle;
            System.Windows.Forms.TextBox TBAboutDescription;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptionsForm));
            this.TPAbout = new System.Windows.Forms.TabPage();
            this.BDefault = new System.Windows.Forms.Button();
            this.BOk = new System.Windows.Forms.Button();
            this.BCancel = new System.Windows.Forms.Button();
            this.LBAddIns = new System.Windows.Forms.ListBox();
            this.BAddInSettings = new System.Windows.Forms.Button();
            TCMain = new System.Windows.Forms.TabControl();
            TPAddIns = new System.Windows.Forms.TabPage();
            LAboutTitle = new System.Windows.Forms.Label();
            LAboutSubTitle = new System.Windows.Forms.Label();
            TBAboutDescription = new System.Windows.Forms.TextBox();
            TCMain.SuspendLayout();
            TPAddIns.SuspendLayout();
            this.TPAbout.SuspendLayout();
            this.SuspendLayout();
            // 
            // TCMain
            // 
            TCMain.Controls.Add(TPAddIns);
            TCMain.Controls.Add(this.TPAbout);
            TCMain.Location = new System.Drawing.Point(0, 0);
            TCMain.Name = "TCMain";
            TCMain.SelectedIndex = 0;
            TCMain.Size = new System.Drawing.Size(408, 279);
            TCMain.TabIndex = 3;
            // 
            // TPAddIns
            // 
            TPAddIns.Controls.Add(this.BAddInSettings);
            TPAddIns.Controls.Add(this.LBAddIns);
            TPAddIns.Location = new System.Drawing.Point(4, 22);
            TPAddIns.Name = "TPAddIns";
            TPAddIns.Padding = new System.Windows.Forms.Padding(3);
            TPAddIns.Size = new System.Drawing.Size(400, 253);
            TPAddIns.TabIndex = 0;
            TPAddIns.Text = "Add ins-s";
            TPAddIns.UseVisualStyleBackColor = true;
            // 
            // TPAbout
            // 
            this.TPAbout.Controls.Add(TBAboutDescription);
            this.TPAbout.Controls.Add(LAboutSubTitle);
            this.TPAbout.Controls.Add(LAboutTitle);
            this.TPAbout.Location = new System.Drawing.Point(4, 22);
            this.TPAbout.Name = "TPAbout";
            this.TPAbout.Padding = new System.Windows.Forms.Padding(3);
            this.TPAbout.Size = new System.Drawing.Size(400, 253);
            this.TPAbout.TabIndex = 1;
            this.TPAbout.Text = "About";
            this.TPAbout.UseVisualStyleBackColor = true;
            // 
            // BDefault
            // 
            this.BDefault.Location = new System.Drawing.Point(4, 285);
            this.BDefault.Name = "BDefault";
            this.BDefault.Size = new System.Drawing.Size(75, 23);
            this.BDefault.TabIndex = 0;
            this.BDefault.Text = "Defaults";
            this.BDefault.UseVisualStyleBackColor = true;
            this.BDefault.Click += new System.EventHandler(this.BDefault_Click);
            // 
            // BOk
            // 
            this.BOk.Location = new System.Drawing.Point(329, 285);
            this.BOk.Name = "BOk";
            this.BOk.Size = new System.Drawing.Size(75, 23);
            this.BOk.TabIndex = 1;
            this.BOk.Text = "Ok";
            this.BOk.UseVisualStyleBackColor = true;
            this.BOk.Click += new System.EventHandler(this.BOk_Click);
            // 
            // BCancel
            // 
            this.BCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BCancel.Location = new System.Drawing.Point(248, 285);
            this.BCancel.Name = "BCancel";
            this.BCancel.Size = new System.Drawing.Size(75, 23);
            this.BCancel.TabIndex = 2;
            this.BCancel.Text = "Cancel";
            this.BCancel.UseVisualStyleBackColor = true;
            this.BCancel.Click += new System.EventHandler(this.BCancel_Click);
            // 
            // LAboutTitle
            // 
            LAboutTitle.AutoSize = true;
            LAboutTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            LAboutTitle.ForeColor = System.Drawing.Color.DodgerBlue;
            LAboutTitle.Location = new System.Drawing.Point(3, 3);
            LAboutTitle.Name = "LAboutTitle";
            LAboutTitle.Size = new System.Drawing.Size(149, 39);
            LAboutTitle.TabIndex = 2;
            LAboutTitle.Text = "InfoHUD";
            // 
            // LAboutSubTitle
            // 
            LAboutSubTitle.AutoSize = true;
            LAboutSubTitle.Location = new System.Drawing.Point(8, 40);
            LAboutSubTitle.Name = "LAboutSubTitle";
            LAboutSubTitle.Size = new System.Drawing.Size(138, 13);
            LAboutSubTitle.TabIndex = 3;
            LAboutSubTitle.Text = "for Managed DirectX (MDX)";
            // 
            // TBAboutDescription
            // 
            TBAboutDescription.Location = new System.Drawing.Point(10, 58);
            TBAboutDescription.Multiline = true;
            TBAboutDescription.Name = "TBAboutDescription";
            TBAboutDescription.ReadOnly = true;
            TBAboutDescription.Size = new System.Drawing.Size(380, 189);
            TBAboutDescription.TabIndex = 4;
            TBAboutDescription.Text = resources.GetString("TBAboutDescription.Text");
            // 
            // LBAddIns
            // 
            this.LBAddIns.FormattingEnabled = true;
            this.LBAddIns.Location = new System.Drawing.Point(8, 6);
            this.LBAddIns.Name = "LBAddIns";
            this.LBAddIns.Size = new System.Drawing.Size(305, 238);
            this.LBAddIns.TabIndex = 0;
            this.LBAddIns.SelectedIndexChanged += new System.EventHandler(this.LBAddIns_SelectedIndexChanged);
            // 
            // BAddInSettings
            // 
            this.BAddInSettings.Enabled = false;
            this.BAddInSettings.Location = new System.Drawing.Point(319, 6);
            this.BAddInSettings.Name = "BAddInSettings";
            this.BAddInSettings.Size = new System.Drawing.Size(75, 23);
            this.BAddInSettings.TabIndex = 1;
            this.BAddInSettings.Text = "Settings";
            this.BAddInSettings.UseVisualStyleBackColor = true;
            this.BAddInSettings.Click += new System.EventHandler(this.BAddInSettings_Click);
            // 
            // OptionsForm
            // 
            this.AcceptButton = this.BOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BCancel;
            this.ClientSize = new System.Drawing.Size(406, 311);
            this.Controls.Add(TCMain);
            this.Controls.Add(this.BCancel);
            this.Controls.Add(this.BOk);
            this.Controls.Add(this.BDefault);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "OptionsForm";
            this.Text = "InfoHUD options";
            TCMain.ResumeLayout(false);
            TPAddIns.ResumeLayout(false);
            this.TPAbout.ResumeLayout(false);
            this.TPAbout.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BDefault;
        private System.Windows.Forms.Button BOk;
        private System.Windows.Forms.Button BCancel;
        private System.Windows.Forms.TabPage TPAbout;
        private System.Windows.Forms.Button BAddInSettings;
        private System.Windows.Forms.ListBox LBAddIns;
    }
}